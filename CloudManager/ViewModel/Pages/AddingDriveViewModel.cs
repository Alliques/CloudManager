

using System.Windows.Input;

namespace CloudManager
{
  
    public class AddingDriveViewModel : BaseViewModel
    {
        public AddingDriveViewModel()
        {
            SelectDriveCommand = new RelayParameterizedCommand((obj) => SelectDrive(obj));
        }
        private void SelectDrive(object obj)
        {
            switch ((DriveType)obj)
            {
                case DriveType.GoogleDrive:
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Authentification);
                    break;
                case DriveType.OneDrive:
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Authentification);
                    break;
                case DriveType.YandexDisk:
                   IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Authentification);
                    break;
                default:
                    break;
            }
        }


        public ICommand SelectDriveCommand { get; set; }
    }
}
