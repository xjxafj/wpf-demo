using System;
using System.ComponentModel;

namespace wpf_demo.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
                catch (Exception ex)
                {
                    HandyControl.Controls.Growl.InfoGlobal(ex.Message);
                }
                
            }
        }
    }
}
