using System.Diagnostics;
using System.Security.Principal;

namespace BlueCgProcessMonitor
{
    static class Program
    {
        private static Mutex mutex = null;
        private const string APP_NAME = "BlueCgProcessMonitor";

        /// <summary>
        /// ���ε{�Ǫ��D�J�f�I�C
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // �]�m���ε{�ǲ��`�B�z
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // �ˬd�O�_�w�g����ҹB��
            if (!CheckSingleInstance())
            {
                MessageBox.Show("BlueCg �i�{�ʱ��޲z�t�Τw�g�b�B�椤�I", "����",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // �ˬd�޲z���v��
                if (!IsRunAsAdministrator())
                {
                    var result = MessageBox.Show(
                        "��ĳ�H�޲z���v���B�榹�{�ǥH��o��n���ʱ��ĪG�C\n\n" +
                        "�O�_�n�H�޲z���v�����s�ҰʡH",
                        "�v������",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        RestartAsAdministrator();
                        return;
                    }
                }

                // �Ыإ��n���ؿ�
                CreateRequiredDirectories();

                // ���J�t�m
                LoadConfiguration();

                // �ҰʥD����
                var mainForm = new MainForm();

                // �B�z�R�O��Ѽ�
                ProcessCommandLineArgs(args, mainForm);

                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                ShowFatalError(ex);
            }
            finally
            {
                // �M�z�귽
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                    mutex.Dispose();
                }
            }
        }

        /// <summary>
        /// �ˬd�O�_����@���
        /// </summary>
        private static bool CheckSingleInstance()
        {
            bool createdNew;
            mutex = new Mutex(true, APP_NAME, out createdNew);

            if (!createdNew)
            {
                // ���տE���w�s�b�����
                ActivateExistingInstance();
                return false;
            }

            return true;
        }

