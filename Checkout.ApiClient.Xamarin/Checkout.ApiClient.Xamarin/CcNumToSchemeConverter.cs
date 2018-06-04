using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Checkout.ApiClient.Xamarin
{
    public class CcNumToSchemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            } else
            {
                string ccNum = value.ToString();
                Console.WriteLine(ccNum);

                if (ccNum.StartsWith("34") || ccNum.StartsWith("37"))
                {
                    return "logo_amex.png";
                } else if (ccNum.StartsWith("4"))
                {
                    return "logo_visa.png";
                } else if (ccNum.StartsWith("51") || ccNum.StartsWith("52") || ccNum.StartsWith("53") || ccNum.StartsWith("54") || ccNum.StartsWith("55"))
                {
                    return "logo_mastercard.png";
                } else
                {
                    return "";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
