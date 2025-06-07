namespace BlueCgProcessMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainTableLayout = new TableLayoutPanel();
            topTableLayout = new TableLayoutPanel();
            processGroupBox = new GroupBox();
            processListView = new ListView();
            processNameColumn = new ColumnHeader();
            memoryColumn = new ColumnHeader();
            cpuColumn = new ColumnHeader();
            statusColumn = new ColumnHeader();
            startTimeColumn = new ColumnHeader();
            restartCountColumn = new ColumnHeader();
            rightPanel = new Panel();
            pathConfigGroupBox = new GroupBox();
            pathConfigTableLayout = new TableLayoutPanel();
            pathButtonsFlow = new FlowLayoutPanel();
            addPathBtn = new Button();
            removePathBtn = new Button();
            editPathBtn = new Button();
            importBtn = new Button();
            exportBtn = new Button();
            pathListView = new ListView();
            indexColumn = new ColumnHeader();
            pathNameColumn = new ColumnHeader();
            periodColumn = new ColumnHeader();
            orderColumn = new ColumnHeader();
            pathStatusColumn = new ColumnHeader();
            middleOperationPanel = new Panel();
            middleOperationFlow = new FlowLayoutPanel();
            manualStartBtn = new Button();
            manualRestartBtn = new Button();
            executePathBtn = new Button();
            controlGroupBox = new GroupBox();
            controlTableLayout = new TableLayoutPanel();
            statusPanel = new Panel();
            statusLabel = new Label();
            buttonPanel1 = new Panel();
            startMonitorBtn = new Button();
            stopMonitorBtn = new Button();
            restartAllBtn = new Button();
            settingsPanel = new Panel();
            settingsTableLayout = new TableLayoutPanel();
            label1 = new Label();
            noResponseTextBox = new TextBox();
            label2 = new Label();
            applyNoResponseBtn = new Button();
            label3 = new Label();
            childRestartDelayTextBox = new TextBox();
            label4 = new Label();
            applyChildDelayBtn = new Button();
            label5 = new Label();
            monitorIntervalTextBox = new TextBox();
            label6 = new Label();
            applyIntervalBtn = new Button();
            buttonPanel2 = new Panel();
            addProcessBtn = new Button();
            removeProcessBtn = new Button();
            editProcessBtn = new Button();
            globalOpsPanel = new Panel();
            globalOpsTableLayout = new TableLayoutPanel();
            globalOpsLabel = new Label();
            globalButtonsFlow = new FlowLayoutPanel();
            clearLogBtn = new Button();
            exportLogBtn = new Button();
            reloadBtn = new Button();
            logGroupBox = new GroupBox();
            logListView = new ListView();
            logTimeColumn = new ColumnHeader();
            logLevelColumn = new ColumnHeader();
            logMessageColumn = new ColumnHeader();
            bottomPanel = new Panel();
            bottomFlow = new FlowLayoutPanel();
            autoStartCheckBox = new CheckBox();
            clearLogBottomBtn = new Button();
            exportLogBottomBtn = new Button();
            showOnlyCheckBox = new CheckBox();
            logFilterComboBox = new ComboBox();
            monitorTimer = new System.Windows.Forms.Timer(components);
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            顯示主視窗ToolStripMenuItem = new ToolStripMenuItem();
            開始監控ToolStripMenuItem = new ToolStripMenuItem();
            停止監控ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            結束程式ToolStripMenuItem = new ToolStripMenuItem();
            mainTableLayout.SuspendLayout();
            topTableLayout.SuspendLayout();
            processGroupBox.SuspendLayout();
            rightPanel.SuspendLayout();
            pathConfigGroupBox.SuspendLayout();
            pathConfigTableLayout.SuspendLayout();
            pathButtonsFlow.SuspendLayout();
            middleOperationPanel.SuspendLayout();
            middleOperationFlow.SuspendLayout();
            controlGroupBox.SuspendLayout();
            controlTableLayout.SuspendLayout();
            statusPanel.SuspendLayout();
            buttonPanel1.SuspendLayout();
            settingsPanel.SuspendLayout();
            settingsTableLayout.SuspendLayout();
            buttonPanel2.SuspendLayout();
            globalOpsPanel.SuspendLayout();
            globalOpsTableLayout.SuspendLayout();
            globalButtonsFlow.SuspendLayout();
            logGroupBox.SuspendLayout();
            bottomPanel.SuspendLayout();
            bottomFlow.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.Controls.Add(topTableLayout, 0, 0);
            mainTableLayout.Controls.Add(logGroupBox, 0, 1);
            mainTableLayout.Controls.Add(bottomPanel, 0, 2);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 3;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainTableLayout.Size = new Size(1400, 800);
            mainTableLayout.TabIndex = 0;
            // 
            // topTableLayout
            // 
            topTableLayout.ColumnCount = 2;
            topTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            topTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            topTableLayout.Controls.Add(processGroupBox, 0, 0);
            topTableLayout.Controls.Add(rightPanel, 1, 0);
            topTableLayout.Dock = DockStyle.Fill;
            topTableLayout.Location = new Point(3, 3);
            topTableLayout.Name = "topTableLayout";
            topTableLayout.RowCount = 1;
            topTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topTableLayout.Size = new Size(1394, 517);
            topTableLayout.TabIndex = 0;
            // 
            // processGroupBox
            // 
            processGroupBox.Controls.Add(processListView);
            processGroupBox.Dock = DockStyle.Fill;
            processGroupBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            processGroupBox.Location = new Point(3, 3);
            processGroupBox.Name = "processGroupBox";
            processGroupBox.Padding = new Padding(8);
            processGroupBox.Size = new Size(830, 511);
            processGroupBox.TabIndex = 0;
            processGroupBox.TabStop = false;
            processGroupBox.Text = "進程監控列表";
            // 
            // processListView
            // 
            processListView.Columns.AddRange(new ColumnHeader[] { processNameColumn, memoryColumn, cpuColumn, statusColumn, startTimeColumn, restartCountColumn });
            processListView.Dock = DockStyle.Fill;
            processListView.FullRowSelect = true;
            processListView.GridLines = true;
            processListView.Location = new Point(8, 24);
            processListView.MultiSelect = false;
            processListView.Name = "processListView";
            processListView.Size = new Size(814, 479);
            processListView.TabIndex = 0;
            processListView.UseCompatibleStateImageBehavior = false;
            processListView.View = View.Details;
            // 
            // processNameColumn
            // 
            processNameColumn.Text = "進程名稱";
            processNameColumn.Width = 150;
            // 
            // memoryColumn
            // 
            memoryColumn.Text = "內存使用";
            memoryColumn.Width = 100;
            // 
            // cpuColumn
            // 
            cpuColumn.Text = "CPU";
            cpuColumn.Width = 80;
            // 
            // statusColumn
            // 
            statusColumn.Text = "狀態";
            statusColumn.Width = 100;
            // 
            // startTimeColumn
            // 
            startTimeColumn.Text = "啟動時間";
            startTimeColumn.Width = 150;
            // 
            // restartCountColumn
            // 
            restartCountColumn.Text = "重啟次數";
            restartCountColumn.Width = 100;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(pathConfigGroupBox);
            rightPanel.Controls.Add(middleOperationPanel);
            rightPanel.Controls.Add(controlGroupBox);
            rightPanel.Controls.Add(globalOpsPanel);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(839, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(552, 511);
            rightPanel.TabIndex = 1;
            rightPanel.Paint += rightPanel_Paint;
            // 
            // pathConfigGroupBox
            // 
            pathConfigGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pathConfigGroupBox.Controls.Add(pathConfigTableLayout);
            pathConfigGroupBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            pathConfigGroupBox.Location = new Point(3, 3);
            pathConfigGroupBox.Name = "pathConfigGroupBox";
            pathConfigGroupBox.Padding = new Padding(8);
            pathConfigGroupBox.Size = new Size(546, 150);
            pathConfigGroupBox.TabIndex = 0;
            pathConfigGroupBox.TabStop = false;
            pathConfigGroupBox.Text = "路徑配置管理";
            // 
            // pathConfigTableLayout
            // 
            pathConfigTableLayout.ColumnCount = 1;
            pathConfigTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pathConfigTableLayout.Controls.Add(pathButtonsFlow, 0, 0);
            pathConfigTableLayout.Controls.Add(pathListView, 0, 1);
            pathConfigTableLayout.Dock = DockStyle.Fill;
            pathConfigTableLayout.Location = new Point(8, 24);
            pathConfigTableLayout.Name = "pathConfigTableLayout";
            pathConfigTableLayout.RowCount = 2;
            pathConfigTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            pathConfigTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pathConfigTableLayout.Size = new Size(530, 118);
            pathConfigTableLayout.TabIndex = 0;
            // 
            // pathButtonsFlow
            // 
            pathButtonsFlow.Controls.Add(addPathBtn);
            pathButtonsFlow.Controls.Add(removePathBtn);
            pathButtonsFlow.Controls.Add(editPathBtn);
            pathButtonsFlow.Controls.Add(importBtn);
            pathButtonsFlow.Controls.Add(exportBtn);
            pathButtonsFlow.Dock = DockStyle.Fill;
            pathButtonsFlow.Location = new Point(3, 3);
            pathButtonsFlow.Name = "pathButtonsFlow";
            pathButtonsFlow.Size = new Size(524, 29);
            pathButtonsFlow.TabIndex = 0;
            // 
            // addPathBtn
            // 
            addPathBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            addPathBtn.Location = new Point(3, 3);
            addPathBtn.Name = "addPathBtn";
            addPathBtn.Size = new Size(65, 23);
            addPathBtn.TabIndex = 0;
            addPathBtn.Text = "添加路徑";
            addPathBtn.UseVisualStyleBackColor = true;
            // 
            // removePathBtn
            // 
            removePathBtn.Enabled = false;
            removePathBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            removePathBtn.Location = new Point(74, 3);
            removePathBtn.Name = "removePathBtn";
            removePathBtn.Size = new Size(50, 23);
            removePathBtn.TabIndex = 1;
            removePathBtn.Text = "刪除";
            removePathBtn.UseVisualStyleBackColor = true;
            // 
            // editPathBtn
            // 
            editPathBtn.Enabled = false;
            editPathBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            editPathBtn.Location = new Point(130, 3);
            editPathBtn.Name = "editPathBtn";
            editPathBtn.Size = new Size(50, 23);
            editPathBtn.TabIndex = 2;
            editPathBtn.Text = "編輯";
            editPathBtn.UseVisualStyleBackColor = true;
            // 
            // importBtn
            // 
            importBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            importBtn.Location = new Point(186, 3);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(50, 23);
            importBtn.TabIndex = 3;
            importBtn.Text = "導入";
            importBtn.UseVisualStyleBackColor = true;
            // 
            // exportBtn
            // 
            exportBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exportBtn.Location = new Point(242, 3);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(50, 23);
            exportBtn.TabIndex = 4;
            exportBtn.Text = "導出";
            exportBtn.UseVisualStyleBackColor = true;
            // 
            // pathListView
            // 
            pathListView.Columns.AddRange(new ColumnHeader[] { indexColumn, pathNameColumn, periodColumn, orderColumn, pathStatusColumn });
            pathListView.Dock = DockStyle.Fill;
            pathListView.FullRowSelect = true;
            pathListView.GridLines = true;
            pathListView.Location = new Point(3, 38);
            pathListView.Name = "pathListView";
            pathListView.Size = new Size(524, 77);
            pathListView.TabIndex = 1;
            pathListView.UseCompatibleStateImageBehavior = false;
            pathListView.View = View.Details;
            // 
            // indexColumn
            // 
            indexColumn.Text = "序號";
            indexColumn.Width = 50;
            // 
            // pathNameColumn
            // 
            pathNameColumn.Text = "路徑器號";
            pathNameColumn.Width = 150;
            // 
            // periodColumn
            // 
            periodColumn.Text = "期數";
            // 
            // orderColumn
            // 
            orderColumn.Text = "順序";
            // 
            // pathStatusColumn
            // 
            pathStatusColumn.Text = "狀態";
            pathStatusColumn.Width = 80;
            // 
            // middleOperationPanel
            // 
            middleOperationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            middleOperationPanel.Controls.Add(middleOperationFlow);
            middleOperationPanel.Location = new Point(3, 159);
            middleOperationPanel.Name = "middleOperationPanel";
            middleOperationPanel.Size = new Size(546, 35);
            middleOperationPanel.TabIndex = 1;
            // 
            // middleOperationFlow
            // 
            middleOperationFlow.Controls.Add(manualStartBtn);
            middleOperationFlow.Controls.Add(manualRestartBtn);
            middleOperationFlow.Controls.Add(executePathBtn);
            middleOperationFlow.Dock = DockStyle.Fill;
            middleOperationFlow.Location = new Point(0, 0);
            middleOperationFlow.Name = "middleOperationFlow";
            middleOperationFlow.Padding = new Padding(10, 5, 0, 0);
            middleOperationFlow.Size = new Size(546, 35);
            middleOperationFlow.TabIndex = 0;
            // 
            // manualStartBtn
            // 
            manualStartBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            manualStartBtn.Location = new Point(13, 8);
            manualStartBtn.Name = "manualStartBtn";
            manualStartBtn.Size = new Size(75, 23);
            manualStartBtn.TabIndex = 0;
            manualStartBtn.Text = "手動啟動";
            manualStartBtn.UseVisualStyleBackColor = true;
            // 
            // manualRestartBtn
            // 
            manualRestartBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            manualRestartBtn.Location = new Point(94, 8);
            manualRestartBtn.Name = "manualRestartBtn";
            manualRestartBtn.Size = new Size(75, 23);
            manualRestartBtn.TabIndex = 1;
            manualRestartBtn.Text = "手動重啟";
            manualRestartBtn.UseVisualStyleBackColor = true;
            // 
            // executePathBtn
            // 
            executePathBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            executePathBtn.Location = new Point(175, 8);
            executePathBtn.Name = "executePathBtn";
            executePathBtn.Size = new Size(75, 23);
            executePathBtn.TabIndex = 2;
            executePathBtn.Text = "執行路徑";
            executePathBtn.UseVisualStyleBackColor = true;
            // 
            // controlGroupBox
            // 
            controlGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            controlGroupBox.Controls.Add(controlTableLayout);
            controlGroupBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            controlGroupBox.Location = new Point(3, 200);
            controlGroupBox.Name = "controlGroupBox";
            controlGroupBox.Padding = new Padding(8);
            controlGroupBox.Size = new Size(546, 220);
            controlGroupBox.TabIndex = 2;
            controlGroupBox.TabStop = false;
            controlGroupBox.Text = "監控控制";
            // 
            // controlTableLayout
            // 
            controlTableLayout.ColumnCount = 2;
            controlTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controlTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controlTableLayout.Controls.Add(statusPanel, 0, 0);
            controlTableLayout.Controls.Add(buttonPanel1, 1, 0);
            controlTableLayout.Controls.Add(settingsPanel, 0, 1);
            controlTableLayout.Controls.Add(buttonPanel2, 1, 1);
            controlTableLayout.Dock = DockStyle.Fill;
            controlTableLayout.Location = new Point(8, 24);
            controlTableLayout.Name = "controlTableLayout";
            controlTableLayout.RowCount = 2;
            controlTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            controlTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            controlTableLayout.Size = new Size(530, 188);
            controlTableLayout.TabIndex = 0;
            // 
            // statusPanel
            // 
            statusPanel.Controls.Add(statusLabel);
            statusPanel.Dock = DockStyle.Fill;
            statusPanel.Location = new Point(3, 3);
            statusPanel.Name = "statusPanel";
            statusPanel.Size = new Size(259, 50);
            statusPanel.TabIndex = 0;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("微軟正黑體", 10F, FontStyle.Bold, GraphicsUnit.Point, 136);
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(10, 15);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(120, 18);
            statusLabel.TabIndex = 0;
            statusLabel.Text = "監控狀態：已停止";
            // 
            // buttonPanel1
            // 
            buttonPanel1.Controls.Add(startMonitorBtn);
            buttonPanel1.Controls.Add(stopMonitorBtn);
            buttonPanel1.Controls.Add(restartAllBtn);
            buttonPanel1.Dock = DockStyle.Fill;
            buttonPanel1.Location = new Point(268, 3);
            buttonPanel1.Name = "buttonPanel1";
            buttonPanel1.Size = new Size(259, 50);
            buttonPanel1.TabIndex = 1;
            // 
            // startMonitorBtn
            // 
            startMonitorBtn.BackColor = Color.LightGreen;
            startMonitorBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startMonitorBtn.Location = new Point(10, 8);
            startMonitorBtn.Name = "startMonitorBtn";
            startMonitorBtn.Size = new Size(75, 35);
            startMonitorBtn.TabIndex = 0;
            startMonitorBtn.Text = "開始監控";
            startMonitorBtn.UseVisualStyleBackColor = false;
            // 
            // stopMonitorBtn
            // 
            stopMonitorBtn.BackColor = Color.LightCoral;
            stopMonitorBtn.Enabled = false;
            stopMonitorBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            stopMonitorBtn.Location = new Point(91, 8);
            stopMonitorBtn.Name = "stopMonitorBtn";
            stopMonitorBtn.Size = new Size(75, 35);
            stopMonitorBtn.TabIndex = 1;
            stopMonitorBtn.Text = "停止監控";
            stopMonitorBtn.UseVisualStyleBackColor = false;
            // 
            // restartAllBtn
            // 
            restartAllBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            restartAllBtn.Location = new Point(172, 8);
            restartAllBtn.Name = "restartAllBtn";
            restartAllBtn.Size = new Size(75, 35);
            restartAllBtn.TabIndex = 2;
            restartAllBtn.Text = "重啟所有";
            restartAllBtn.UseVisualStyleBackColor = true;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(settingsTableLayout);
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(3, 59);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(259, 126);
            settingsPanel.TabIndex = 2;
            // 
            // settingsTableLayout
            // 
            settingsTableLayout.ColumnCount = 4;
            settingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            settingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            settingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            settingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            settingsTableLayout.Controls.Add(label1, 0, 0);
            settingsTableLayout.Controls.Add(noResponseTextBox, 1, 0);
            settingsTableLayout.Controls.Add(label2, 2, 0);
            settingsTableLayout.Controls.Add(applyNoResponseBtn, 3, 0);
            settingsTableLayout.Controls.Add(label3, 0, 1);
            settingsTableLayout.Controls.Add(childRestartDelayTextBox, 1, 1);
            settingsTableLayout.Controls.Add(label4, 2, 1);
            settingsTableLayout.Controls.Add(applyChildDelayBtn, 3, 1);
            settingsTableLayout.Controls.Add(label5, 0, 2);
            settingsTableLayout.Controls.Add(monitorIntervalTextBox, 1, 2);
            settingsTableLayout.Controls.Add(label6, 2, 2);
            settingsTableLayout.Controls.Add(applyIntervalBtn, 3, 2);
            settingsTableLayout.Dock = DockStyle.Fill;
            settingsTableLayout.Location = new Point(0, 0);
            settingsTableLayout.Name = "settingsTableLayout";
            settingsTableLayout.Padding = new Padding(10, 10, 0, 0);
            settingsTableLayout.RowCount = 3;
            settingsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            settingsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            settingsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            settingsTableLayout.Size = new Size(259, 126);
            settingsTableLayout.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(73, 38);
            label1.TabIndex = 0;
            label1.Text = "無回應時間:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // noResponseTextBox
            // 
            noResponseTextBox.Anchor = AnchorStyles.None;
            noResponseTextBox.Location = new Point(92, 17);
            noResponseTextBox.Name = "noResponseTextBox";
            noResponseTextBox.Size = new Size(44, 23);
            noResponseTextBox.TabIndex = 1;
            noResponseTextBox.Text = "20";
            noResponseTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(142, 10);
            label2.Name = "label2";
            label2.Size = new Size(53, 38);
            label2.TabIndex = 2;
            label2.Text = "秒";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applyNoResponseBtn
            // 
            applyNoResponseBtn.Anchor = AnchorStyles.None;
            applyNoResponseBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            applyNoResponseBtn.Location = new Point(207, 17);
            applyNoResponseBtn.Name = "applyNoResponseBtn";
            applyNoResponseBtn.Size = new Size(42, 23);
            applyNoResponseBtn.TabIndex = 3;
            applyNoResponseBtn.Text = "套用";
            applyNoResponseBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(13, 48);
            label3.Name = "label3";
            label3.Size = new Size(73, 38);
            label3.TabIndex = 4;
            label3.Text = "子進程等待:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // childRestartDelayTextBox
            // 
            childRestartDelayTextBox.Anchor = AnchorStyles.None;
            childRestartDelayTextBox.Location = new Point(92, 55);
            childRestartDelayTextBox.Name = "childRestartDelayTextBox";
            childRestartDelayTextBox.Size = new Size(44, 23);
            childRestartDelayTextBox.TabIndex = 5;
            childRestartDelayTextBox.Text = "120";
            childRestartDelayTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(142, 48);
            label4.Name = "label4";
            label4.Size = new Size(53, 38);
            label4.TabIndex = 6;
            label4.Text = "秒";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applyChildDelayBtn
            // 
            applyChildDelayBtn.Anchor = AnchorStyles.None;
            applyChildDelayBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            applyChildDelayBtn.Location = new Point(207, 55);
            applyChildDelayBtn.Name = "applyChildDelayBtn";
            applyChildDelayBtn.Size = new Size(42, 23);
            applyChildDelayBtn.TabIndex = 7;
            applyChildDelayBtn.Text = "套用";
            applyChildDelayBtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(13, 86);
            label5.Name = "label5";
            label5.Size = new Size(73, 40);
            label5.TabIndex = 8;
            label5.Text = "重啟間隔:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // monitorIntervalTextBox
            // 
            monitorIntervalTextBox.Anchor = AnchorStyles.None;
            monitorIntervalTextBox.Location = new Point(92, 94);
            monitorIntervalTextBox.Name = "monitorIntervalTextBox";
            monitorIntervalTextBox.Size = new Size(44, 23);
            monitorIntervalTextBox.TabIndex = 9;
            monitorIntervalTextBox.Text = "60";
            monitorIntervalTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(142, 86);
            label6.Name = "label6";
            label6.Size = new Size(53, 40);
            label6.TabIndex = 10;
            label6.Text = "秒";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // applyIntervalBtn
            // 
            applyIntervalBtn.Anchor = AnchorStyles.None;
            applyIntervalBtn.Font = new Font("微軟正黑體", 8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            applyIntervalBtn.Location = new Point(207, 94);
            applyIntervalBtn.Name = "applyIntervalBtn";
            applyIntervalBtn.Size = new Size(42, 23);
            applyIntervalBtn.TabIndex = 11;
            applyIntervalBtn.Text = "套用";
            applyIntervalBtn.UseVisualStyleBackColor = true;
            // 
            // buttonPanel2
            // 
            buttonPanel2.Controls.Add(addProcessBtn);
            buttonPanel2.Controls.Add(removeProcessBtn);
            buttonPanel2.Controls.Add(editProcessBtn);
            buttonPanel2.Dock = DockStyle.Fill;
            buttonPanel2.Location = new Point(268, 59);
            buttonPanel2.Name = "buttonPanel2";
            buttonPanel2.Size = new Size(259, 126);
            buttonPanel2.TabIndex = 3;
            // 
            // addProcessBtn
            // 
            addProcessBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            addProcessBtn.Location = new Point(10, 10);
            addProcessBtn.Name = "addProcessBtn";
            addProcessBtn.Size = new Size(75, 30);
            addProcessBtn.TabIndex = 0;
            addProcessBtn.Text = "添加進程";
            addProcessBtn.UseVisualStyleBackColor = true;
            // 
            // removeProcessBtn
            // 
            removeProcessBtn.Enabled = false;
            removeProcessBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            removeProcessBtn.Location = new Point(91, 10);
            removeProcessBtn.Name = "removeProcessBtn";
            removeProcessBtn.Size = new Size(75, 30);
            removeProcessBtn.TabIndex = 1;
            removeProcessBtn.Text = "刪除";
            removeProcessBtn.UseVisualStyleBackColor = true;
            // 
            // editProcessBtn
            // 
            editProcessBtn.Enabled = false;
            editProcessBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            editProcessBtn.Location = new Point(172, 10);
            editProcessBtn.Name = "editProcessBtn";
            editProcessBtn.Size = new Size(75, 30);
            editProcessBtn.TabIndex = 2;
            editProcessBtn.Text = "編輯";
            editProcessBtn.UseVisualStyleBackColor = true;
            // 
            // globalOpsPanel
            // 
            globalOpsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            globalOpsPanel.Controls.Add(globalOpsTableLayout);
            globalOpsPanel.Location = new Point(3, 426);
            globalOpsPanel.Name = "globalOpsPanel";
            globalOpsPanel.Size = new Size(546, 56);
            globalOpsPanel.TabIndex = 3;
            // 
            // globalOpsTableLayout
            // 
            globalOpsTableLayout.ColumnCount = 1;
            globalOpsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            globalOpsTableLayout.Controls.Add(globalOpsLabel, 0, 0);
            globalOpsTableLayout.Controls.Add(globalButtonsFlow, 0, 1);
            globalOpsTableLayout.Dock = DockStyle.Fill;
            globalOpsTableLayout.Location = new Point(0, 0);
            globalOpsTableLayout.Name = "globalOpsTableLayout";
            globalOpsTableLayout.RowCount = 2;
            globalOpsTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            globalOpsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            globalOpsTableLayout.Size = new Size(546, 56);
            globalOpsTableLayout.TabIndex = 0;
            // 
            // globalOpsLabel
            // 
            globalOpsLabel.AutoSize = true;
            globalOpsLabel.Dock = DockStyle.Fill;
            globalOpsLabel.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point, 136);
            globalOpsLabel.Location = new Point(3, 0);
            globalOpsLabel.Name = "globalOpsLabel";
            globalOpsLabel.Size = new Size(540, 20);
            globalOpsLabel.TabIndex = 0;
            globalOpsLabel.Text = "全局操作";
            globalOpsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // globalButtonsFlow
            // 
            globalButtonsFlow.Controls.Add(clearLogBtn);
            globalButtonsFlow.Controls.Add(exportLogBtn);
            globalButtonsFlow.Controls.Add(reloadBtn);
            globalButtonsFlow.Dock = DockStyle.Fill;
            globalButtonsFlow.Location = new Point(3, 23);
            globalButtonsFlow.Name = "globalButtonsFlow";
            globalButtonsFlow.Padding = new Padding(10, 2, 0, 0);
            globalButtonsFlow.Size = new Size(540, 30);
            globalButtonsFlow.TabIndex = 1;
            // 
            // clearLogBtn
            // 
            clearLogBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            clearLogBtn.Location = new Point(13, 5);
            clearLogBtn.Name = "clearLogBtn";
            clearLogBtn.Size = new Size(75, 23);
            clearLogBtn.TabIndex = 0;
            clearLogBtn.Text = "清除日誌";
            clearLogBtn.UseVisualStyleBackColor = true;
            // 
            // exportLogBtn
            // 
            exportLogBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exportLogBtn.Location = new Point(94, 5);
            exportLogBtn.Name = "exportLogBtn";
            exportLogBtn.Size = new Size(75, 23);
            exportLogBtn.TabIndex = 1;
            exportLogBtn.Text = "導出日誌";
            exportLogBtn.UseVisualStyleBackColor = true;
            // 
            // reloadBtn
            // 
            reloadBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            reloadBtn.Location = new Point(175, 5);
            reloadBtn.Name = "reloadBtn";
            reloadBtn.Size = new Size(75, 23);
            reloadBtn.TabIndex = 2;
            reloadBtn.Text = "重新載入";
            reloadBtn.UseVisualStyleBackColor = true;
            // 
            // logGroupBox
            // 
            logGroupBox.Controls.Add(logListView);
            logGroupBox.Dock = DockStyle.Fill;
            logGroupBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            logGroupBox.Location = new Point(3, 526);
            logGroupBox.Name = "logGroupBox";
            logGroupBox.Padding = new Padding(8);
            logGroupBox.Size = new Size(1394, 235);
            logGroupBox.TabIndex = 1;
            logGroupBox.TabStop = false;
            logGroupBox.Text = "監控日誌輸出";
            // 
            // logListView
            // 
            logListView.Columns.AddRange(new ColumnHeader[] { logTimeColumn, logLevelColumn, logMessageColumn });
            logListView.Dock = DockStyle.Fill;
            logListView.FullRowSelect = true;
            logListView.GridLines = true;
            logListView.Location = new Point(8, 24);
            logListView.Name = "logListView";
            logListView.Size = new Size(1378, 203);
            logListView.TabIndex = 0;
            logListView.UseCompatibleStateImageBehavior = false;
            logListView.View = View.Details;
            // 
            // logTimeColumn
            // 
            logTimeColumn.Text = "[16:48:26]";
            logTimeColumn.Width = 120;
            // 
            // logLevelColumn
            // 
            logLevelColumn.Text = "🔧";
            logLevelColumn.Width = 40;
            // 
            // logMessageColumn
            // 
            logMessageColumn.Text = "BlueCg 進程監控管理系統啟動成功";
            logMessageColumn.Width = 1000;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(bottomFlow);
            bottomPanel.Dock = DockStyle.Fill;
            bottomPanel.Location = new Point(3, 767);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1394, 30);
            bottomPanel.TabIndex = 2;
            // 
            // bottomFlow
            // 
            bottomFlow.Controls.Add(autoStartCheckBox);
            bottomFlow.Controls.Add(clearLogBottomBtn);
            bottomFlow.Controls.Add(exportLogBottomBtn);
            bottomFlow.Controls.Add(showOnlyCheckBox);
            bottomFlow.Controls.Add(logFilterComboBox);
            bottomFlow.Dock = DockStyle.Fill;
            bottomFlow.Location = new Point(0, 0);
            bottomFlow.Name = "bottomFlow";
            bottomFlow.Padding = new Padding(10, 8, 0, 0);
            bottomFlow.Size = new Size(1394, 30);
            bottomFlow.TabIndex = 0;
            // 
            // autoStartCheckBox
            // 
            autoStartCheckBox.AutoSize = true;
            autoStartCheckBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            autoStartCheckBox.Location = new Point(13, 11);
            autoStartCheckBox.Name = "autoStartCheckBox";
            autoStartCheckBox.Size = new Size(74, 20);
            autoStartCheckBox.TabIndex = 0;
            autoStartCheckBox.Text = "自動啟動";
            autoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearLogBottomBtn
            // 
            clearLogBottomBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            clearLogBottomBtn.Location = new Point(93, 11);
            clearLogBottomBtn.Name = "clearLogBottomBtn";
            clearLogBottomBtn.Size = new Size(75, 25);
            clearLogBottomBtn.TabIndex = 1;
            clearLogBottomBtn.Text = "清除日誌";
            clearLogBottomBtn.UseVisualStyleBackColor = true;
            // 
            // exportLogBottomBtn
            // 
            exportLogBottomBtn.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exportLogBottomBtn.Location = new Point(174, 11);
            exportLogBottomBtn.Name = "exportLogBottomBtn";
            exportLogBottomBtn.Size = new Size(75, 25);
            exportLogBottomBtn.TabIndex = 2;
            exportLogBottomBtn.Text = "導出日誌";
            exportLogBottomBtn.UseVisualStyleBackColor = true;
            // 
            // showOnlyCheckBox
            // 
            showOnlyCheckBox.AutoSize = true;
            showOnlyCheckBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            showOnlyCheckBox.Location = new Point(255, 11);
            showOnlyCheckBox.Name = "showOnlyCheckBox";
            showOnlyCheckBox.Size = new Size(77, 20);
            showOnlyCheckBox.TabIndex = 3;
            showOnlyCheckBox.Text = "日誌篩選:";
            showOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // logFilterComboBox
            // 
            logFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            logFilterComboBox.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            logFilterComboBox.FormattingEnabled = true;
            logFilterComboBox.Items.AddRange(new object[] { "全部", "信息", "警告", "錯誤", "調試" });
            logFilterComboBox.Location = new Point(338, 11);
            logFilterComboBox.Name = "logFilterComboBox";
            logFilterComboBox.Size = new Size(100, 24);
            logFilterComboBox.TabIndex = 4;
            // 
            // monitorTimer
            // 
            monitorTimer.Interval = 1000;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Text = "BlueCg 進程監控";
            notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { 顯示主視窗ToolStripMenuItem, 開始監控ToolStripMenuItem, 停止監控ToolStripMenuItem, toolStripSeparator1, 結束程式ToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(135, 98);
            // 
            // 顯示主視窗ToolStripMenuItem
            // 
            顯示主視窗ToolStripMenuItem.Name = "顯示主視窗ToolStripMenuItem";
            顯示主視窗ToolStripMenuItem.Size = new Size(134, 22);
            顯示主視窗ToolStripMenuItem.Text = "顯示主視窗";
            // 
            // 開始監控ToolStripMenuItem
            // 
            開始監控ToolStripMenuItem.Name = "開始監控ToolStripMenuItem";
            開始監控ToolStripMenuItem.Size = new Size(134, 22);
            開始監控ToolStripMenuItem.Text = "開始監控";
            // 
            // 停止監控ToolStripMenuItem
            // 
            停止監控ToolStripMenuItem.Enabled = false;
            停止監控ToolStripMenuItem.Name = "停止監控ToolStripMenuItem";
            停止監控ToolStripMenuItem.Size = new Size(134, 22);
            停止監控ToolStripMenuItem.Text = "停止監控";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(131, 6);
            // 
            // 結束程式ToolStripMenuItem
            // 
            結束程式ToolStripMenuItem.Name = "結束程式ToolStripMenuItem";
            結束程式ToolStripMenuItem.Size = new Size(134, 22);
            結束程式ToolStripMenuItem.Text = "結束程式";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 800);
            Controls.Add(mainTableLayout);
            Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, 136);
            MinimumSize = new Size(1200, 700);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BlueCg 進程監控管理系統";
            Load += MainForm_Load_1;
            mainTableLayout.ResumeLayout(false);
            topTableLayout.ResumeLayout(false);
            processGroupBox.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            pathConfigGroupBox.ResumeLayout(false);
            pathConfigTableLayout.ResumeLayout(false);
            pathButtonsFlow.ResumeLayout(false);
            middleOperationPanel.ResumeLayout(false);
            middleOperationFlow.ResumeLayout(false);
            controlGroupBox.ResumeLayout(false);
            controlTableLayout.ResumeLayout(false);
            statusPanel.ResumeLayout(false);
            statusPanel.PerformLayout();
            buttonPanel1.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            settingsTableLayout.ResumeLayout(false);
            settingsTableLayout.PerformLayout();
            buttonPanel2.ResumeLayout(false);
            globalOpsPanel.ResumeLayout(false);
            globalOpsTableLayout.ResumeLayout(false);
            globalOpsTableLayout.PerformLayout();
            globalButtonsFlow.ResumeLayout(false);
            logGroupBox.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            bottomFlow.ResumeLayout(false);
            bottomFlow.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);

        }
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.TableLayoutPanel topTableLayout;
        private System.Windows.Forms.GroupBox processGroupBox;
        private System.Windows.Forms.ListView processListView;
        private System.Windows.Forms.ColumnHeader processNameColumn;
        private System.Windows.Forms.ColumnHeader memoryColumn;
        private System.Windows.Forms.ColumnHeader cpuColumn;
        private System.Windows.Forms.ColumnHeader statusColumn;
        private System.Windows.Forms.ColumnHeader startTimeColumn;
        private System.Windows.Forms.ColumnHeader restartCountColumn;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.GroupBox pathConfigGroupBox;
        private System.Windows.Forms.TableLayoutPanel pathConfigTableLayout;
        private System.Windows.Forms.FlowLayoutPanel pathButtonsFlow;
        private System.Windows.Forms.Button addPathBtn;
        private System.Windows.Forms.Button removePathBtn;
        private System.Windows.Forms.Button editPathBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.ListView pathListView;
        private System.Windows.Forms.ColumnHeader indexColumn;
        private System.Windows.Forms.ColumnHeader pathNameColumn;
        private System.Windows.Forms.ColumnHeader periodColumn;
        private System.Windows.Forms.ColumnHeader orderColumn;
        private System.Windows.Forms.ColumnHeader pathStatusColumn;
        private System.Windows.Forms.Panel middleOperationPanel;
        private System.Windows.Forms.FlowLayoutPanel middleOperationFlow;
        private System.Windows.Forms.Button manualStartBtn;
        private System.Windows.Forms.Button manualRestartBtn;
        private System.Windows.Forms.Button executePathBtn;
        private System.Windows.Forms.GroupBox controlGroupBox;
        private System.Windows.Forms.TableLayoutPanel controlTableLayout;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel buttonPanel1;
        private System.Windows.Forms.Button startMonitorBtn;
        private System.Windows.Forms.Button stopMonitorBtn;
        private System.Windows.Forms.Button restartAllBtn;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.TableLayoutPanel settingsTableLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noResponseTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button applyNoResponseBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox childRestartDelayTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button applyChildDelayBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox monitorIntervalTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button applyIntervalBtn;
        private System.Windows.Forms.Panel buttonPanel2;
        private System.Windows.Forms.Button addProcessBtn;
        private System.Windows.Forms.Button removeProcessBtn;
        private System.Windows.Forms.Button editProcessBtn;
        private System.Windows.Forms.Panel globalOpsPanel;
        private System.Windows.Forms.TableLayoutPanel globalOpsTableLayout;
        private System.Windows.Forms.Label globalOpsLabel;
        private System.Windows.Forms.FlowLayoutPanel globalButtonsFlow;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.Button exportLogBtn;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader logTimeColumn;
        private System.Windows.Forms.ColumnHeader logLevelColumn;
        private System.Windows.Forms.ColumnHeader logMessageColumn;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.FlowLayoutPanel bottomFlow;
        private System.Windows.Forms.CheckBox autoStartCheckBox;
        private System.Windows.Forms.Button clearLogBottomBtn;
        private System.Windows.Forms.Button exportLogBottomBtn;
        private System.Windows.Forms.CheckBox showOnlyCheckBox;
        private System.Windows.Forms.ComboBox logFilterComboBox;
        private System.Windows.Forms.Timer monitorTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 顯示主視窗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開始監控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止監控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 結束程式ToolStripMenuItem;
        #endregion
    }
}// <auto-generated>    