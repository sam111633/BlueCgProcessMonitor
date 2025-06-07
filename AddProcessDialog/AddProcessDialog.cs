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
            // �]�w�w�]��
            autoRestartCheckBox.Checked = true;
            noResponseTimeNumeric.Value = 20;

            // �]�w�ƥ�B�z
            browseButton.Click += BrowseButton_Click;
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;

            // ��r�ܧ�ƥ�
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

        // �K�[�ʥ����ƥ�B�z��k
        private void autoRestartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // �i�H�b�o�̲K�[�����޿�A�Ҧp�ҥ�/�T�ά�������
            // �ثe�ȮɪŹ�{
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
                dialog.Filter = "�i�����ɮ� (*.exe)|*.exe|�Ҧ��ɮ� (*.*)|*.*";
                dialog.Title = "��ܥi�����ɮ�";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    executablePathTextBox.Text = dialog.FileName;

                    // �۰ʶ�J�i�{�W��
                    if (string.IsNullOrWhiteSpace(processNameTextBox.Text))
                    {
                        processNameTextBox.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
                    }

                    // �۰ʶ�J�u�@�ؿ�
                    if (string.IsNullOrWhiteSpace(workingDirectoryTextBox.Text))
                    {
                        workingDirectoryTextBox.Text = Path.GetDirectoryName(dialog.FileName);
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // ���ҿ�J
            if (string.IsNullOrWhiteSpace(processNameTextBox.Text))
            {
                MessageBox.Show("�п�J�i�{�W�١I", "���ҿ��~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                processNameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(executablePathTextBox.Text))
            {
                MessageBox.Show("�п�ܥi�����ɮסI", "���ҿ��~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                executablePathTextBox.Focus();
                return;
            }

            if (!File.Exists(executablePathTextBox.Text))
            {
                MessageBox.Show("���w���i�����ɮפ��s�b�I", "���ҿ��~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                executablePathTextBox.Focus();
                return;
            }

            // �]�w�ݩʭ�
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
        /// �]�w�s��Ҧ�
        /// </summary>
        /// <param name="processItem">�n�s�誺�i�{����</param>
        public void SetEditMode(ProcessMonitorItem processItem)
        {
            if (processItem == null) return;

            isEditMode = true;
            this.Text = "�s��i�{";

            // ��J�{���ƾ�
            processNameTextBox.Text = processItem.ProcessName;
            executablePathTextBox.Text = processItem.ExecutablePath;
            argumentsTextBox.Text = processItem.Arguments;
            autoRestartCheckBox.Checked = processItem.AutoRestart;
            noResponseTimeNumeric.Value = processItem.NoResponseTime;
            workingDirectoryTextBox.Text = processItem.WorkingDirectory;
        }

        private void AddProcessDialog_Load(object sender, EventArgs e)
        {
            // ������J�ƥ�
            UpdateOkButtonState();
        }
    }
}