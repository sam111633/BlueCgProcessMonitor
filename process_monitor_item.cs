using System;
using System.Diagnostics;

namespace BlueCgProcessMonitor
{
    /// <summary>
    /// 進程監控項目類
    /// </summary>
    public class ProcessMonitorItem
    {
        /// <summary>
        /// 進程名稱
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 可執行文件路徑
        /// </summary>
        public string ExecutablePath { get; set; }

        /// <summary>
        /// 啟動參數
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// 實際進程對象
        /// </summary>
        public Process Process { get; set; }

        /// <summary>
        /// 進程狀態
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 內存使用量
        /// </summary>
        public string MemoryUsage { get; set; }

        /// <summary>
        /// CPU使用率
        /// </summary>
        public string CpuUsage { get; set; }

        /// <summary>
        /// 啟動時間
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 重啟次數
        /// </summary>
        public int RestartCount { get; set; }

        /// <summary>
        /// 是否自動重啟
        /// </summary>
        public bool AutoRestart { get; set; }

        /// <summary>
        /// 無回應時間（秒）
        /// </summary>
        public int NoResponseTime { get; set; }

        /// <summary>
        /// 最後響應檢查時間
        /// </summary>
        public DateTime LastResponseCheck { get; set; }

        /// <summary>
        /// 是否啟用監控
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 工作目錄
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// 備註信息
        /// </summary>
        public string Notes { get; set; }

        public ProcessMonitorItem()
        {
            ProcessName = string.Empty;
            ExecutablePath = string.Empty;
            Arguments = string.Empty;
            Status = "未啟動";
            MemoryUsage = "0 MB";
            CpuUsage = "0%";
            StartTime = DateTime.Now;
            RestartCount = 0;
            AutoRestart = true;
            NoResponseTime = 20;
            LastResponseCheck = DateTime.Now;
            IsEnabled = true;
            WorkingDirectory = string.Empty;
            Notes = string.Empty;
        }

        /// <summary>
        /// 啟動進程
        /// </summary>
        /// <returns>是否成功啟動</returns>
        public bool StartProcess()
        {
            try
            {
                if (Process != null && !Process.HasExited)
                {
                    return true; // 已經在運行
                }

                var startInfo = new ProcessStartInfo
                {
                    FileName = ExecutablePath,
                    Arguments = Arguments,
                    UseShellExecute = true,
                    WorkingDirectory = string.IsNullOrEmpty(WorkingDirectory) ?
                        System.IO.Path.GetDirectoryName(ExecutablePath) : WorkingDirectory
                };

                Process = Process.Start(startInfo);
                if (Process != null)
                {
                    StartTime = DateTime.Now;
                    Status = "正在運行";
                    return true;
                }
            }
            catch (Exception)
            {
                Status = "啟動失敗";
            }

            return false;
        }

        /// <summary>
        /// 停止進程
        /// </summary>
        /// <param name="force">是否強制終止</param>
        /// <returns>是否成功停止</returns>
        public bool StopProcess(bool force = false)
        {
            try
            {
                if (Process == null || Process.HasExited)
                {
                    Status = "已停止";
                    return true;
                }

                if (force)
                {
                    Process.Kill();
                }
                else
                {
                    Process.CloseMainWindow();
                    if (!Process.WaitForExit(5000)) // 等待5秒
                    {
                        Process.Kill(); // 強制終止
                    }
                }

                Status = "已停止";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 重啟進程
        /// </summary>
        /// <returns>是否成功重啟</returns>
        public bool RestartProcess()
        {
            try
            {
                StopProcess(true);
                System.Threading.Thread.Sleep(1000); // 等待1秒

                if (StartProcess())
                {
                    RestartCount++;
                    return true;
                }
            }
            catch (Exception)
            {
                // 重啟失敗
            }

            return false;
        }

        /// <summary>
        /// 檢查進程健康狀態
        /// </summary>
        /// <returns>健康狀態信息</returns>
        public ProcessHealthInfo CheckHealth()
        {
            var healthInfo = new ProcessHealthInfo();

            try
            {
                if (Process == null)
                {
                    healthInfo.IsHealthy = false;
                    healthInfo.Issue = "進程未啟動";
                    return healthInfo;
                }

                if (Process.HasExited)
                {
                    healthInfo.IsHealthy = false;
                    healthInfo.Issue = "進程已退出";
                    healthInfo.ExitCode = Process.ExitCode;
                    return healthInfo;
                }

                if (!Process.Responding)
                {
                    healthInfo.IsHealthy = false;
                    healthInfo.Issue = "進程無回應";
                    healthInfo.NoResponseDuration = DateTime.Now - LastResponseCheck;
                    return healthInfo;
                }

                // 檢查內存使用量
                Process.Refresh();
                var memoryMB = Process.WorkingSet64 / 1024 / 1024;
                if (memoryMB > 1024) // 超過1GB
                {
                    healthInfo.IsHealthy = true;
                    healthInfo.Warning = "內存使用量較高";
                }

                healthInfo.IsHealthy = true;
                healthInfo.MemoryUsageMB = memoryMB;
            }
            catch (Exception ex)
            {
                healthInfo.IsHealthy = false;
                healthInfo.Issue = $"健康檢查異常: {ex.Message}";
            }

            return healthInfo;
        }

        public override string ToString()
        {
            return $"{ProcessName} - {Status}";
        }
    }

    /// <summary>
    /// 進程健康狀態信息
    /// </summary>
    public class ProcessHealthInfo
    {
        public bool IsHealthy { get; set; }
        public string Issue { get; set; }
        public string Warning { get; set; }
        public int? ExitCode { get; set; }
        public TimeSpan? NoResponseDuration { get; set; }
        public long MemoryUsageMB { get; set; }

        public ProcessHealthInfo()
        {
            IsHealthy = true;
            Issue = string.Empty;
            Warning = string.Empty;
            MemoryUsageMB = 0;
        }
    }
}