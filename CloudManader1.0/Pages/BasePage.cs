using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CloudManader1._0
{
    /// <summary>
    /// Base functional for all pages
    /// </summary>
    public class BasePage : Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideFromLeft;

        public float SlideSeconds { get; set; } = 0.8f;


        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = System.Windows.Visibility.Collapsed;
            this.Loaded += Page_Loaded;
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await Animate();
        }

        public async Task Animate()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.None:
                    break;
                case PageAnimation.SlideFromRight:
                    var storyboard = new Storyboard();
                    var slideanimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.9f
                    };
                    Storyboard.SetTargetProperty(slideanimation, new PropertyPath("Margin"));
                    storyboard.Children.Add(slideanimation);
                    storyboard.Begin(this);

                    await Task.Delay((int)this.SlideSeconds * 1000);

                    this.Visibility = Visibility.Visible;


                    break;
            }
        }
    }
}
