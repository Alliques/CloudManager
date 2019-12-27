
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
            ClosePage = new RelayCommand(async () => await CloseThisPageMethodAsync());
        }
        #endregion

        #region Methods
        public async Task CloseThisPageMethodAsync()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Login;

            await Task.Delay(1);
        }
        #endregion

        #region Commands
        public ICommand ClosePage { get; set; }
        #endregion
    }
}
