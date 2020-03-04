using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CloudManader.Controls
{
    public class CustomizableProgressBar : ProgressBar
    {
        public Brushes ProgressBarBgColor
        {
            get { return (Brushes)GetValue(ProgressBarBgColorProperty); }
            set { SetValue(ProgressBarBgColorProperty, value); }
        }

        public static readonly DependencyProperty ProgressBarBgColorProperty =
            DependencyProperty.Register("ProgressBarBgColor", typeof(Brushes), typeof(CustomizableProgressBar));

        public Brushes FootingBgColor
        {
            get { return (Brushes)GetValue(FootingBgColorProperty); }
            set { SetValue(FootingBgColorProperty, value); }
        }

        public static readonly DependencyProperty FootingBgColorProperty =
            DependencyProperty.Register("FootingBgColor", typeof(Brushes), typeof(CustomizableProgressBar));


    }
}
