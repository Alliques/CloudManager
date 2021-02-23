

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
                    IoC.Get<ApplicationViewModel>().GoToAuthPage(ApplicationPage.Authentification, DriveType.GoogleDrive);
                    break;
                case DriveType.OneDrive:
                    IoC.Get<ApplicationViewModel>().GoToAuthPage(ApplicationPage.Authentification, DriveType.OneDrive);
                    break;
                case DriveType.YandexDisk:
                   IoC.Get<ApplicationViewModel>().GoToAuthPage(ApplicationPage.Authentification, DriveType.YandexDisk);
                    break;
                default:
                    break;
            }
        }


        public ICommand SelectDriveCommand { get; set; }
    }
}
