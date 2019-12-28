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
            this.DataContext = new MainViewModel(this);
        }
        
        private void DragWindowHeader(object sender, MouseButtonEventArgs e)
        {
            AppWindow.DragMove();
            if (e.ClickCount == 2)
            {
                if (AppWindow.WindowState == WindowState.Maximized)
                {
                    AppWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    AppWindow.WindowState = WindowState.Maximized;
                }
            }
        }

    }
}
