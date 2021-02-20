using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace wpf_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //配置文件更新到后台
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };


        //计时器
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();


        //业务控制，线程流程控制，如果ManualResetEvent的初始化为终止状态（true），那么该方法将一直工作，直到收到Reset信号。然后，直到收到Set信号，就继续工作。
        System.Threading.ManualResetEvent manualReset = new System.Threading.ManualResetEvent(true);

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ViewModel.ViewModelLocator.Instance.MainWindowViewModel.ProcessValue<100)
            {
                ViewModel.ViewModelLocator.Instance.MainWindowViewModel.ProcessValue += 1;
            }
            else
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Tag)
            {
                case "stop":
                    break;
                case "wait":
                    break;
                default:
                    break;
            }
        }
    }
}
