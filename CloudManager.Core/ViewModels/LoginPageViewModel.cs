
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudManager.Core
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            ClosePage = new RelayCommand(async () => await CloseThisPageMethodAsync());
        }
        public async Task CloseThisPageMethodAsync()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.AddAccountPage;
            // ((MainViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Start;
            await Task.Delay(1);
        }
        public ICommand ClosePage { get; set; }
        public string MyProperty { get; set; } = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=e6d2b189-15d4-472f-8ac9-ec6da36fcbed&scope=files.readwrite.all&response_type=code&redirect_uri=http://yandex.ru";
    }
}
