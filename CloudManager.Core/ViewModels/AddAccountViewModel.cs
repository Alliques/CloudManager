using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudManager.Core
{
    public class AddAccountViewModel : BaseViewModel
    {
        #region Constructor
        public AddAccountViewModel()
        {
            ClosePage = new RelayCommand(async () => await CloseThisPageMethodAsync());
            SelectCloudForAuth = new RelayParameterizedCommand(async (cloudType) => await SelectCloudForAuthCommand(cloudType));
        }
        #endregion

        #region Methods
        public async Task CloseThisPageMethodAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.LoginPage);
            await Task.Delay(500);
        }

        public async Task SelectCloudForAuthCommand(object cloudType)
        {
            IoC.Get<ApplicationViewModel>().CurrentAuthAdress = cloudType;
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.LoginPage);
            await Task.Delay(500);
        }
        #endregion

        #region Commands
        public ICommand ClosePage { get; set; }
        public ICommand SelectCloudForAuth { get; set; }
        #endregion
    }
   
}
