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
            SelectedItemCommand = new RelayCommand(() => SelectedItem());
        }
        public void SelectedItem()
        {
            IsSelected = true;
        }
        public ICommand SelectedItemCommand { get; set; }
    }
}
