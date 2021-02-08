using System;
using System.Collections.Generic;
using System.Text;

namespace wpf_demo.ViewModel
{
    public class DemoInfoModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public string Key
        {
            get; set;
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

        public IList<DemoItemModel> DemoItemList
        {
            get; set;
        }
    }
}
