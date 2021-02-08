using System;
using System.Windows;
using wpf_demo.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace wpf_demo.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            //SimpleIoc.Default.Register(() => new GrowlDemoViewModel(), "GrowlDemo");
            //SimpleIoc.Default.Register(() => new GrowlDemoViewModel(MessageToken.GrowlDemoPanel), "GrowlDemoWithToken");
            SimpleIoc.Default.Register<InteractiveDialogViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();


          
        }

        public static ViewModelLocator Instance => new Lazy<ViewModelLocator>(() =>
            Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;
        #region Vm
        public InteractiveDialogViewModel InteractiveDialog => SimpleIoc.Default.GetInstance<InteractiveDialogViewModel>();
        public MainWindowViewModel MainWindowViewModel => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
        #endregion
    }
}
