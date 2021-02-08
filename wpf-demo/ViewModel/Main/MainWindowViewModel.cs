﻿using System;
using System.Collections.Generic;
using System.Text;

namespace wpf_demo.ViewModel
{
   public class MainWindowViewModel:GalaSoft.MvvmLight.ViewModelBase
    {
        private string _Title;
        private double _Age=30;

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        public double Age
        {
            get => _Age;
            set => Set(ref _Age, value);
        }
    }
}
