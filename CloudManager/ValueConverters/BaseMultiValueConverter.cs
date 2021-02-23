

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CloudManager
{
    /// <summary>
    /// base value converter 
    /// </summary>
    /// <typeparam name="T">Type of this value converter</typeparam>
    public abstract class BaseValueMultiConverter<T> : MarkupExtension, IMultiValueConverter
                 where T:class ,new ()
    {
        private static T mConverter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }
        //public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        //public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);


        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
        
    }
}
