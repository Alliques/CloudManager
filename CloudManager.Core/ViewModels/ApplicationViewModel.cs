namespace CloudManager.Core
{
    public class ApplicationViewModel:BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.AddAccountPage;
    }
}
