using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace wpf_demo.ViewModel
{
    public class DemoItemModel : ObservableObject
    {
        public string Name
        {
            get; set;
        }

        public string TargetCtlName
        {
            get; set;
        }

        public string ImageName
        {
            get; set;
        }

        public bool IsNew
        {
            get; set;
        }

        private bool _isVisible = true;

        public bool IsVisible
        {
            get => _isVisible;
            set => Set(ref _isVisible, value);
        }
    }
}
