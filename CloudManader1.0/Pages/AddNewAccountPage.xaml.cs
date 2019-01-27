
namespace CloudManader1._0
{
    /// <summary>
    /// Interaction logic for AddNewAccountPage.xaml
    /// </summary>
    public partial class AddNewAccountPage : BasePage
    {
        public AddNewAccountPage()
        {
            InitializeComponent();
            this.DataContext = new AddNewAccountViewModel(this);
        }
    }
}
