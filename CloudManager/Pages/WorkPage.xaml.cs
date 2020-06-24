using CloudManager;
namespace CloudManager
{
    /// <summary>
    /// Interaction logic for WorkPage.xaml
    /// </summary>
    public partial class WorkPage : BasePage<WorkPageViewModel>
    {
        public WorkPage()
        {
            InitializeComponent();
        }

        private void BasePage_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            if (WindowWidth < 900)
            {
                descriptionView.Width = new System.Windows.GridLength(0);
            }
            else
            {
                if(WindowWidth>=900)
                {
                    descriptionView.Width = new System.Windows.GridLength(290);
                }
            }
        }
    }
}
