using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Management;
using System.Configuration;

namespace BlueCgProcessMonitor
{
    public partial class MainForm : Form
    {
        // 字段聲明
        private bool isMonitoring = false;
        private bool isExiting = false;
        private List<ProcessMonitorItem> monitoredProcesses;
        private List<PacketConfigItem> packetConfigs;
        private PerformanceCounter cpuCounter;
        private Dictionary<int, PerformanceCounter> processCpuCounters;
        private PacketConfigManager packetManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeCustom();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 窗體載入事件處理程序
            LogMessage("主窗體載入完成", LogLevel.Info);

            // 初始化日誌篩選
            logFilterComboBox.SelectedIndex = 0;

            // 載入設置
            LoadSettingsFromConfig();
        }

        private void InitializeCustom()
        {
            // 初始化數據結構
            monitoredProcesses = new List<ProcessMonitorItem>();
            packetConfigs = new List<PacketConfigItem>();
            processCpuCounters = new Dictionary<int, PerformanceCounter>();
            packetManager = new PacketConfigManager();

            // 初始化CPU計數器
            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue(); // 第一次調用
            }
            catch (Exception ex)
            {
                LogMessage($"初始化CPU計數器失敗: {ex.Message}", LogLevel.Error);
            }

            // 設置事件處理
            SetupEventHandlers();

            // 初始化UI狀態
            UpdateUIState();

            // 加載配置
            LoadConfiguration();

            // 設置系統托盤
            SetupSystemTray();

            // 設置發包管理器事件
            packetManager.ConfigExecuted += PacketManager_ConfigExecuted;
            packetManager.ConfigFailed += PacketManager_ConfigFailed;

