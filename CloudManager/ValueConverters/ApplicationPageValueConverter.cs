using CloudManager.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace CloudManager
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.LoginPage:
                    return new LoginPage();
                case ApplicationPage.AddAccountPage:
                    return new AddAccountPage();
                case ApplicationPage.WorkPage:
                    return new WorkPage();
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
