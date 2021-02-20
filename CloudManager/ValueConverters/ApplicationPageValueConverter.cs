using CloudManager.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace CloudManager
{
    public class ApplicationPageValueConverter : BaseValueMultiConverter<ApplicationPageValueConverter>
    {

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var p = (DriveType)values[1];
            switch ((ApplicationPage)values[0])
            {
                case ApplicationPage.LoginPage:
                    return new LoginPage();
                case ApplicationPage.AddAccountPage:
                    return new AddAccountPage();
                case ApplicationPage.WorkPage:
                    return new WorkPage();
                case ApplicationPage.AddingDrive:
                    return new AddingDrivePage();
                case ApplicationPage.Authentification:
                    return new AuthentificationPage();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
