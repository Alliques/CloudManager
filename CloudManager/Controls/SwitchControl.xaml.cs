using CloudManager.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudManager
{
    /// <summary>
    /// Interaction logic for SwitchControl.xaml
    /// </summary>
    public partial class SwitchControl : UserControl
    {
        public SwitchControl()
        {
            InitializeComponent();
            roundedButton = ellipseBtn;
        }

        static RoundedButton roundedButton;

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(SwitchControl), new UIPropertyMetadata(false,new PropertyChangedCallback(CurrentStateChanged)));

        private static void CurrentStateChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            SwitchControl s = (SwitchControl)depObj;
            s.IsChecked = (bool)args.NewValue;
           
        }

        private void OnAnimation()
        {
            ThicknessAnimation buttonAnimation = new ThicknessAnimation();

            buttonAnimation.From = ellipseBtn.Margin;
            buttonAnimation.To = new Thickness(8 + ellipseBtn.ActualWidth, 2, 0, 2);
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.25);
            ellipseBtn.BeginAnimation(Border.MarginProperty, buttonAnimation);
        }
        private void OffAnimation()
        {
            ThicknessAnimation buttonAnimation = new ThicknessAnimation();

            buttonAnimation.From = ellipseBtn.Margin;
            buttonAnimation.To = new Thickness(2);
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.25);
            ellipseBtn.BeginAnimation(Border.MarginProperty, buttonAnimation);
        }

        private void border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if ( ellipseBtn.Margin.Left<=2)
            {
                tileIcon.Fill = (Brush)FindResource("CommonBackgroundColorBrush");
                rowIcon.Fill = (Brush)FindResource("DriveListSelectedItemColorBrush");
                IsChecked = true;
                OnAnimation();
            }
            else
            {
                tileIcon.Fill = (Brush)FindResource("DriveListSelectedItemColorBrush");
                rowIcon.Fill = (Brush)FindResource("CommonBackgroundColorBrush");
                IsChecked = false;
                OffAnimation();
            }
            
        }

    
    }
}
