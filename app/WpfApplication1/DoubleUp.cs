using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication1
{
    class DoubleUp : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double? previousValue = value as double?;
            double newValue;
            if (previousValue == null)
            {
                return previousValue;
            }
            else
            {
                if (App.Current.Properties["isDouble"] == null)
                {
                    return previousValue;
                }
                else
                {
                    bool isDouble = (bool)App.Current.Properties["isDouble"];

                    if (isDouble == false)
                    {
                        newValue = (double)previousValue * 2.0;
                    }
                    else
                    {
                        newValue = (double)previousValue;
                    }

                    return newValue;
                }

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
