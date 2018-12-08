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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloudManader1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }
       

        //private void max_minWind_btnClick(object sender, RoutedEventArgs e)
        //{
        //    if (mainWindow.WindowState == WindowState.Normal)
        //    {
        //        mainWindow.WindowState = WindowState.Maximized;
        //        max_minImage.Source = new BitmapImage(new Uri("/images/mainWindowImades/icon.png", UriKind.RelativeOrAbsolute));
        //    }
        //    else
        //    {
        //        mainWindow.WindowState = WindowState.Normal;
        //        max_minImage.Source = new BitmapImage(new Uri("/images/mainWindowImades/full-screen.png", UriKind.RelativeOrAbsolute));
        //    }
        //}


        //private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonOpenMenu.Visibility = Visibility.Visible;
        //    ButtonCloseMenu.Visibility = Visibility.Collapsed;
        //}
        //private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonOpenMenu.Visibility = Visibility.Collapsed;
        //    ButtonCloseMenu.Visibility = Visibility.Visible;
        //}
    }
}
