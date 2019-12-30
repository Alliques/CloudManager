
using CloudManager;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CloudManager.Core
{
    public class AddAccountViewModel : BaseViewModel
    {
        //public BasePage CurrentPage { get; set; }

        #region Constructor
        public AddAccountViewModel()
        {
            //CurrentPage = page;
            ClosePage = new RelayCommand(async () => await CloseThisPageMethodAsync());
        }
        #endregion

        #region Methods
        //private async System.Threading.Tasks.Task CloseThisPageMethodAsync()
        //{

        //    await CurrentPage.AnimateOut();
        //}
        public async Task CloseThisPageMethodAsync()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.LoginPage;
            var e = IoC.Get<ApplicationViewModel>().CurrentPage;
           // ((MainViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Start;
            await Task.Delay(1);
        }
        #endregion

        #region Commands
        public ICommand ClosePage { get; set; }
        #endregion
    }
}
