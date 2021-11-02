using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Organizer.UserControls
{
    /// <summary>
    /// Interaction logic for ControlSwitcher.xaml
    /// </summary>
    public partial class ControlSwitcher : UserControl
    {
        #region Properties
        public UserControl CurrentControl { get; set; } = null;
        public UserControl PreviousControl { get; set; } = null;
        #endregion

        #region Constructor
        public ControlSwitcher()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public async void SwitchControl(UserControl userControl)
        {
            PreviousControl = CurrentControl;
            AnimateControlOut(PreviousControl);            
            //await Task.Delay(500);
            //MainGrid.Children.Remove(CurrentControl);
            AnimateControlIn(userControl);
        }
        #endregion

        #region Animations
        private void AnimateControlIn(UserControl userControl)
        {
            Storyboard sb = new Storyboard();
            ThicknessAnimation anim = new ThicknessAnimation() {
                DecelerationRatio = 0.8f,
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),
                From = new Thickness(MainGrid.ActualWidth,0,0,0),
                To = new Thickness(0,0,0,0)
            };
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            sb.Children.Add(anim);
            sb.Begin(userControl);


            //if (CurrentControl != null) MainGrid.Children.Remove(CurrentControl);
            CurrentControl = userControl;
            MainGrid.Children.Add(CurrentControl);
        }

        private async void AnimateControlOut(UserControl userControl)
        {
            if (userControl == null) return;

            Storyboard sb = new Storyboard();
            ThicknessAnimation anim = new ThicknessAnimation()
            {
                DecelerationRatio = 0.8f,
                Duration = new Duration(TimeSpan.FromMilliseconds(500)),
                To = new Thickness(0, 0, (MainGrid.ActualWidth + userControl.ActualWidth), 0)
            };
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            sb.Children.Add(anim);
            sb.Begin(userControl);
            await Task.Delay(500);

            MainGrid.Children.Remove(PreviousControl);
        }
        #endregion
    }
}
