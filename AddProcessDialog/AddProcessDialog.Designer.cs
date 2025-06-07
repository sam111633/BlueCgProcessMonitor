namespace BlueCgProcessMonitor
{
    partial class AddProcessDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTableLayout = new TableLayoutPanel();
            label1 = new Label();
            processNameTextBox = new TextBox();
            label2 = new Label();
            executablePathPanel = new Panel();
            browseButton = new Button();
            executablePathTextBox = new TextBox();
            label3 = new Label();
            argumentsTextBox = new TextBox();
            label4 = new Label();
            workingDirectoryTextBox = new TextBox();
            label5 = new Label();
            autoRestartCheckBox = new CheckBox();
            label6 = new Label();
            noResponseTimePanel = new Panel();
            label7 = new Label();
            noResponseTimeNumeric = new NumericUpDown();
            buttonPanel = new Panel();
            cancelButton = new Button();
            okButton = new Button();
            mainTableLayout.SuspendLayout();
            executablePathPanel.SuspendLayout();
            noResponseTimePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)noResponseTimeNumeric).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 2;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(label1, 0, 0);
            mainTableLayout.Controls.Add(processNameTextBox, 1, 0);
            mainTableLayout.Controls.Add(label2, 0, 1);
            mainTableLayout.Controls.Add(executablePathPanel, 1, 1);
            mainTableLayout.Controls.Add(label3, 0, 2);
            mainTableLayout.Controls.Add(argumentsTextBox, 1, 2);
            mainTableLayout.Controls.Add(label4, 0, 3);
            mainTableLayout.Controls.Add(workingDirectoryTextBox, 1, 3);
            mainTableLayout.Controls.Add(label5, 0, 4);
            mainTableLayout.Controls.Add(autoRestartCheckBox, 1, 4);
            mainTableLayout.Controls.Add(label6, 0, 5);
            mainTableLayout.Controls.Add(noResponseTimePanel, 1, 5);
            mainTableLayout.Controls.Add(buttonPanel, 0, 6);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(10, 10);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 7;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainTableLayout.Size = new Size(464, 260);
            mainTableLayout.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 35);
            label1.TabIndex = 0;
            label1.Text = "進程名稱：";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // processNameTextBox
            // 
            processNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            processNameTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            processNameTextBox.Location = new Point(123, 6);
            processNameTextBox.Name = "processNameTextBox";
            processNameTextBox.Size = new Size(338, 23);
            processNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(3, 35);
            label2.Name = "label2";
            label2.Size = new Size(114, 35);
            label2.TabIndex = 2;
            label2.Text = "可執行檔案：";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // executablePathPanel
            // 
            executablePathPanel.Controls.Add(browseButton);
            executablePathPanel.Controls.Add(executablePathTextBox);
            executablePathPanel.Dock = DockStyle.Fill;
            executablePathPanel.Location = new Point(123, 38);
            executablePathPanel.Name = "executablePathPanel";
            executablePathPanel.Size = new Size(338, 29);
            executablePathPanel.TabIndex = 3;
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            browseButton.Location = new Point(295, 3);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(40, 23);
            browseButton.TabIndex = 1;
            browseButton.Text = "...";
            browseButton.UseVisualStyleBackColor = true;
            // 
            // executablePathTextBox
            // 
            executablePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            executablePathTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            executablePathTextBox.Location = new Point(0, 3);
            executablePathTextBox.Name = "executablePathTextBox";
            executablePathTextBox.Size = new Size(289, 23);
            executablePathTextBox.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(3, 70);
            label3.Name = "label3";
            label3.Size = new Size(114, 35);
            label3.TabIndex = 4;
            label3.Text = "啟動參數：";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // argumentsTextBox
            // 
            argumentsTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            argumentsTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            argumentsTextBox.Location = new Point(123, 76);
            argumentsTextBox.Name = "argumentsTextBox";
            argumentsTextBox.Size = new Size(338, 23);
            argumentsTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label4.Location = new Point(3, 105);
            label4.Name = "label4";
            label4.Size = new Size(114, 35);
            label4.TabIndex = 6;
            label4.Text = "工作目錄：";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // workingDirectoryTextBox
            // 
            workingDirectoryTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            workingDirectoryTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            workingDirectoryTextBox.Location = new Point(123, 111);
            workingDirectoryTextBox.Name = "workingDirectoryTextBox";
            workingDirectoryTextBox.Size = new Size(338, 23);
            workingDirectoryTextBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label5.Location = new Point(3, 140);
            label5.Name = "label5";
            label5.Size = new Size(114, 35);
            label5.TabIndex = 8;
            label5.Text = "自動重啟：";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // autoRestartCheckBox
            // 
            autoRestartCheckBox.AutoSize = true;
            autoRestartCheckBox.Dock = DockStyle.Fill;
            autoRestartCheckBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            autoRestartCheckBox.Location = new Point(123, 143);
            autoRestartCheckBox.Name = "autoRestartCheckBox";
            autoRestartCheckBox.Size = new Size(338, 29);
            autoRestartCheckBox.TabIndex = 9;
            autoRestartCheckBox.Text = "啟用自動重啟";
            autoRestartCheckBox.UseVisualStyleBackColor = true;
            autoRestartCheckBox.CheckedChanged += autoRestartCheckBox_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label6.Location = new Point(3, 175);
            label6.Name = "label6";
            label6.Size = new Size(114, 35);
            label6.TabIndex = 10;
            label6.Text = "無回應時間：";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // noResponseTimePanel
            // 
            noResponseTimePanel.Controls.Add(label7);
            noResponseTimePanel.Controls.Add(noResponseTimeNumeric);
            noResponseTimePanel.Dock = DockStyle.Fill;
            noResponseTimePanel.Location = new Point(123, 178);
            noResponseTimePanel.Name = "noResponseTimePanel";
            noResponseTimePanel.Size = new Size(338, 29);
            noResponseTimePanel.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(120, 7);
            label7.Name = "label7";
            label7.Size = new Size(19, 16);
            label7.TabIndex = 1;
            label7.Text = "秒";
            // 
            // noResponseTimeNumeric
            // 
            noResponseTimeNumeric.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            noResponseTimeNumeric.Location = new Point(0, 3);
            noResponseTimeNumeric.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            noResponseTimeNumeric.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            noResponseTimeNumeric.Name = "noResponseTimeNumeric";
            noResponseTimeNumeric.Size = new Size(114, 23);
            noResponseTimeNumeric.TabIndex = 0;
            noResponseTimeNumeric.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // buttonPanel
            // 
            mainTableLayout.SetColumnSpan(buttonPanel, 2);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Location = new Point(3, 213);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(458, 44);
            buttonPanel.TabIndex = 12;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            cancelButton.Location = new Point(380, 10);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 28);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            okButton.Enabled = false;
            okButton.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            okButton.Location = new Point(299, 10);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 28);
            okButton.TabIndex = 0;
            okButton.Text = "確定";
            okButton.UseVisualStyleBackColor = true;
            // 
            // AddProcessDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(484, 280);
            Controls.Add(mainTableLayout);
            Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProcessDialog";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "添加進程";
            Load += AddProcessDialog_Load;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            executablePathPanel.ResumeLayout(false);
            executablePathPanel.PerformLayout();
            noResponseTimePanel.ResumeLayout(false);
            noResponseTimePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)noResponseTimeNumeric).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox processNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel executablePathPanel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox executablePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox argumentsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox workingDirectoryTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox autoRestartCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel noResponseTimePanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown noResponseTimeNumeric;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}