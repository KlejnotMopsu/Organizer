using Organizer.Models;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Organizer.UserControls.Views
{
    /// <summary>
    /// Interaction logic for DailyChoreView.xaml
    /// </summary>
    public partial class DailyChoreView : UserControl
    {
        #region Dependency properties
        public DailyChoreModel AssignedChore
        {
            get { return (DailyChoreModel)GetValue(AssignedChoreProperty); }
            set { SetValue(AssignedChoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AssignedChore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssignedChoreProperty =
            DependencyProperty.Register("AssignedChore", typeof(DailyChoreModel), typeof(DailyChoreView));
        #endregion

        #region Properties
        public string IsAccomplishedString { get { if (AssignedChore.Is_accomplished_today) return "X"; else return "O"; } }
        #endregion

        #region Constructor
        public DailyChoreView()
        {
            InitializeComponent();            
        }
        #endregion

        #region Methods

        #endregion

        private void CheckDailyChoreButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Assigne chore - {AssignedChore?.Description}");
        }
    }
}
