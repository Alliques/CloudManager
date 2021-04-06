using System.Collections.Generic;

namespace CloudManager
{
    public class DiskContentListViewModel:BaseViewModel
    {
        public List<DiskContentListItemViewModel> Items { get; set; }

        public DiskContentListViewModel()
        {
            Items = new List<DiskContentListItemViewModel> { new DiskContentListItemViewModel(), new DiskContentListItemViewModel(), new DiskContentListItemViewModel() };
        }
    }
}
