using System;
using GalaSoft.MvvmLight.Command;
using HandyControl.Tools.Extension;

namespace wpf_demo.ViewModel
{
    public class InteractiveDialogViewModel : GalaSoft.MvvmLight.ViewModelBase, IDialogResultable<string>
    {

        private string _title;

        public Action CloseAction
        {
            get; set;
        }

        private string _result;

        public string Result
        {
            get => _result;
#if NET40
            set => Set(nameof(Result), ref _result, value);
#else
            set => Set(ref _result, value);
#endif
        }

        private string _message;

        public string Message
        {
            get => _message;
#if NET40
            set => Set(nameof(Message), ref _message, value);
#else
            set => Set(ref _message, value);
#endif
        }

        public RelayCommand CloseCmd => new Lazy<RelayCommand>(() => new RelayCommand(() => CloseAction?.Invoke())).Value;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
