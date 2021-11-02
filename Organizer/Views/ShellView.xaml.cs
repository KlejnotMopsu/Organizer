using Organizer.UserControls;
using Organizer.ViewModels;
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
using System.Windows.Shapes;

namespace Organizer.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            //Switcher.SwitchControl(new NotesView());
        }

        private void NotesButton_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.SwitchControl(new NotesView());
        }

        private void DailyChoresButton_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.SwitchControl(new DailyChoresView());
        }

        private void MealsButton_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.SwitchControl(new MealsView());
        }

        private void RemindersButton_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.SwitchControl(new RemindersView());
        }

        #region Helpers
        public async void AnimateControlOut(UserControl userControl, int durationMiliseconds = 500)
        {
            MainGrid.Children.Add(userControl);
            Grid.SetRow(userControl, 1);
            Panel.SetZIndex(userControl, 10);

            Storyboard sb = new Storyboard();
            ThicknessAnimation anim = new ThicknessAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(durationMiliseconds),
                From = new Thickness(0, 0, 0, 0),
                To = new Thickness(-1000, 0, 1000, 0)
            };

            //Storyboard.SetTarget(anim, userControl);
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            sb.Children.Add(anim);
            sb.Begin(userControl);
            await Task.Delay(durationMiliseconds);

            MainGrid.Children.Remove(userControl);
        }
        #endregion
    }
}
