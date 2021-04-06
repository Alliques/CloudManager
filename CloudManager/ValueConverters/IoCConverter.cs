using System;
using System.Diagnostics;
using System.Globalization;
using Ninject;

namespace CloudManager
{
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Kernel.Get<ApplicationViewModel>();
                case nameof(AuthentificationViewModel):
                    return IoC.Kernel.Get<AuthentificationViewModel>();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
