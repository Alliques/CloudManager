
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
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.AddAccountPage);
            await Task.Delay(1);
        }
        public ICommand ClosePage { get; set; }
    }
    public enum AccountType
    {
        GoogleDrive,
        OneDrive,
        MailCloud,
        YandexDisk
    }
}
