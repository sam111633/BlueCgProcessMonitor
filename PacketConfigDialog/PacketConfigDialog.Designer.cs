namespace BlueCgProcessMonitor
{
    partial class PacketConfigDialog
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
            packetNameTextBox = new TextBox();
            label2 = new Label();
            periodNumeric = new NumericUpDown();
            label3 = new Label();
            targetProcessTextBox = new TextBox();
            label4 = new Label();
            packetDataTextBox = new TextBox();
            label5 = new Label();
            intervalPanel = new Panel();
            label6 = new Label();
            intervalNumeric = new NumericUpDown();
            label7 = new Label();
            maxRetriesNumeric = new NumericUpDown();
            label8 = new Label();
            enabledCheckBox = new CheckBox();
            label9 = new Label();
            notesTextBox = new TextBox();
            buttonPanel = new Panel();
            cancelButton = new Button();
            okButton = new Button();
            mainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)periodNumeric).BeginInit();
            intervalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)intervalNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxRetriesNumeric).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 2;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(label1, 0, 0);
            mainTableLayout.Controls.Add(packetNameTextBox, 1, 0);
            mainTableLayout.Controls.Add(label2, 0, 1);
            mainTableLayout.Controls.Add(periodNumeric, 1, 1);
            mainTableLayout.Controls.Add(label3, 0, 2);
            mainTableLayout.Controls.Add(targetProcessTextBox, 1, 2);
            mainTableLayout.Controls.Add(label4, 0, 3);
            mainTableLayout.Controls.Add(packetDataTextBox, 1, 3);
            mainTableLayout.Controls.Add(label5, 0, 4);
            mainTableLayout.Controls.Add(intervalPanel, 1, 4);
            mainTableLayout.Controls.Add(label7, 0, 5);
            mainTableLayout.Controls.Add(maxRetriesNumeric, 1, 5);
            mainTableLayout.Controls.Add(label8, 0, 6);
            mainTableLayout.Controls.Add(enabledCheckBox, 1, 6);
            mainTableLayout.Controls.Add(label9, 0, 7);
            mainTableLayout.Controls.Add(notesTextBox, 1, 7);
            mainTableLayout.Controls.Add(buttonPanel, 0, 8);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(10, 10);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 9;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainTableLayout.Size = new Size(464, 430);
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
            label1.Text = "發包器名稱：";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // packetNameTextBox
            // 
            packetNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            packetNameTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            packetNameTextBox.Location = new Point(123, 6);
            packetNameTextBox.Name = "packetNameTextBox";
            packetNameTextBox.Size = new Size(338, 23);
            packetNameTextBox.TabIndex = 1;
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
            label2.Text = "期數：";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // periodNumeric
            // 
            periodNumeric.Anchor = AnchorStyles.Left;
            periodNumeric.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            periodNumeric.Location = new Point(123, 41);
            periodNumeric.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            periodNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            periodNumeric.Name = "periodNumeric";
            periodNumeric.Size = new Size(100, 23);
            periodNumeric.TabIndex = 3;
            periodNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            label3.Text = "目標進程：";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // targetProcessTextBox
            // 
            targetProcessTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            targetProcessTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            targetProcessTextBox.Location = new Point(123, 76);
            targetProcessTextBox.Name = "targetProcessTextBox";
            targetProcessTextBox.Size = new Size(338, 23);
            targetProcessTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label4.Location = new Point(3, 105);
            label4.Name = "label4";
            label4.Size = new Size(114, 80);
            label4.TabIndex = 6;
            label4.Text = "發包數據：";
            // 
            // packetDataTextBox
            // 
            packetDataTextBox.Dock = DockStyle.Fill;
            packetDataTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            packetDataTextBox.Location = new Point(123, 108);
            packetDataTextBox.Multiline = true;
            packetDataTextBox.Name = "packetDataTextBox";
            packetDataTextBox.ScrollBars = ScrollBars.Vertical;
            packetDataTextBox.Size = new Size(338, 74);
            packetDataTextBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label5.Location = new Point(3, 185);
            label5.Name = "label5";
            label5.Size = new Size(114, 35);
            label5.TabIndex = 8;
            label5.Text = "發包間隔：";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // intervalPanel
            // 
            intervalPanel.Controls.Add(label6);
            intervalPanel.Controls.Add(intervalNumeric);
            intervalPanel.Dock = DockStyle.Fill;
            intervalPanel.Location = new Point(123, 188);
            intervalPanel.Name = "intervalPanel";
            intervalPanel.Size = new Size(338, 29);
            intervalPanel.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(120, 7);
            label6.Name = "label6";
            label6.Size = new Size(31, 16);
            label6.TabIndex = 1;
            label6.Text = "毫秒";
            // 
            // intervalNumeric
            // 
            intervalNumeric.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            intervalNumeric.Location = new Point(0, 3);
            intervalNumeric.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            intervalNumeric.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            intervalNumeric.Name = "intervalNumeric";
            intervalNumeric.Size = new Size(114, 23);
            intervalNumeric.TabIndex = 0;
            intervalNumeric.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label7.Location = new Point(3, 220);
            label7.Name = "label7";
            label7.Size = new Size(114, 35);
            label7.TabIndex = 10;
            label7.Text = "最大重試次數：";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // maxRetriesNumeric
            // 
            maxRetriesNumeric.Anchor = AnchorStyles.Left;
            maxRetriesNumeric.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            maxRetriesNumeric.Location = new Point(123, 226);
            maxRetriesNumeric.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            maxRetriesNumeric.Name = "maxRetriesNumeric";
            maxRetriesNumeric.Size = new Size(100, 23);
            maxRetriesNumeric.TabIndex = 11;
            maxRetriesNumeric.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label8.Location = new Point(3, 255);
            label8.Name = "label8";
            label8.Size = new Size(114, 35);
            label8.TabIndex = 12;
            label8.Text = "啟用狀態：";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // enabledCheckBox
            // 
            enabledCheckBox.AutoSize = true;
            enabledCheckBox.Dock = DockStyle.Fill;
            enabledCheckBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            enabledCheckBox.Location = new Point(123, 258);
            enabledCheckBox.Name = "enabledCheckBox";
            enabledCheckBox.Size = new Size(338, 29);
            enabledCheckBox.TabIndex = 13;
            enabledCheckBox.Text = "啟用此發包配置";
            enabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label9.Location = new Point(3, 290);
            label9.Name = "label9";
            label9.Size = new Size(114, 90);
            label9.TabIndex = 14;
            label9.Text = "備註：";
            // 
            // notesTextBox
            // 
            notesTextBox.Dock = DockStyle.Fill;
            notesTextBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            notesTextBox.Location = new Point(123, 293);
            notesTextBox.Multiline = true;
            notesTextBox.Name = "notesTextBox";
            notesTextBox.ScrollBars = ScrollBars.Vertical;
            notesTextBox.Size = new Size(338, 84);
            notesTextBox.TabIndex = 15;
            // 
            // buttonPanel
            // 
            mainTableLayout.SetColumnSpan(buttonPanel, 2);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Location = new Point(3, 383);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(458, 44);
            buttonPanel.TabIndex = 16;
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
            // PacketConfigDialog
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(484, 450);
            Controls.Add(mainTableLayout);
            Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PacketConfigDialog";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "添加發包配置";
            Load += PacketConfigDialog_Load;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)periodNumeric).EndInit();
            intervalPanel.ResumeLayout(false);
            intervalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)intervalNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxRetriesNumeric).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox packetNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown periodNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox targetProcessTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox packetDataTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel intervalPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown intervalNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown maxRetriesNumeric;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox enabledCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}