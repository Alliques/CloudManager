
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
        private void BasePage_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //browser.GetBrowser().Dispose();
           
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
           //browser.GetFocusedFrame();
        }   
    }
}