        /// <summary>
        /// �E���w�s�b�����
        /// </summary>
        private static void ActivateExistingInstance()
        {
            try
            {
                var processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                foreach (var process in processes)
                {
                    if (process.Id != Process.GetCurrentProcess().Id)
                    {
                        // �ϥ� Windows API �E�����f
                        NativeMethods.SetForegroundWindow(process.MainWindowHandle);
                        if (NativeMethods.IsIconic(process.MainWindowHandle))
                        {
                            NativeMethods.ShowWindow(process.MainWindowHandle, NativeMethods.SW_RESTORE);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�E���w�s�b��ҥ���: {ex.Message}");
            }
        }

        /// <summary>
        /// �ˬd�O�_�H�޲z���v���B��
        /// </summary>
        private static bool IsRunAsAdministrator()
        {
            try
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// �H�޲z���v�����s�Ұ�
        /// </summary>
        private static void RestartAsAdministrator()
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    UseShellExecute = true,
                    Verb = "runas" // �H�޲z�������B��
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�H�޲z���v���Ұʥ���: {ex.Message}", "���~",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// �Ыإ��n���ؿ�
        /// </summary>
        private static void CreateRequiredDirectories()
        {
            try
            {
                var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), APP_NAME);
                if (!Directory.Exists(appDataPath))
                {
                    Directory.CreateDirectory(appDataPath);
                }

                var logsPath = Path.Combine(appDataPath, "Logs");
                if (!Directory.Exists(logsPath))
                {
                    Directory.CreateDirectory(logsPath);
                }

                var configPath = Path.Combine(appDataPath, "Config");
                if (!Directory.Exists(configPath))
                {
                    Directory.CreateDirectory(configPath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�Ыإؿ�����: {ex.Message}");
            }
        }

        /// <summary>
        /// ���J�t�m
        /// </summary>
        private static void LoadConfiguration()
        {
            try
            {
                // �o�̥i�H���J���ε{�Ǫ������t�m
                // �Ҧp�q���U��B�t�m��󵥸��J�]�m
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"���J�t�m����: {ex.Message}");
            }
        }

        /// <summary>
        /// �B�z�R�O��Ѽ�
        /// </summary>
        private static void ProcessCommandLineArgs(string[] args, MainForm mainForm)
        {
            if (args.Length == 0)
                return;

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "/minimized":
                        case "-minimized":
                            // �Ұʮɳ̤p��
                            mainForm.WindowState = FormWindowState.Minimized;
                            mainForm.ShowInTaskbar = false;
                            break;

                        case "/autostart":
                        case "-autostart":
                            // �۰ʶ}�l�ʱ�
                            // �o�ӥ\��ݭn�b�D���餤��{
                            break;

                        case "/config":
                        case "-config":
                            // ���J���w���t�m���
                            if (i + 1 < args.Length)
                            {
                                var configFile = args[i + 1];
                                // ���J�t�m����޿�
                                i++; // ���L�U�@�ӰѼ�
                            }
                            break;

                        case "/help":
                        case "-help":
                        case "/?":
                            ShowHelp();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�B�z�R�O��Ѽƥ���: {ex.Message}");
            }
        }

        /// <summary>
        /// ������U�H��
        /// </summary>
        private static void ShowHelp()
        {
            var helpText = @"BlueCg �i�{�ʱ��޲z�t�� - �R�O��Ѽƻ���

�Ѽ�:
  /minimized    �Ұʮɳ̤p�ƨ�t�Φ��L
  /autostart    �Ұʫ�۰ʶ}�l�ʱ�
  /config <file> ���J���w���t�m���
  /help         ��ܦ����U�H��

�ܨ�:
  BlueCgProcessMonitor.exe /minimized /autostart
  BlueCgProcessMonitor.exe /config ""C:\MyConfig.xml""
";

            MessageBox.Show(helpText, "�R�O��Ѽƻ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ���ε{�ǲ��`�B�z
        /// </summary>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                LogException(e.Exception);

                var result = MessageBox.Show(
                    $"���ε{�ǵo�ͥ��B�z�����`:\n\n{e.Exception.Message}\n\n�O�_�n�~��B��H",
                    "���ε{�ǲ��`",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            catch
            {
                try
                {
                    MessageBox.Show("�o���Y�����~�A�{�ǱN�����C", "�Y�����~",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// �첧�`�B�z
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                LogException(exception);

                MessageBox.Show(
                    $"���ε{�ǵo�ͥ��B�z�����`:\n\n{exception?.Message ?? "�������~"}\n\n�{�ǱN�����C",
                    "���ε{�ǲ��`",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                // �̫᪺���u
            }
            finally
            {
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// �O�����`���x
        /// </summary>
        private static void LogException(Exception exception)
        {
            try
            {
                if (exception == null) return;

                var logPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    APP_NAME,
                    "Logs",
                    $"Error_{DateTime.Now:yyyyMMdd}.log");

                var logContent = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ���`�o��:\n" +
                               $"����: {exception.Message}\n" +
                               $"���: {exception.StackTrace}\n" +
                               $"�������`: {exception.InnerException?.Message}\n" +
                               new string('-', 80) + "\n\n";

                File.AppendAllText(logPath, logContent);
            }
            catch
            {
                // �O����x���ѡA����
            }
        }

        /// <summary>
        /// ��ܭP�R���~
        /// </summary>
        private static void ShowFatalError(Exception exception)
        {
            var message = $"�{�ǱҰʥ���:\n\n{exception.Message}\n\n" +
                         "���ˬd�H�U����:\n" +
                         "1. �O�_���������v��\n" +
                         "2. �������O�_����\n" +
                         "3. .NET Framework �O�_���T�w��\n\n" +
                         "�p���D����A���pô�޳N����C";

            MessageBox.Show(message, "�{�ǱҰʥ���", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LogException(exception);
        }
    }

    /// <summary>
    /// Windows API ��k
    /// </summary>
    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        public const int SW_RESTORE = 9;
    }
}