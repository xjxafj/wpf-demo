using System;
using System.IO;

namespace wpf_demo.Config
{
    /// <summary>
    /// 配置相关
    /// </summary>
    public  class GlobalConfig
    {
        /// <summary>
        /// 主程序文件夹路径
        /// </summary>
        public static string appDir  = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public static string log4netConfigPath = Path.Combine(appDir, "Config", "log4net.config");
        //控制自动更新参数错误显示只显示一次
        public static  bool isOneShowUpdateConfigError = true;
    }
}
