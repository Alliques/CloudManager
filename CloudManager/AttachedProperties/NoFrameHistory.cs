using System.Windows;
using System.Windows.Controls;

namespace CloudManager
{
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //clear navigation history
            frame.Navigated += (s, args) => ((Frame)s).NavigationService.RemoveBackEntry();
        }
    }
}
