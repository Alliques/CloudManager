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

namespace CloudManader1._0.Resources.Controls
{
    /// <summary>
    /// Interaction logic for RippleButton.xaml
    /// </summary>
    public partial class RippleButton : Button
    {
        DoubleAnimation CurtainAnimation = new DoubleAnimation();

        public RippleButton()
        {
            InitializeComponent();
        }
        
    }
}