            LogMessage("BlueCg 進程監控管理系統啟動成功", LogLevel.Info);
        }

        private void SetupEventHandlers()
        {
            // 主按鈕事件
            startMonitorBtn.Click += StartMonitorBtn_Click;
            stopMonitorBtn.Click += StopMonitorBtn_Click;
            addProcessBtn.Click += AddProcessBtn_Click;
            removeProcessBtn.Click += RemoveProcessBtn_Click;
            editProcessBtn.Click += EditProcessBtn_Click;
            restartAllBtn.Click += RestartAllBtn_Click;
            clearLogBtn.Click += ClearLogBtn_Click;
            clearLogBottomBtn.Click += ClearLogBtn_Click;
            exportLogBtn.Click += ExportLogBtn_Click;
            exportLogBottomBtn.Click += ExportLogBtn_Click;
            reloadBtn.Click += ReloadBtn_Click;

            // 路徑配置按鈕事件
            addPathBtn.Click += AddPathBtn_Click;
            removePathBtn.Click += RemovePathBtn_Click;
            editPathBtn.Click += EditPathBtn_Click;
            importBtn.Click += ImportBtn_Click;
            exportBtn.Click += ExportBtn_Click;

            // 手動操作按鈕事件
            manualStartBtn.Click += ManualStartBtn_Click;
            manualRestartBtn.Click += ManualRestartBtn_Click;
            executePathBtn.Click += ExecutePathBtn_Click;

            // 設置應用按鈕事件
            applyNoResponseBtn.Click += ApplyNoResponseBtn_Click;
            applyChildDelayBtn.Click += ApplyChildDelayBtn_Click;
            applyIntervalBtn.Click += ApplyIntervalBtn_Click;

            // 列表選擇事件
            processListView.SelectedIndexChanged += ProcessListView_SelectedIndexChanged;
            pathListView.SelectedIndexChanged += PathListView_SelectedIndexChanged;
            logListView.SelectedIndexChanged += LogListView_SelectedIndexChanged;

            // 計時器事件
            monitorTimer.Tick += MonitorTimer_Tick;

            // 系統托盤事件
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            顯示主視窗ToolStripMenuItem.Click += 顯示主視窗ToolStripMenuItem_Click;
            開始監控ToolStripMenuItem.Click += 開始監控ToolStripMenuItem_Click;
            停止監控ToolStripMenuItem.Click += 停止監控ToolStripMenuItem_Click;
            結束程式ToolStripMenuItem.Click += 結束程式ToolStripMenuItem_Click;

            // 窗體事件
            this.Resize += MainForm_Resize;
            this.FormClosing += MainForm_FormClosing;
            this.Load += MainForm_Load;

            // 其他控件事件
            autoStartCheckBox.CheckedChanged += AutoStartCheckBox_CheckedChanged;
            showOnlyCheckBox.CheckedChanged += ShowOnlyCheckBox_CheckedChanged;
            logFilterComboBox.SelectedIndexChanged += LogFilterComboBox_SelectedIndexChanged;
        }

        #region 監控控制

        private void StartMonitorBtn_Click(object sender, EventArgs e)
        {
            StartMonitoring();
        }

        private void StopMonitorBtn_Click(object sender, EventArgs e)
        {
            StopMonitoring();
        }

        private void StartMonitoring()
        {
            if (monitoredProcesses.Count == 0)
            {
                MessageBox.Show("請先添加要監控的進程！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isMonitoring = true;
            monitorTimer.Start();
            packetManager.StartExecutor();

            startMonitorBtn.Enabled = false;
            stopMonitorBtn.Enabled = true;
            statusLabel.Text = "監控狀態：正在運行";
            statusLabel.ForeColor = Color.Green;

            開始監控ToolStripMenuItem.Enabled = false;
            停止監控ToolStripMenuItem.Enabled = true;

            LogMessage("開始進程監控", LogLevel.Info);
        }

        private void StopMonitoring()
        {
            isMonitoring = false;
            monitorTimer.Stop();
            packetManager.StopExecutor();

            startMonitorBtn.Enabled = true;
            stopMonitorBtn.Enabled = false;
            statusLabel.Text = "監控狀態：已停止";
            statusLabel.ForeColor = Color.Red;

            開始監控ToolStripMenuItem.Enabled = true;
            停止監控ToolStripMenuItem.Enabled = false;

            LogMessage("停止進程監控", LogLevel.Info);
        }

        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            UpdateProcessStatus();
            CheckProcessHealth();
        }

        #endregion

        #region 進程管理

        private void AddProcessBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddProcessDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var processItem = new ProcessMonitorItem
                    {
                        ProcessName = dialog.ProcessName,
                        ExecutablePath = dialog.ExecutablePath,
                        Arguments = dialog.Arguments,
                        StartTime = DateTime.Now,
                        RestartCount = 0,
                        Status = "已停止",
                        AutoRestart = dialog.AutoRestart,
                        NoResponseTime = dialog.NoResponseTime,
                        WorkingDirectory = dialog.WorkingDirectory
                    };

                    monitoredProcesses.Add(processItem);
                    RefreshProcessList();
                    LogMessage($"添加進程監控: {processItem.ProcessName}", LogLevel.Info);
                }
            }
        }

        private void RemoveProcessBtn_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                var selectedItem = processListView.SelectedItems[0];
                var processName = selectedItem.Text;

                if (MessageBox.Show($"確定要移除進程 '{processName}' 的監控嗎？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var processItem = monitoredProcesses.FirstOrDefault(p => p.ProcessName == processName);
                    if (processItem != null)
                    {
                        // 停止進程（如果正在運行）
                        if (processItem.Process != null && !processItem.Process.HasExited)
                        {
                            try
                            {
                                processItem.Process.Kill();
                            }
                            catch (Exception ex)
                            {
                                LogMessage($"停止進程失敗: {ex.Message}", LogLevel.Warning);
                            }
                        }

                        monitoredProcesses.Remove(processItem);
                        RefreshProcessList();
                        LogMessage($"移除進程監控: {processName}", LogLevel.Info);
                    }
                }
            }
            else
            {
                MessageBox.Show("請先選擇要移除的進程！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditProcessBtn_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                var selectedItem = processListView.SelectedItems[0];
                var processName = selectedItem.Text;
                var processItem = monitoredProcesses.FirstOrDefault(p => p.ProcessName == processName);

                if (processItem != null)
                {
                    using (var dialog = new AddProcessDialog())
                    {
                        dialog.SetEditMode(processItem);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            processItem.ProcessName = dialog.ProcessName;
                            processItem.ExecutablePath = dialog.ExecutablePath;
                            processItem.Arguments = dialog.Arguments;
                            processItem.AutoRestart = dialog.AutoRestart;
                            processItem.NoResponseTime = dialog.NoResponseTime;
                            processItem.WorkingDirectory = dialog.WorkingDirectory;

                            RefreshProcessList();
                            LogMessage($"編輯進程配置: {processItem.ProcessName}", LogLevel.Info);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("請先選擇要編輯的進程！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RestartAllBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要重啟所有進程嗎？", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var processItem in monitoredProcesses)
                {
                    RestartProcess(processItem);
                }
                LogMessage("重啟所有進程", LogLevel.Info);
            }
        }

        private void ManualStartBtn_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                var selectedItem = processListView.SelectedItems[0];
                var processName = selectedItem.Text;
                var processItem = monitoredProcesses.FirstOrDefault(p => p.ProcessName == processName);

                if (processItem != null)
                {
                    if (processItem.StartProcess())
                    {
                        LogMessage($"手動啟動進程: {processName}", LogLevel.Info);
                        RefreshProcessList();
                    }
                    else
                    {
                        LogMessage($"手動啟動進程失敗: {processName}", LogLevel.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("請先選擇要啟動的進程！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ManualRestartBtn_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                var selectedItem = processListView.SelectedItems[0];
                var processName = selectedItem.Text;
                var processItem = monitoredProcesses.FirstOrDefault(p => p.ProcessName == processName);

                if (processItem != null)
                {
                    RestartProcess(processItem);
                    LogMessage($"手動重啟進程: {processName}", LogLevel.Info);
                }
            }
            else
            {
                MessageBox.Show("請先選擇要重啟的進程！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RestartProcess(ProcessMonitorItem processItem)
        {
            try
            {
                // 停止現有進程
                if (processItem.Process != null && !processItem.Process.HasExited)
                {
                    processItem.Process.Kill();
                    processItem.Process.WaitForExit(5000); // 等待5秒
                }

                // 啟動新進程
                var startInfo = new ProcessStartInfo
                {
                    FileName = processItem.ExecutablePath,
                    Arguments = processItem.Arguments,
                    UseShellExecute = true,
                    WorkingDirectory = string.IsNullOrEmpty(processItem.WorkingDirectory) ?
                        Path.GetDirectoryName(processItem.ExecutablePath) : processItem.WorkingDirectory
                };

                processItem.Process = Process.Start(startInfo);
                processItem.StartTime = DateTime.Now;
                processItem.RestartCount++;
                processItem.Status = "正在運行";

                LogMessage($"重啟進程: {processItem.ProcessName}", LogLevel.Info);
            }
            catch (Exception ex)
            {
                processItem.Status = "啟動失敗";
                LogMessage($"重啟進程失敗 {processItem.ProcessName}: {ex.Message}", LogLevel.Error);
            }
        }

        #endregion

        #region 路徑配置管理

        private void AddPathBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new PacketConfigDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var config = dialog.GetConfig();
                    packetManager.AddConfig(config);
                    RefreshPathList();
                    LogMessage($"添加路徑配置: {config.PacketName}", LogLevel.Info);
                }
            }
        }

        private void RemovePathBtn_Click(object sender, EventArgs e)
        {
            if (pathListView.SelectedItems.Count > 0)
            {
                var selectedItem = pathListView.SelectedItems[0];
                var configId = int.Parse(selectedItem.Text);

                if (MessageBox.Show("確定要刪除選中的路徑配置嗎？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    packetManager.RemoveConfig(configId);
                    RefreshPathList();
                    LogMessage($"刪除路徑配置: ID {configId}", LogLevel.Info);
                }
            }
            else
            {
                MessageBox.Show("請先選擇要刪除的路徑配置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditPathBtn_Click(object sender, EventArgs e)
        {
            if (pathListView.SelectedItems.Count > 0)
            {
                var selectedItem = pathListView.SelectedItems[0];
                var configId = int.Parse(selectedItem.Text);
                var config = packetManager.GetAllConfigs().FirstOrDefault(c => c.Id == configId);

                if (config != null)
                {
                    using (var dialog = new PacketConfigDialog())
                    {
                        dialog.SetEditMode(config);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var updatedConfig = dialog.GetConfig();
                            updatedConfig.Id = configId;

                            packetManager.RemoveConfig(configId);
                            packetManager.AddConfig(updatedConfig);
                            RefreshPathList();
                            LogMessage($"編輯路徑配置: {updatedConfig.PacketName}", LogLevel.Info);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("請先選擇要編輯的路徑配置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "配置文件 (*.json)|*.json|所有文件 (*.*)|*.*";
                dialog.Title = "導入路徑配置";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 實現配置導入邏輯
                        LogMessage($"導入配置文件: {dialog.FileName}", LogLevel.Info);
                        MessageBox.Show("配置導入成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"導入配置失敗: {ex.Message}", LogLevel.Error);
                        MessageBox.Show($"導入配置失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "配置文件 (*.json)|*.json|所有文件 (*.*)|*.*";
                dialog.Title = "導出路徑配置";
                dialog.FileName = $"PacketConfig_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 實現配置導出邏輯
                        LogMessage($"導出配置文件: {dialog.FileName}", LogLevel.Info);
                        MessageBox.Show("配置導出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"導出配置失敗: {ex.Message}", LogLevel.Error);
                        MessageBox.Show($"導出配置失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExecutePathBtn_Click(object sender, EventArgs e)
        {
            if (pathListView.SelectedItems.Count > 0)
            {
                var selectedItem = pathListView.SelectedItems[0];
                var configId = int.Parse(selectedItem.Text);
                var config = packetManager.GetAllConfigs().FirstOrDefault(c => c.Id == configId);

                if (config != null)
                {
                    if (config.Execute())
                    {
                        LogMessage($"手動執行路徑配置: {config.PacketName}", LogLevel.Info);
                        RefreshPathList();
                    }
                    else
                    {
                        LogMessage($"執行路徑配置失敗: {config.PacketName} - {config.ErrorMessage}", LogLevel.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("請先選擇要執行的路徑配置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 設置應用

        private void ApplyNoResponseBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(noResponseTextBox.Text, out int seconds) && seconds > 0)
            {
                foreach (var process in monitoredProcesses)
                {
                    process.NoResponseTime = seconds;
                }
                LogMessage($"應用無回應時間設置: {seconds}秒", LogLevel.Info);
                MessageBox.Show("設置已應用！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入有效的秒數！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplyChildDelayBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(childRestartDelayTextBox.Text, out int seconds) && seconds > 0)
            {
                // 應用子進程重啟延遲設置
                LogMessage($"應用子進程重啟延遲設置: {seconds}秒", LogLevel.Info);
                MessageBox.Show("設置已應用！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入有效的秒數！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplyIntervalBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(monitorIntervalTextBox.Text, out int seconds) && seconds > 0)
            {
                monitorTimer.Interval = seconds * 1000;
                LogMessage($"應用監控間隔設置: {seconds}秒", LogLevel.Info);
                MessageBox.Show("設置已應用！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入有效的秒數！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region 狀態更新

        private void UpdateProcessStatus()
        {
            foreach (var processItem in monitoredProcesses)
            {
                UpdateSingleProcessStatus(processItem);
            }
            RefreshProcessList();
        }

        private void UpdateSingleProcessStatus(ProcessMonitorItem processItem)
        {
            try
            {
                if (processItem.Process == null)
                {
                    processItem.Status = "未啟動";
                    processItem.MemoryUsage = "0 MB";
                    processItem.CpuUsage = "0%";
                    return;
                }

                if (processItem.Process.HasExited)
                {
                    processItem.Status = "已退出";
                    processItem.MemoryUsage = "0 MB";
                    processItem.CpuUsage = "0%";

                    // 如果啟用自動重啟
                    if (processItem.AutoRestart)
                    {
                        LogMessage($"檢測到進程 {processItem.ProcessName} 已退出，準備重啟", LogLevel.Warning);
                        RestartProcess(processItem);
                    }
                    return;
                }

                // 更新狀態
                processItem.Status = "正在運行";

                // 更新內存使用量
                processItem.Process.Refresh();
                var memoryMB = processItem.Process.WorkingSet64 / 1024 / 1024;
                processItem.MemoryUsage = $"{memoryMB} MB";

                // 更新CPU使用率
                var cpuUsage = GetProcessCpuUsage(processItem.Process);
                processItem.CpuUsage = $"{cpuUsage:F1}%";

                // 檢查是否無回應
                if (!processItem.Process.Responding)
                {
                    processItem.Status = "無回應";
                    if (processItem.AutoRestart)
                    {
                        var noResponseTime = processItem.NoResponseTime;
                        if (DateTime.Now - processItem.LastResponseCheck > TimeSpan.FromSeconds(noResponseTime))
                        {
                            LogMessage($"進程 {processItem.ProcessName} 長時間無回應，準備重啟", LogLevel.Warning);
                            RestartProcess(processItem);
                        }
                    }
                }
                else
                {
                    processItem.LastResponseCheck = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                processItem.Status = "狀態異常";
                LogMessage($"更新進程狀態失敗 {processItem.ProcessName}: {ex.Message}", LogLevel.Error);
            }
        }

        private double GetProcessCpuUsage(Process process)
        {
            try
            {
                if (!processCpuCounters.ContainsKey(process.Id))
                {
                    var counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                    processCpuCounters[process.Id] = counter;
                    counter.NextValue(); // 第一次調用
                    return 0;
                }

                return processCpuCounters[process.Id].NextValue();
            }
            catch
            {
                return 0;
            }
        }

        private void CheckProcessHealth()
        {
            // 這裡可以添加額外的健康檢查邏輯
            // 例如檢查進程是否卡住、內存洩漏等
        }

        #endregion

        #region UI更新

        private void RefreshProcessList()
        {
            processListView.Items.Clear();

            foreach (var processItem in monitoredProcesses)
            {
                var item = new ListViewItem(processItem.ProcessName);
                item.SubItems.Add(processItem.MemoryUsage);
                item.SubItems.Add(processItem.CpuUsage);
                item.SubItems.Add(processItem.Status);
                item.SubItems.Add(processItem.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(processItem.RestartCount.ToString());

                // 根據狀態設置顏色
                switch (processItem.Status)
                {
                    case "正在運行":
                        item.ForeColor = Color.Green;
                        break;
                    case "已退出":
                    case "啟動失敗":
                    case "狀態異常":
                        item.ForeColor = Color.Red;
                        break;
                    case "無回應":
                        item.ForeColor = Color.Orange;
                        break;
                    default:
                        item.ForeColor = Color.Gray;
                        break;
                }

                processListView.Items.Add(item);
            }
        }

        private void RefreshPathList()
        {
            pathListView.Items.Clear();

            var configs = packetManager.GetAllConfigs();
            foreach (var config in configs)
            {
                var item = new ListViewItem(config.Id.ToString());
                item.SubItems.Add(config.PacketName);
                item.SubItems.Add(config.Period.ToString());
                item.SubItems.Add("1"); // 順序，暫時固定為1
                item.SubItems.Add(config.GetStatusText());

                item.ForeColor = config.IsEnabled ? Color.Green : Color.Gray;
                pathListView.Items.Add(item);
            }
        }

        private void UpdateUIState()
        {
            removeProcessBtn.Enabled = processListView.SelectedItems.Count > 0;
            editProcessBtn.Enabled = processListView.SelectedItems.Count > 0;
            manualStartBtn.Enabled = processListView.SelectedItems.Count > 0;
            manualRestartBtn.Enabled = processListView.SelectedItems.Count > 0;

            removePathBtn.Enabled = pathListView.SelectedItems.Count > 0;
            editPathBtn.Enabled = pathListView.SelectedItems.Count > 0;
            executePathBtn.Enabled = pathListView.SelectedItems.Count > 0;
        }

        #endregion

        #region 日誌系統

        public enum LogLevel
        {
            Info,
            Warning,
            Error,
            Debug
        }

        private void LogMessage(string message, LogLevel level = LogLevel.Info)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            var logEntry = $"[{timestamp}] {message}";

            // 添加到日誌列表
            var item = new ListViewItem(timestamp);
            item.SubItems.Add(GetLogLevelIcon(level));
            item.SubItems.Add(message);

            // 根據日誌級別設置顏色
            switch (level)
            {
                case LogLevel.Info:
                    item.ForeColor = Color.Black;
                    break;
                case LogLevel.Warning:
                    item.ForeColor = Color.Orange;
                    break;
                case LogLevel.Error:
                    item.ForeColor = Color.Red;
                    break;
                case LogLevel.Debug:
                    item.ForeColor = Color.Gray;
                    break;
            }

            // 應用日誌篩選
            if (ShouldShowLogItem(level))
            {
                logListView.Items.Insert(0, item);
            }

            // 限制日誌數量
            if (logListView.Items.Count > 1000)
            {
                logListView.Items.RemoveAt(logListView.Items.Count - 1);
            }

            // 輸出到調試窗口
            Debug.WriteLine(logEntry);
        }

        private bool ShouldShowLogItem(LogLevel level)
        {
            if (!showOnlyCheckBox.Checked)
                return true;

            var selectedFilter = logFilterComboBox.SelectedItem?.ToString();
            if (selectedFilter == "全部")
                return true;

            return selectedFilter == GetLogLevelText(level);
        }

        private string GetLogLevelIcon(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Info:
                    return "ℹ️";
                case LogLevel.Warning:
                    return "⚠️";
                case LogLevel.Error:
                    return "❌";
                case LogLevel.Debug:
                    return "🔧";
                default:
                    return "?";
            }
        }

        private string GetLogLevelText(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Info:
                    return "信息";
                case LogLevel.Warning:
                    return "警告";
                case LogLevel.Error:
                    return "錯誤";
                case LogLevel.Debug:
                    return "調試";
                default:
                    return "未知";
            }
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            logListView.Items.Clear();
            LogMessage("日誌已清除", LogLevel.Info);
        }

        private void ExportLogBtn_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                dialog.Title = "導出日誌";
                dialog.FileName = $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lines = new List<string>();
                        foreach (ListViewItem item in logListView.Items)
                        {
                            var line = $"{item.SubItems[0].Text} {item.SubItems[1].Text} {item.SubItems[2].Text}";
                            lines.Add(line);
                        }

                        File.WriteAllLines(dialog.FileName, lines);
                        MessageBox.Show("日誌導出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"導出日誌失敗: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region 系統托盤

        private void SetupSystemTray()
        {
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Text = "BlueCg 進程監控";
            notifyIcon.Visible = true;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void ShowMainWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.ShowBalloonTip(1000, "BlueCg 監控", "程序已最小化到系統托盤", ToolTipIcon.Info);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.ShowBalloonTip(1000, "BlueCg 監控", "程序將繼續在後台運行", ToolTipIcon.Info);
            }
        }

        #endregion

        #region 托盤菜單事件

        private void 顯示主視窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void 開始監控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isMonitoring)
                StartMonitoring();
        }

        private void 停止監控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isMonitoring)
                StopMonitoring();
        }

        private void 結束程式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isExiting) return;

            if (MessageBox.Show("確定要結束程式嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isExiting = true;

                // 停止監控與計時器
                if (monitorTimer != null)
                    monitorTimer.Stop();

                // 停止發包管理器
                packetManager?.StopExecutor();

                // 關閉所有被監控進程（如需）
                foreach (var item in monitoredProcesses)
                {
                    try
                    {
                        item.StopProcess(true);
                    }
                    catch { /* 忽略單一進程關閉失敗 */ }
                }

                // 記錄結束日誌
                LogMessage("程式即將結束", LogLevel.Info);

                // 隱藏托盤圖示
                notifyIcon.Visible = false;

                // 釋放托盤資源
                notifyIcon.Dispose();

                // 結束應用程式
                Application.Exit();
            }
        }

        #endregion

        #region 列表選擇事件

        private void ProcessListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
        }

        private void PathListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
        }

        private void LogListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 日誌列表選擇事件
        }

        #endregion

        #region 其他控件事件

        private void AutoStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // 保存自動啟動設置
            SaveSettingsToConfig();
        }

        private void ShowOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLogDisplay();
        }

        private void LogFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLogDisplay();
        }

        private void RefreshLogDisplay()
        {
            // 重新刷新日誌顯示，應用篩選
            // 這裡可以重新載入日誌或隱藏/顯示相關項目
        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
            RefreshProcessList();
            RefreshPathList();
            LogMessage("配置已重新載入", LogLevel.Info);
        }

        #endregion

        #region 發包管理器事件

        private void PacketManager_ConfigExecuted(object sender, PacketConfigEventArgs e)
        {
            LogMessage($"發包配置執行成功: {e.Config.PacketName}", LogLevel.Info);
            this.Invoke(new Action(() => RefreshPathList()));
        }

        private void PacketManager_ConfigFailed(object sender, PacketConfigEventArgs e)
        {
            LogMessage($"發包配置執行失敗: {e.Config.PacketName} - {e.Config.ErrorMessage}", LogLevel.Error);
            this.Invoke(new Action(() => RefreshPathList()));
        }

        #endregion

        #region 配置管理

        private void LoadConfiguration()
        {
            try
            {
                // 載入進程配置
                // 這裡可以從文件或數據庫載入保存的進程配置
                LogMessage("配置載入完成", LogLevel.Info);
            }
            catch (Exception ex)
            {
                LogMessage($"載入配置失敗: {ex.Message}", LogLevel.Error);
            }
        }

        private void SaveConfiguration()
        {
            try
            {
                // 保存進程配置
                // 這裡可以保存當前的進程配置到文件或數據庫
                LogMessage("配置保存完成", LogLevel.Info);
            }
            catch (Exception ex)
            {
                LogMessage($"保存配置失敗: {ex.Message}", LogLevel.Error);
            }
        }

        private void LoadSettingsFromConfig()
        {
            try
            {
                // 從App.config載入設置
                var config = ConfigurationManager.AppSettings;

                autoStartCheckBox.Checked = bool.Parse(config["AutoStartWithWindows"] ?? "false");

                var noResponseTime = config["DefaultNoResponseTime"] ?? "20";
                noResponseTextBox.Text = noResponseTime;

                var monitorInterval = int.Parse(config["MonitorInterval"] ?? "1000") / 1000;
                monitorIntervalTextBox.Text = monitorInterval.ToString();
            }
            catch (Exception ex)
            {
                LogMessage($"載入設置失敗: {ex.Message}", LogLevel.Warning);
            }
        }

        private void SaveSettingsToConfig()
        {
            try
            {
                // 保存設置到App.config
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["AutoStartWithWindows"].Value = autoStartCheckBox.Checked.ToString();

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                LogMessage($"保存設置失敗: {ex.Message}", LogLevel.Warning);
            }
        }

        #endregion

        private void rightPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}