using System;
using System.Globalization;
using Xamarin.Forms;

namespace umaCollabApp
{
    class RatingConverter : IValueConverter
    {
        // convert the value (1-5) to whatever other value we want. 
        // Here, we give it the integer value of the number of stars.
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var rating = (int) value;
            if (rating == 1)
                return "1";
            if (rating == 2)
                return "2";
            if (rating == 3)
                return "3";
            if (rating == 4)
                return "4";
            if (rating == 5)
                return "5";

            return string.Empty;
        }


        // convert the visual representation of data to the specific DataType.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "yes";
                else
                    return "no";
            }
            return "no";


            // sem implementação, é mesmo assim.
            // throw new NotImplementedException();
        }
    }
}