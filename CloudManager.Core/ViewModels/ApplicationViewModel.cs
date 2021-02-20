using System;
using System.Collections.Generic;

namespace CloudManager.Core
{
    public class ApplicationViewModel:BaseViewModel
    {
        
        public ApplicationViewModel()
        {
        }
        public DriveType Storage { get; private set; } = DriveType.None;

        
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.AddAccountPage;

        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
        }
        public void GoToAuthPage(ApplicationPage page, DriveType storage)
        {
            CurrentPage = page;
            Storage = storage;
        }
    }
}
