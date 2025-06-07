using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlueCgProcessMonitor
{
    public partial class PacketConfigDialog : Form
    {
        private PacketConfigItem config;
        private bool isEditMode = false;

        // �����n�� - �T�O�W�ٻP�ϥήɤ@�P
        private TableLayoutPanel mainTableLayout;
        private Label label1;
        private TextBox packetNameTextBox;
        private Label label2;
        private NumericUpDown periodNumeric;
        private Label label3;
        private TextBox targetProcessTextBox;
        private Label label4;
        private TextBox packetDataTextBox;
        private Label label5;
        private Panel intervalPanel;
        private Label label6;
        private NumericUpDown intervalNumeric;
        private Label label7;
        private NumericUpDown maxRetriesNumeric;
        private Label label8;
        private CheckBox enabledCheckBox;
        private Label label9;
        private TextBox notesTextBox;
        private Panel buttonPanel;
        private Button cancelButton;
        private Button okButton;

        public PacketConfigDialog()
        {
            InitializeComponent();
            InitializeDialog();
        }

        private void InitializeComponent()
        {
            this.mainTableLayout = new TableLayoutPanel();
            this.label1 = new Label();
            this.packetNameTextBox = new TextBox();
            this.label2 = new Label();
            this.periodNumeric = new NumericUpDown();
            this.label3 = new Label();
            this.targetProcessTextBox = new TextBox();
            this.label4 = new Label();
            this.packetDataTextBox = new TextBox();
            this.label5 = new Label();
            this.intervalPanel = new Panel();
            this.label6 = new Label();
            this.intervalNumeric = new NumericUpDown();
            this.label7 = new Label();
            this.maxRetriesNumeric = new NumericUpDown();
            this.label8 = new Label();
            this.enabledCheckBox = new CheckBox();
            this.label9 = new Label();
            this.notesTextBox = new TextBox();
            this.buttonPanel = new Panel();
            this.cancelButton = new Button();
            this.okButton = new Button();

            this.mainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumeric)).BeginInit();
            this.intervalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRetriesNumeric)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.label1, 0, 0);
            this.mainTableLayout.Controls.Add(this.packetNameTextBox, 1, 0);
            this.mainTableLayout.Controls.Add(this.label2, 0, 1);
            this.mainTableLayout.Controls.Add(this.periodNumeric, 1, 1);
            this.mainTableLayout.Controls.Add(this.label3, 0, 2);
            this.mainTableLayout.Controls.Add(this.targetProcessTextBox, 1, 2);
            this.mainTableLayout.Controls.Add(this.label4, 0, 3);
            this.mainTableLayout.Controls.Add(this.packetDataTextBox, 1, 3);
            this.mainTableLayout.Controls.Add(this.label5, 0, 4);
            this.mainTableLayout.Controls.Add(this.intervalPanel, 1, 4);
            this.mainTableLayout.Controls.Add(this.label7, 0, 5);
            this.mainTableLayout.Controls.Add(this.maxRetriesNumeric, 1, 5);
            this.mainTableLayout.Controls.Add(this.label8, 0, 6);
            this.mainTableLayout.Controls.Add(this.enabledCheckBox, 1, 6);
            this.mainTableLayout.Controls.Add(this.label9, 0, 7);
            this.mainTableLayout.Controls.Add(this.notesTextBox, 1, 7);
            this.mainTableLayout.Controls.Add(this.buttonPanel, 0, 8);
            this.mainTableLayout.Dock = DockStyle.Fill;
            this.mainTableLayout.Location = new Point(10, 10);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 9;
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.mainTableLayout.Size = new Size(464, 430);
            this.mainTableLayout.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = DockStyle.Fill;
            this.label1.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label1.Location = new Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(114, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "�o�]���W�١G";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // packetNameTextBox
            // 
            this.packetNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.packetNameTextBox.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.packetNameTextBox.Location = new Point(123, 6);
            this.packetNameTextBox.Name = "packetNameTextBox";
            this.packetNameTextBox.Size = new Size(338, 23);
            this.packetNameTextBox.TabIndex = 1;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = DockStyle.Fill;
            this.label2.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label2.Location = new Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new Size(114, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "���ơG";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // periodNumeric
            // 
            this.periodNumeric.Anchor = AnchorStyles.Left;
            this.periodNumeric.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.periodNumeric.Location = new Point(123, 41);
            this.periodNumeric.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.periodNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.periodNumeric.Name = "periodNumeric";
            this.periodNumeric.Size = new Size(100, 23);
            this.periodNumeric.TabIndex = 3;
            this.periodNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = DockStyle.Fill;
            this.label3.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label3.Location = new Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new Size(114, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "�ؼжi�{�G";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // targetProcessTextBox
            // 
            this.targetProcessTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.targetProcessTextBox.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.targetProcessTextBox.Location = new Point(123, 76);
            this.targetProcessTextBox.Name = "targetProcessTextBox";
            this.targetProcessTextBox.Size = new Size(338, 23);
            this.targetProcessTextBox.TabIndex = 5;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = DockStyle.Fill;
            this.label4.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label4.Location = new Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new Size(114, 80);
            this.label4.TabIndex = 6;
            this.label4.Text = "�o�]�ƾڡG";

            // 
            // packetDataTextBox
            // 
            this.packetDataTextBox.Dock = DockStyle.Fill;
            this.packetDataTextBox.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.packetDataTextBox.Location = new Point(123, 108);
            this.packetDataTextBox.Multiline = true;
            this.packetDataTextBox.Name = "packetDataTextBox";
            this.packetDataTextBox.ScrollBars = ScrollBars.Vertical;
            this.packetDataTextBox.Size = new Size(338, 74);
            this.packetDataTextBox.TabIndex = 7;

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = DockStyle.Fill;
            this.label5.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label5.Location = new Point(3, 185);
            this.label5.Name = "label5";
            this.label5.Size = new Size(114, 35);
            this.label5.TabIndex = 8;
            this.label5.Text = "�o�]���j�G";
            this.label5.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // intervalPanel
            // 
            this.intervalPanel.Controls.Add(this.label6);
            this.intervalPanel.Controls.Add(this.intervalNumeric);
            this.intervalPanel.Dock = DockStyle.Fill;
            this.intervalPanel.Location = new Point(123, 188);
            this.intervalPanel.Name = "intervalPanel";
            this.intervalPanel.Size = new Size(338, 29);
            this.intervalPanel.TabIndex = 9;

            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new Point(120, 7);
            this.label6.Name = "label6";
            this.label6.Size = new Size(31, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "�@��";

            // 
            // intervalNumeric
            // 
            this.intervalNumeric.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.intervalNumeric.Location = new Point(0, 3);
            this.intervalNumeric.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            this.intervalNumeric.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            this.intervalNumeric.Name = "intervalNumeric";
            this.intervalNumeric.Size = new Size(114, 23);
            this.intervalNumeric.TabIndex = 0;
            this.intervalNumeric.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = DockStyle.Fill;
            this.label7.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label7.Location = new Point(3, 220);
            this.label7.Name = "label7";
            this.label7.Size = new Size(114, 35);
            this.label7.TabIndex = 10;
            this.label7.Text = "�̤j���զ��ơG";
            this.label7.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // maxRetriesNumeric
            // 
            this.maxRetriesNumeric.Anchor = AnchorStyles.Left;
            this.maxRetriesNumeric.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.maxRetriesNumeric.Location = new Point(123, 226);
            this.maxRetriesNumeric.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.maxRetriesNumeric.Name = "maxRetriesNumeric";
            this.maxRetriesNumeric.Size = new Size(100, 23);
            this.maxRetriesNumeric.TabIndex = 11;
            this.maxRetriesNumeric.Value = new decimal(new int[] { 3, 0, 0, 0 });

            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = DockStyle.Fill;
            this.label8.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label8.Location = new Point(3, 255);
            this.label8.Name = "label8";
            this.label8.Size = new Size(114, 35);
            this.label8.TabIndex = 12;
            this.label8.Text = "�ҥΪ��A�G";
            this.label8.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Dock = DockStyle.Fill;
            this.enabledCheckBox.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.enabledCheckBox.Location = new Point(123, 258);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new Size(338, 29);
            this.enabledCheckBox.TabIndex = 13;
            this.enabledCheckBox.Text = "�ҥΦ��o�]�t�m";
            this.enabledCheckBox.UseVisualStyleBackColor = true;

            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = DockStyle.Fill;
            this.label9.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.label9.Location = new Point(3, 290);
            this.label9.Name = "label9";
            this.label9.Size = new Size(114, 90);
            this.label9.TabIndex = 14;
            this.label9.Text = "�Ƶ��G";

            // 
            // notesTextBox
            // 
            this.notesTextBox.Dock = DockStyle.Fill;
            this.notesTextBox.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.notesTextBox.Location = new Point(123, 293);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = ScrollBars.Vertical;
            this.notesTextBox.Size = new Size(338, 84);
            this.notesTextBox.TabIndex = 15;

            // 
            // buttonPanel
            // 
            this.mainTableLayout.SetColumnSpan(this.buttonPanel, 2);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Dock = DockStyle.Fill;
            this.buttonPanel.Location = new Point(3, 383);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new Size(458, 44);
            this.buttonPanel.TabIndex = 16;

            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.cancelButton.DialogResult = DialogResult.Cancel;
            this.cancelButton.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.cancelButton.Location = new Point(380, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new Size(75, 28);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "����";
            this.cancelButton.UseVisualStyleBackColor = true;

            // 
            // okButton
            // 
            this.okButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.okButton.Enabled = false;
            this.okButton.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.okButton.Location = new Point(299, 10);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(75, 28);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "�T�w";
            this.okButton.UseVisualStyleBackColor = true;

            // 
            // PacketConfigDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new SizeF(7F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new Size(484, 450);
            this.Controls.Add(this.mainTableLayout);
            this.Font = new Font("�L�n������", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PacketConfigDialog";
            this.Padding = new Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "�K�[�o�]�t�m";
            this.Load += new EventHandler(this.PacketConfigDialog_Load);

            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumeric)).EndInit();
            this.intervalPanel.ResumeLayout(false);
            this.intervalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRetriesNumeric)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void InitializeDialog()
        {
            // �]�w�w�]��
            periodNumeric.Value = 1;
            intervalNumeric.Value = 1000;
            maxRetriesNumeric.Value = 3;
            enabledCheckBox.Checked = true;

            // �]�w�ƥ�B�z
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;

            // ��r�ܧ�ƥ�
            packetNameTextBox.TextChanged += PacketNameTextBox_TextChanged;
            targetProcessTextBox.TextChanged += TargetProcessTextBox_TextChanged;
        }

        private void PacketNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOkButtonState();
        }

        private void TargetProcessTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOkButtonState();
        }

        private void UpdateOkButtonState()
        {
            okButton.Enabled = !string.IsNullOrWhiteSpace(packetNameTextBox.Text) &&
                              !string.IsNullOrWhiteSpace(targetProcessTextBox.Text);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // ���ҿ�J
            if (string.IsNullOrWhiteSpace(packetNameTextBox.Text))
            {
                MessageBox.Show("�п�J�o�]���W�١I", "���ҿ��~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                packetNameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(targetProcessTextBox.Text))
            {
                MessageBox.Show("�п�J�ؼжi�{�W�١I", "���ҿ��~", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                targetProcessTextBox.Focus();
                return;
            }

            // �ЫةΧ�s�t�m
            if (config == null)
            {
                config = new PacketConfigItem();
            }

            config.PacketName = packetNameTextBox.Text.Trim();
            config.Period = (int)periodNumeric.Value;
            config.TargetProcess = targetProcessTextBox.Text.Trim();
            config.PacketData = packetDataTextBox.Text.Trim();
            config.Interval = (int)intervalNumeric.Value;
            config.MaxRetries = (int)maxRetriesNumeric.Value;
            config.IsEnabled = enabledCheckBox.Checked;
            config.Notes = notesTextBox.Text.Trim();

            if (!isEditMode)
            {
                config.CreateTime = DateTime.Now;
            }
            config.UpdateTime = DateTime.Now;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// ����t�m����
        /// </summary>
        /// <returns>�o�]�t�m����</returns>
        public PacketConfigItem GetConfig()
        {
            return config;
        }

        /// <summary>
        /// �]�w�s��Ҧ�
        /// </summary>
        /// <param name="configItem">�n�s�誺�t�m����</param>
        public void SetEditMode(PacketConfigItem configItem)
        {
            if (configItem == null) return;

            isEditMode = true;
            config = configItem;
            this.Text = "�s��o�]�t�m";

            // ��J�{���ƾ�
            packetNameTextBox.Text = configItem.PacketName;
            periodNumeric.Value = configItem.Period;
            targetProcessTextBox.Text = configItem.TargetProcess;
            packetDataTextBox.Text = configItem.PacketData;
            intervalNumeric.Value = configItem.Interval;
            maxRetriesNumeric.Value = configItem.MaxRetries;
            enabledCheckBox.Checked = configItem.IsEnabled;
            notesTextBox.Text = configItem.Notes;
        }

        private void PacketConfigDialog_Load(object sender, EventArgs e)
        {
            // ������J�ƥ�B�z
            UpdateOkButtonState();
        }
    }
}