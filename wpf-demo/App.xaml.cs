using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime;
using System.Threading;
using System.Windows;
using wpf_demo.Config;
using wpf_demo.Tools;

namespace wpf_demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        private static Mutex AppMutex;


        public App()
        {
#if !NET40
            var cachePath = $"{AppDomain.CurrentDomain.BaseDirectory}Cache";
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }
            ProfileOptimization.SetProfileRoot(cachePath);
            ProfileOptimization.StartProfile("Profile");
#endif
        }

        /// <summary>
        /// 主程序（开始）
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                AppMutex = new Mutex(true, "wpf-demo", out var createdNew);
                if (!createdNew)
                {
                    var current = Process.GetCurrentProcess();

                    foreach (var process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            Win32Helper.SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                    Shutdown();
                }
                else
                {
                    var splashScreen = new SplashScreen("Resources/Img/Cover.png");
                    splashScreen.Show(true, true);
                    IniData();
                    base.OnStartup(e);
                    ShutdownMode = ShutdownMode.OnLastWindowClose;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
          
        }

        private static void IniData()
        {
            //Handycontrol国际化
            HandyControl.Tools.ConfigHelper.Instance.SetLang("zh-cn");
            //加载日志配置
            Log4netHelper.loadConfig(GlobalConfig.log4netConfigPath);

        }

        /// <summary>
        /// 记录异常记录
        /// </summary>
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                string exStr = string.Format("{0}:{1}", sender.ToString(), e.Exception.Message + e.Exception.StackTrace);
                Log4netHelper.Error(exStr);
                MessageBox.Show(exStr);
            }
            catch (System.Exception)
            {

            }
        }
    }
}
