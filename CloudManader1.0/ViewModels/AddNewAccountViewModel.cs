
using CloudManader1._0;
using System.Windows.Controls;
using System.Windows.Input;

namespace CloudManader1._0
{
    public class AddNewAccountViewModel : BaseViewModel
    {
        public BasePage CurrentPage { get; set; }

        #region Constructor
        public AddNewAccountViewModel(BasePage page)
        {
            CurrentPage = page;
            ClosePage = new RelayCommand(async ()=> await CloseThisPageMethodAsync());
        }
        #endregion

        #region Methods
        private async System.Threading.Tasks.Task CloseThisPageMethodAsync()
        {

            await CurrentPage.AnimateOut();
        }
        #endregion

        #region Commands
        public ICommand ClosePage { get; set; }
        #endregion
    }
}
