using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using CloudManader1._0.Animation;
namespace CloudManader1._0
{
    /// <summary>
    /// Base functional for all pages
    /// </summary>
    public class BasePage<VM> : Page
        where VM:BaseViewModel,new()
    {
        #region Private member
        private VM mViewModel;
        #endregion

        #region Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideFromLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The viewModel assotiated with this page
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return mViewModel;
            }
            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }
        #endregion
          
        #region Constructor
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = System.Windows.Visibility.Collapsed;
            this.Loaded += Page_Loaded;

            this.ViewModel = new VM(); 
        }
        #endregion



        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        /// <summary>
        /// animate  page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideFromRight:

                    await this.SlideAndFateInFromRight(this.SlideSeconds);

                    break;
            }
        }
        /// <summary>
        /// animate page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideFromLeft:

                    await this.SlideAndFateInFromLeft(this.SlideSeconds);

                    break;
            }
        }
    }
}
