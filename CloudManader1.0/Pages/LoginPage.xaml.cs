
using CefSharp;
using CefSharp.Wpf;
using CloudManager.Core;

namespace CloudManager
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
            var settings = new BrowserSettings();
        }
        ~LoginPage()
        {
            browser.CleanupCommand.CanExecute(null);
            browser.GetBrowser().Dispose();
            browser.Dispose();
        }
    }
}
