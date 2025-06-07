using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlueCgProcessMonitor
{
    /// <summary>
    /// 發包配置項目類
    /// </summary>
    public class PacketConfigItem
    {
        /// <summary>
        /// 配置ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 發包器名稱
        /// </summary>
        public string PacketName { get; set; }

        /// <summary>
        /// 期數
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 目標進程名稱
        /// </summary>
        public string TargetProcess { get; set; }

        /// <summary>
        /// 發包內容
        /// </summary>
        public string PacketData { get; set; }

        /// <summary>
        /// 發包間隔（毫秒）
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 最大重試次數
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// 當前重試次數
        /// </summary>
        public int CurrentRetries { get; set; }

        /// <summary>
        /// 最後執行時間
        /// </summary>
        public DateTime LastExecuteTime { get; set; }

        /// <summary>
        /// 執行狀態
        /// </summary>
        public PacketStatus Status { get; set; }

        /// <summary>
        /// 錯誤信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 成功執行次數
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// 失敗執行次數
        /// </summary>
        public int FailureCount { get; set; }

        public PacketConfigItem()
        {
            Id = 0;
            PacketName = string.Empty;
            Period = 1;
            IsEnabled = false;
            TargetProcess = string.Empty;
            PacketData = string.Empty;
            Interval = 1000;
            MaxRetries = 3;
            CurrentRetries = 0;
            LastExecuteTime = DateTime.MinValue;
            Status = PacketStatus.Stopped;
            ErrorMessage = string.Empty;
            Notes = string.Empty;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            SuccessCount = 0;
            FailureCount = 0;
        }

        /// <summary>
        /// 執行發包
        /// </summary>
        /// <returns>是否成功執行</returns>
        public bool Execute()
        {
            try
            {
                if (!IsEnabled)
                {
                    Status = PacketStatus.Disabled;
                    return false;
                }

                Status = PacketStatus.Running;
                LastExecuteTime = DateTime.Now;

                // 這裡實現實際的發包邏輯
                bool success = SendPacketToProcess();

                if (success)
                {
                    Status = PacketStatus.Success;
                    SuccessCount++;
                    CurrentRetries = 0;
                    ErrorMessage = string.Empty;
                }
                else
                {
                    Status = PacketStatus.Failed;
                    FailureCount++;
                    CurrentRetries++;
                    ErrorMessage = "發包失敗";
                }

                UpdateTime = DateTime.Now;
                return success;
            }
            catch (Exception ex)
            {
                Status = PacketStatus.Error;
                ErrorMessage = ex.Message;
                FailureCount++;
                CurrentRetries++;
                UpdateTime = DateTime.Now;
                return false;
            }
        }

        /// <summary>
        /// 實際發包邏輯（需要根據具體需求實現）
        /// </summary>
        /// <returns>是否成功發包</returns>
        private bool SendPacketToProcess()
        {
            try
            {
                // 示例：查找目標進程
                var processes = System.Diagnostics.Process.GetProcessesByName(TargetProcess);
                if (processes.Length == 0)
                {
                    ErrorMessage = $"找不到目標進程: {TargetProcess}";
                    return false;
                }

                // 示例：發送數據（這裡需要根據實際情況實現）
                // 例如使用命名管道、共享內存、網絡套接字等
                return true; // 暫時返回成功
            }
            catch (Exception ex)
            {
                ErrorMessage = $"發包異常: {ex.Message}";
                return false;
            }
        }

        /// <summary>
        /// 重置配置狀態
        /// </summary>
        public void Reset()
        {
            CurrentRetries = 0;
            Status = PacketStatus.Stopped;
            ErrorMessage = string.Empty;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 啟用配置
        /// </summary>
        public void Enable()
        {
            IsEnabled = true;
            Status = PacketStatus.Ready;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 停用配置
        /// </summary>
        public void Disable()
        {
            IsEnabled = false;
            Status = PacketStatus.Disabled;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 檢查是否需要重試
        /// </summary>
        /// <returns>是否需要重試</returns>
        public bool ShouldRetry()
        {
            return IsEnabled &&
                   Status == PacketStatus.Failed &&
                   CurrentRetries < MaxRetries;
        }

        /// <summary>
        /// 檢查是否可以執行
        /// </summary>
        /// <returns>是否可以執行</returns>
        public bool CanExecute()
        {
            if (!IsEnabled)
                return false;

            if (Status == PacketStatus.Running)
                return false;

            // 檢查間隔時間
            var timeSinceLastExecute = DateTime.Now - LastExecuteTime;
            return timeSinceLastExecute.TotalMilliseconds >= Interval;
        }

        /// <summary>
        /// 獲取狀態顯示文本
        /// </summary>
        /// <returns>狀態文本</returns>
        public string GetStatusText()
        {
            switch (Status)
            {
                case PacketStatus.Stopped:
                    return "已停止";
                case PacketStatus.Ready:
                    return "就緒";
                case PacketStatus.Running:
                    return "執行中";
                case PacketStatus.Success:
                    return "成功";
                case PacketStatus.Failed:
                    return "失敗";
                case PacketStatus.Error:
                    return "錯誤";
                case PacketStatus.Disabled:
                    return "已停用";
                default:
                    return "未知";
            }
        }

        /// <summary>
        /// 獲取詳細信息
        /// </summary>
        /// <returns>詳細信息字符串</returns>
        public string GetDetailedInfo()
        {
            return $"發包器: {PacketName}\n" +
                   $"期數: {Period}\n" +
                   $"狀態: {GetStatusText()}\n" +
                   $"目標進程: {TargetProcess}\n" +
                   $"間隔: {Interval}ms\n" +
                   $"成功次數: {SuccessCount}\n" +
                   $"失敗次數: {FailureCount}\n" +
                   $"最後執行: {(LastExecuteTime == DateTime.MinValue ? "從未執行" : LastExecuteTime.ToString())}\n" +
                   $"錯誤信息: {ErrorMessage}";
        }

        public override string ToString()
        {
            return $"{PacketName} - 期數:{Period} - {GetStatusText()}";
        }
    }

    /// <summary>
    /// 發包狀態枚舉
    /// </summary>
    public enum PacketStatus
    {
        /// <summary>
        /// 已停止
        /// </summary>
        Stopped,

        /// <summary>
        /// 就緒
        /// </summary>
        Ready,

        /// <summary>
        /// 執行中
        /// </summary>
        Running,

        /// <summary>
        /// 成功
        /// </summary>
        Success,

        /// <summary>
        /// 失敗
        /// </summary>
        Failed,

        /// <summary>
        /// 錯誤
        /// </summary>
        Error,

        /// <summary>
        /// 已停用
        /// </summary>
        Disabled
    }

    /// <summary>
    /// 發包配置管理器
    /// </summary>
    public class PacketConfigManager
    {
        private List<PacketConfigItem> configs;
        private Timer executeTimer;
        private readonly object lockObject = new object();

        public event EventHandler<PacketConfigEventArgs> ConfigExecuted;
        public event EventHandler<PacketConfigEventArgs> ConfigFailed;

        public PacketConfigManager()
        {
            configs = new List<PacketConfigItem>();
        }

        /// <summary>
        /// 添加配置
        /// </summary>
        public void AddConfig(PacketConfigItem config)
        {
            lock (lockObject)
            {
                config.Id = GetNextId();
                configs.Add(config);
            }
        }

        /// <summary>
        /// 移除配置
        /// </summary>
        public void RemoveConfig(int configId)
        {
            lock (lockObject)
            {
                configs.RemoveAll(c => c.Id == configId);
            }
        }

        /// <summary>
        /// 獲取所有配置
        /// </summary>
        public List<PacketConfigItem> GetAllConfigs()
        {
            lock (lockObject)
            {
                return new List<PacketConfigItem>(configs);
            }
        }

        /// <summary>
        /// 啟動執行器
        /// </summary>
        public void StartExecutor()
        {
            executeTimer = new Timer(ExecuteCallback, null, 0, 100);
        }

        /// <summary>
        /// 停止執行器
        /// </summary>
        public void StopExecutor()
        {
            executeTimer?.Dispose();
            executeTimer = null;
        }

        private void ExecuteCallback(object state)
        {
            lock (lockObject)
            {
                foreach (var config in configs)
                {
                    if (config.CanExecute())
                    {
                        bool success = config.Execute();

                        if (success)
                        {
                            ConfigExecuted?.Invoke(this, new PacketConfigEventArgs(config));
                        }
                        else
                        {
                            ConfigFailed?.Invoke(this, new PacketConfigEventArgs(config));
                        }
                    }
                }
            }
        }

        private int GetNextId()
        {
            return configs.Count > 0 ? configs.Max(c => c.Id) + 1 : 1;
        }
    }

    /// <summary>
    /// 發包配置事件參數
    /// </summary>
    public class PacketConfigEventArgs : EventArgs
    {
        public PacketConfigItem Config { get; }

        public PacketConfigEventArgs(PacketConfigItem config)
        {
            Config = config;
        }
    }
}