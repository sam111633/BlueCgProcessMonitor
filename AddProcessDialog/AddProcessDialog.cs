using System;
using System.IO;
using System.Windows.Forms;

namespace BlueCgProcessMonitor
{
    public partial class AddProcessDialog : Form
    {
        public string ProcessName { get; private set; }
        public string ExecutablePath { get; private set; }
        public string Arguments { get; private set; }
        public bool AutoRestart { get; private set; }
        public int NoResponseTime { get; private set; }
        public string WorkingDirectory { get; private set; }

        private bool isEditMode = false;

        public AddProcessDialog()
        {
            InitializeComponent();
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            // 設定預設值
            autoRestartCheckBox.Checked = true;
            noResponseTimeNumeric.Value = 20;

            // 設定事件處理
            browseButton.Click += BrowseButton_Click;
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;

            // 文字變更事件
            processNameTextBox.TextChanged += ProcessNameTextBox_TextChanged;
            executablePathTextBox.TextChanged += ExecutablePathTextBox_TextChanged;
        }

        private void ProcessNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOkButtonState();
        }

        private void ExecutablePathTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOkButtonState();
        }

        // 添加缺失的事件處理方法
        private void autoRestartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 可以在這裡添加相關邏輯，例如啟用/禁用相關控件
            // 目前暫時空實現
        }

        private void UpdateOkButtonState()
        {
            okButton.Enabled = !string.IsNullOrWhiteSpace(processNameTextBox.Text) &&
                              !string.IsNullOrWhiteSpace(executablePathTextBox.Text);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "可執行檔案 (*.exe)|*.exe|所有檔案 (*.*)|*.*";
                dialog.Title = "選擇可執行檔案";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    executablePathTextBox.Text = dialog.FileName;

                    // 自動填入進程名稱
                    if (string.IsNullOrWhiteSpace(processNameTextBox.Text))
                    {
                        processNameTextBox.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
                    }

                    // 自動填入工作目錄
                    if (string.IsNullOrWhiteSpace(workingDirectoryTextBox.Text))
                    {
                        workingDirectoryTextBox.Text = Path.GetDirectoryName(dialog.FileName);
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // 驗證輸入
            if (string.IsNullOrWhiteSpace(processNameTextBox.Text))
            {
                MessageBox.Show("請輸入進程名稱！", "驗證錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                processNameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(executablePathTextBox.Text))
            {
                MessageBox.Show("請選擇可執行檔案！", "驗證錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                executablePathTextBox.Focus();
                return;
            }

            if (!File.Exists(executablePathTextBox.Text))
            {
                MessageBox.Show("指定的可執行檔案不存在！", "驗證錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                executablePathTextBox.Focus();
                return;
            }

            // 設定屬性值
            ProcessName = processNameTextBox.Text.Trim();
            ExecutablePath = executablePathTextBox.Text.Trim();
            Arguments = argumentsTextBox.Text.Trim();
            AutoRestart = autoRestartCheckBox.Checked;
            NoResponseTime = (int)noResponseTimeNumeric.Value;
            WorkingDirectory = workingDirectoryTextBox.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 設定編輯模式
        /// </summary>
        /// <param name="processItem">要編輯的進程項目</param>
        public void SetEditMode(ProcessMonitorItem processItem)
        {
            if (processItem == null) return;

            isEditMode = true;
            this.Text = "編輯進程";

            // 填入現有數據
            processNameTextBox.Text = processItem.ProcessName;
            executablePathTextBox.Text = processItem.ExecutablePath;
            argumentsTextBox.Text = processItem.Arguments;
            autoRestartCheckBox.Checked = processItem.AutoRestart;
            noResponseTimeNumeric.Value = processItem.NoResponseTime;
            workingDirectoryTextBox.Text = processItem.WorkingDirectory;
        }

        private void AddProcessDialog_Load(object sender, EventArgs e)
        {
            // 窗體載入事件
            UpdateOkButtonState();
        }
    }
}