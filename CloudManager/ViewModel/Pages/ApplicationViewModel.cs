using System;
using System.Collections.Generic;

namespace CloudManager
{
    public class ApplicationViewModel:BaseViewModel
    {
        
        public ApplicationViewModel()
        {
        }

        
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.AddAccountPage;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
        }
    }
}
