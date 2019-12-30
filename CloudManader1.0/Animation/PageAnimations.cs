using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using CloudManager.Animation;
namespace CloudManager
{
    public static class PageAnimations
    {
        /// <summary>
        /// slide a page in from right
        /// </summary>
        /// <param name="page">animate page</param>
        /// <param name="seconds">animation durate</param>
        /// <returns></returns>
        public static async Task SlideAndFateInFromRight(this Page page,float seconds)
        {
            var storyboard = new Storyboard();
            storyboard.AddSlideFromRight(seconds, page.WindowWidth);

            //Slide from right animation
            storyboard.AddFadeIn(seconds);

            //Fade in animation
            storyboard.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds*1000));
        }
        /// <summary>
        /// slide a page in out to the left
        /// </summary>
        /// <param name="page">animate page</param>
        /// <param name="seconds">animation durate</param>
        /// <returns></returns>
        public static async Task SlideAndFateInFromLeft(this Page page, float seconds)
        {
            var storyboard = new Storyboard();
            storyboard.AddSlideFromLeft(seconds, page.WindowWidth);

            //Slide from right animation
            storyboard.AddFadeOut(seconds);

            //Fade in animation
            storyboard.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
