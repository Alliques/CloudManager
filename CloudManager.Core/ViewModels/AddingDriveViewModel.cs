

using System.Windows.Input;

namespace CloudManager.Core
{
    public enum StorageType
    {
        None,
        GooleDrive,
        OneDrive,
        YandexDisk
    }
    public class AddingDriveViewModel : BaseViewModel
    {
        public AddingDriveViewModel()
        {
            SelectDriveCommand = new RelayParameterizedCommand((obj) => SelectDrive(obj));
        }
        private void SelectDrive(object obj)
        {
            switch ((StorageType)obj)
            {
                case StorageType.None:
                    break;
                case StorageType.GooleDrive:
                    
                    break;
                case StorageType.OneDrive:
                    
                    break;
                case StorageType.YandexDisk:
                   
                    break;
                default:
                    break;
            }
        }


        public ICommand SelectDriveCommand { get; set; }
    }
}
