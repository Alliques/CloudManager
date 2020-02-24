using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace CloudManager
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //get frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //store the current page as the old page
            var oldPageContent = newPageFrame.Content;

            newPageFrame.Content = null;

            oldPageFrame.Content = oldPageContent;

            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
            }
            newPageFrame.Content = e.NewValue;
        }

        #region Constructor
        public PageHost()
        {
            InitializeComponent();
        }
        #endregion
    }
}
