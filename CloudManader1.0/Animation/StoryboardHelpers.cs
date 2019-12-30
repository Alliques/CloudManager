using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace CloudManager.Animation
{
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds a slide from right animation to storyboard
        /// </summary>
        /// <param name="storyboard">the storyboard to add the animation to</param>
        /// <param name="second"> animation time</param>
        /// <param name="offset"> The distance to right from start</param>
        /// <param name="deselerationRatio">Rate of deseleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard,float second,double offset, float decelerationRatio = 0.9f)
        {
            var slideanimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(slideanimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideanimation);
        }
        /// <summary>
        /// Adds a slide to right animation to storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="second"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float second, double offset, float decelerationRatio = 0.9f)
        {
            var slideanimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(slideanimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideanimation);
        }

        /// <summary>
        /// fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="second"></param>
        public static void AddFadeIn(this Storyboard storyboard, float second)
        {
            var slideanimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = 0,
                To = 1,
            };
            Storyboard.SetTargetProperty(slideanimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(slideanimation);
        }

        /// <summary>
        /// fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="second"></param>
        public static void AddFadeOut(this Storyboard storyboard, float second)
        {
            var slideanimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(second)),
                From = 1,
                To = 0,
            };
            Storyboard.SetTargetProperty(slideanimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(slideanimation);
        }
    }
}
