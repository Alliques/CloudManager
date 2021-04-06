using System.Collections.Generic;

namespace CloudManager
{
    public class DiskContentListDesignModel : DiskContentListViewModel
    {
        public static DiskContentListDesignModel Instance => new DiskContentListDesignModel();
        public DiskContentListDesignModel()
        {
            Items = new List<DiskContentListItemViewModel> { new DiskContentListItemViewModel(), new DiskContentListItemViewModel(), new DiskContentListItemViewModel() };
        }
    }
}
