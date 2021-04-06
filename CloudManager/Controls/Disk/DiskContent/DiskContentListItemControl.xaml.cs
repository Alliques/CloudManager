using System;
using System.Windows.Controls;

namespace CloudManager
{
    /// <summary>
    /// Interaction logic for DiskContentListItemControl.xaml
    /// </summary>
    public partial class DiskContentListItemControl : UserControl
    {
        public DiskContentListItemControl()
        {
            InitializeComponent();
            this.DataContext = new DiskContentListItemViewModel();
        }
    }
}
