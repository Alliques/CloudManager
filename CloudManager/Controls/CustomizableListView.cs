using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace  CloudManader.Controls
{
    public class CustomizableListView : ListView
    {


        public Thickness ItemsMargin
        {
            get { return (Thickness)GetValue(ItemsMarginProperty); }
            set { SetValue(ItemsMarginProperty, value); }
        }

        public static readonly DependencyProperty ItemsMarginProperty =
            DependencyProperty.Register("ItemsMargin", typeof(Thickness), typeof(CustomizableListView), new FrameworkPropertyMetadata(new Thickness(0)));


    }
}
