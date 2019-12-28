
using CloudManader1._0;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CloudManader1._0
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
            ((MainViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Start;
            await Task.Delay(500);
        }
        #endregion

        #region Commands
        public ICommand ClosePage { get; set; }
        #endregion
    }
}
