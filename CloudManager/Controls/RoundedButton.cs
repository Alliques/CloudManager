
using System.Windows;
using System.Windows.Controls;

namespace  CloudManader.Controls
{
    public class RoundedButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius", typeof(CornerRadius),
           typeof(RoundedButton), new FrameworkPropertyMetadata(new CornerRadius(0, 0, 0, 0)));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
