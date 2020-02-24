using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CloudManager.Styles
{
    public class CustomizableButton:Button
    {
        public CustomizableButton()
        {
            DefaultStyleKey = typeof(CustomizableButton);
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomizableButton), new FrameworkPropertyMetadata(typeof(CustomizableButton)));
        }


        public CornerRadius ButtonCorners
        {
            get { return (CornerRadius)GetValue(ButtonCornersProperty); }
            set { SetValue(ButtonCornersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonCorners.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCornersProperty =
            DependencyProperty.Register("ButtonCorners", typeof(CornerRadius), typeof(CustomizableButton));


    }
}
