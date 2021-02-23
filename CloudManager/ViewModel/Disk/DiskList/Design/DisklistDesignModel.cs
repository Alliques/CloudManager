using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager
{
    public class DisklistDesignModel : DiskListViewModel
    {
        public static DisklistDesignModel Instance => new DisklistDesignModel();
        public DisklistDesignModel()
        {
            Items = new List<ChatListItemViewModel> { new ChatListItemViewModel(), new ChatListItemViewModel(), new ChatListItemViewModel() };
        }
    }
}
