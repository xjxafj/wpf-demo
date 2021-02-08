using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace wpf_demo.Tools.Converter
{
    public class LevelConverter : IValueConverter
    {
        //源属性传给目标属性时，调用此方法ConvertBack
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int no = 0;
                if (int.TryParse(value.ToString(), out no))
                {
                    return no - 1;
                };
                
            }
            catch (Exception)
            {

                
            }
            return value;
        }

        //目标属性传给源属性时，调用此方法ConvertBack
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
