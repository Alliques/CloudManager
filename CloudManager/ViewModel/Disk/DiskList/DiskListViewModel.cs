using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace CloudManager
{
    public class DiskListViewModel : BaseViewModel
    {
        public List<DiskListItemViewModel> Items { get; set; }

        public DiskListViewModel()
        {
            Items = new List<DiskListItemViewModel> { new DiskListItemViewModel(), new DiskListItemViewModel(), new DiskListItemViewModel() };
        }
        //public DiskListItemViewModel SelectedItem { get; set; }

    }
}
