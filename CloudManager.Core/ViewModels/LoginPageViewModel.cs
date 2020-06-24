
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudManager.Core
{
    public class LoginPageViewModel : BaseViewModel
    {
        public AccountType CloudAuthType { get; set; }
        
        public string Uri { get; set; }

        public LoginPageViewModel()
        {
            ToWorckPageCommand = new RelayCommand(async () => await CloseThisPageMethodAsync());
            AuthentificationStart();
        }

        private void AuthentificationStart()
        {
            var cloudType=IoC.Get<ApplicationViewModel>().CurrentAuthAdress as string;
            switch (cloudType)
            {
                case nameof(AccountType.GoogleDrive):
                    break;
                case nameof(AccountType.OneDrive):
                    break;
                case nameof(AccountType.MailCloud):
                    break;
                case nameof(AccountType.YandexDisk):
                    break;
                default:
                    break;
            }
        }

        public async Task CloseThisPageMethodAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.WorkPage);
            await Task.Delay(1);
        }
        public ICommand ToWorckPageCommand { get; set; }
    }
    public enum AccountType
    {
        GoogleDrive,
        OneDrive,
        MailCloud,
        YandexDisk
    }
}
