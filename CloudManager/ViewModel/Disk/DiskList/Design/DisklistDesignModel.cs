using System.Collections.Generic;

namespace CloudManager
{
    public class DisklistDesignModel : DiskListViewModel
    {
        public static DisklistDesignModel Instance => new DisklistDesignModel();
        public DisklistDesignModel()
        {
            Items = new List<DiskListItemViewModel> { new DiskListItemViewModel(), new DiskListItemViewModel(), new DiskListItemViewModel() };
        }
    }
}
