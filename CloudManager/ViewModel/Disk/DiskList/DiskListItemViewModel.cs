using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CloudManager
{
    public class DiskListItemViewModel : BaseViewModel
    {
        public bool IsSelected { get; set; }

        public DiskListItemViewModel()
        {
            SelectDriveCommand = new RelayCommand(() => SelectDrive());
        }
        public void SelectDrive()
        {
            IsSelected = true;
        }
        public ICommand SelectDriveCommand { get; set; }
    }
}
