

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
            
        }
        private void BasePage_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //browser.GetBrowser().Dispose();
           
        }

    }
}
