using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    class DefaultImageAndResize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input_url = value as string;
            string output_url;

            string imageFolder = AppDomain.CurrentDomain.BaseDirectory + @"Images\";
            string inputImage = imageFolder + input_url;

            string defaultimage = imageFolder + "default.jpg";

            if (String.IsNullOrWhiteSpace(input_url))           //(input_url == null || input_url == "")
            {
                if (File.Exists(defaultimage))
                {
                    output_url = defaultimage;
                }
                else
                {
                    return inputImage;
                }
            }
            else
            {
                //// AFHVERJU VIRKAR ÞETTA EKKI!??!?
                //BitmapImage resizedImage = new BitmapImage();
                //resizedImage.BeginInit();
                //resizedImage.UriSource = new Uri(input_url);
                //resizedImage.DecodePixelWidth = 210;
                //resizedImage.DecodePixelHeight = 160;
                //resizedImage.EndInit();

                //Image outputImage = new Image();
                //outputImage.Source = resizedImage;
                //output_url = outputImage.ToString();

                if (File.Exists(inputImage) == true)
                {
                    return inputImage;
                }
                else
                {
                    output_url = defaultimage;
                }


            }

            return output_url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
