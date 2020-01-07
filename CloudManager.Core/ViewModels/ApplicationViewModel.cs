using System;

namespace CloudManager.Core
{
    public class ApplicationViewModel:BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        /// 
        public object CurrentAuthAdress { get;  set; }
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.AddAccountPage;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

        }
    }
}
