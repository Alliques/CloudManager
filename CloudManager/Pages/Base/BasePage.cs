using System.Threading.Tasks;
using System.Windows.Controls;

namespace CloudManager
{
    /// <summary>
    /// Base functional for all pages
    /// </summary>
    public class BasePage :Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideFromLeft;

        public float SlideSeconds { get; set; } = 0.6f;

        public bool ShouldAnimateOut { get; set; }
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = System.Windows.Visibility.Collapsed;
            this.Loaded += Page_Loaded;
        }
        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateOut();
            }
            else
            {
                await AnimateIn();
            }

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

                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

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

                    await this.SlideAndFateInToLeft(this.SlideSeconds);

                    break;
            }
        }
    }

    /// <summary>
    /// A base page with added ViewModel support
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Private member
        private VM mViewModel;
        #endregion

        #region Properties
       

        /// <summary>
        /// The viewModel assotiated with this page
        /// </summary>
        public VM ViewModel
        {
            get=> mViewModel;
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
        public BasePage() :base()
        {
            this.ViewModel = new VM(); 
        }
        #endregion



       
    }
}
