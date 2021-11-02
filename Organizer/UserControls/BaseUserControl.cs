using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Organizer.UserControls
{
    public class BaseUserControl : UserControl
    {
        public BaseUserControl()
        {
            Loaded += UserControl_Loaded;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateIn();
        }

        public void AnimateIn()
        {
            Storyboard sb = new Storyboard();
            ThicknessAnimation anim = new ThicknessAnimation()
            {
                DecelerationRatio = 0.4f,
                Duration = TimeSpan.FromMilliseconds(500),
                From = new Thickness(this.ActualWidth, 0, -this.ActualWidth, 0),
                To = new Thickness(0, 0, 0, 0)
            };

            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            sb.Children.Add(anim);
            sb.Begin(this);
        }

        public void AnimateOut()
        {
            Storyboard sb = new Storyboard();
            ThicknessAnimation anim = new ThicknessAnimation()
            {
                DecelerationRatio = 0.4f,
                Duration = TimeSpan.FromMilliseconds(500),
                From = new Thickness(0, 0, 0, 0),
                To = new Thickness(-this.ActualWidth, 0, this.ActualWidth, 0)
            };

            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            sb.Children.Add(anim);
            sb.Begin(this);
        }
    }
}
