namespace XamarinFormApp2.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;


    class NonNullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return !String.IsNullOrEmpty((string)value);
            }

            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}