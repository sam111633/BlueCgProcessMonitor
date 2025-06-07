using System.Diagnostics;
using System.Security.Principal;

namespace BlueCgProcessMonitor
{
    static class Program
    {
        private static Mutex mutex = null;
        private const string APP_NAME = "BlueCgProcessMonitor";

        /// <summary>
        /// 應用程序的主入口點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 設置應用程序異常處理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // 檢查是否已經有實例運行
            if (!CheckSingleInstance())
            {
                MessageBox.Show("BlueCg 進程監控管理系統已經在運行中！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 檢查管理員權限
                if (!IsRunAsAdministrator())
                {
                    var result = MessageBox.Show(
                        "建議以管理員權限運行此程序以獲得更好的監控效果。\n\n" +
                        "是否要以管理員權限重新啟動？",
                        "權限提示",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        RestartAsAdministrator();
                        return;
                    }
                }

                // 創建必要的目錄
                CreateRequiredDirectories();

                // 載入配置
                LoadConfiguration();

                // 啟動主窗體
                var mainForm = new MainForm();

                // 處理命令行參數
                ProcessCommandLineArgs(args, mainForm);

                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                ShowFatalError(ex);
            }
            finally
            {
                // 清理資源
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                    mutex.Dispose();
                }
            }
        }

        /// <summary>
        /// 檢查是否為單一實例
        /// </summary>
        private static bool CheckSingleInstance()
        {
            bool createdNew;
            mutex = new Mutex(true, APP_NAME, out createdNew);

            if (!createdNew)
            {
                // 嘗試激活已存在的實例
                ActivateExistingInstance();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 激活已存在的實例
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
                        // 使用 Windows API 激活窗口
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
                Debug.WriteLine($"激活已存在實例失敗: {ex.Message}");
            }
        }

        /// <summary>
        /// 檢查是否以管理員權限運行
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
        /// 以管理員權限重新啟動
        /// </summary>
        private static void RestartAsAdministrator()
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    UseShellExecute = true,
                    Verb = "runas" // 以管理員身份運行
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"以管理員權限啟動失敗: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 創建必要的目錄
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
                Debug.WriteLine($"創建目錄失敗: {ex.Message}");
            }
        }

        /// <summary>
        /// 載入配置
        /// </summary>
        private static void LoadConfiguration()
        {
            try
            {
                // 這裡可以載入應用程序的全局配置
                // 例如從註冊表、配置文件等載入設置
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"載入配置失敗: {ex.Message}");
            }
        }

        /// <summary>
        /// 處理命令行參數
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
                            // 啟動時最小化
                            mainForm.WindowState = FormWindowState.Minimized;
                            mainForm.ShowInTaskbar = false;
                            break;

                        case "/autostart":
                        case "-autostart":
                            // 自動開始監控
                            // 這個功能需要在主窗體中實現
                            break;

                        case "/config":
                        case "-config":
                            // 載入指定的配置文件
                            if (i + 1 < args.Length)
                            {
                                var configFile = args[i + 1];
                                // 載入配置文件的邏輯
                                i++; // 跳過下一個參數
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
                Debug.WriteLine($"處理命令行參數失敗: {ex.Message}");
            }
        }

        /// <summary>
        /// 顯示幫助信息
        /// </summary>
        private static void ShowHelp()
        {
            var helpText = @"BlueCg 進程監控管理系統 - 命令行參數說明

參數:
  /minimized    啟動時最小化到系統托盤
  /autostart    啟動後自動開始監控
  /config <file> 載入指定的配置文件
  /help         顯示此幫助信息

示例:
  BlueCgProcessMonitor.exe /minimized /autostart
  BlueCgProcessMonitor.exe /config ""C:\MyConfig.xml""
";

            MessageBox.Show(helpText, "命令行參數說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 應用程序異常處理
        /// </summary>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                LogException(e.Exception);

                var result = MessageBox.Show(
                    $"應用程序發生未處理的異常:\n\n{e.Exception.Message}\n\n是否要繼續運行？",
                    "應用程序異常",
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
                    MessageBox.Show("發生嚴重錯誤，程序將關閉。", "嚴重錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// 域異常處理
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                LogException(exception);

                MessageBox.Show(
                    $"應用程序發生未處理的異常:\n\n{exception?.Message ?? "未知錯誤"}\n\n程序將關閉。",
                    "應用程序異常",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                // 最後的防線
            }
            finally
            {
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// 記錄異常到日誌
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

                var logContent = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] 異常發生:\n" +
                               $"消息: {exception.Message}\n" +
                               $"堆棧: {exception.StackTrace}\n" +
                               $"內部異常: {exception.InnerException?.Message}\n" +
                               new string('-', 80) + "\n\n";

                File.AppendAllText(logPath, logContent);
            }
            catch
            {
                // 記錄日誌失敗，忽略
            }
        }

        /// <summary>
        /// 顯示致命錯誤
        /// </summary>
        private static void ShowFatalError(Exception exception)
        {
            var message = $"程序啟動失敗:\n\n{exception.Message}\n\n" +
                         "請檢查以下項目:\n" +
                         "1. 是否有足夠的權限\n" +
                         "2. 相關文件是否完整\n" +
                         "3. .NET Framework 是否正確安裝\n\n" +
                         "如問題持續，請聯繫技術支持。";

            MessageBox.Show(message, "程序啟動失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LogException(exception);
        }
    }

    /// <summary>
    /// Windows API 方法
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