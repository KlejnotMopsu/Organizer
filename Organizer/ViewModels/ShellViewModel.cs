using Caliburn.Micro;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Organizer.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        #region Properties
        //public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        private ApplicationPage _currentPage;
        public ApplicationPage CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; NotifyOfPropertyChange(() => CurrentPage); }
        }

        #endregion

        #region Constructor
        public ShellViewModel()
        {
            Globals.InitializeGlobals();
        }
        #endregion

        #region Methods
        private void ActivateNewControl(object userControl)
        {
            ActivateItemAsync(userControl);
        }
        #endregion

        #region Button Clicks
        public void NotesButton()
        {
            UserControls.BaseUserControl tempUc;

            //Console.WriteLine($"benv - {tempUc?.GetType()}");
            ActivateNewControl(new NotesViewModel());

            //await Task.Delay(100);
        }

        public void DailyChoresButton()
        {
            ActivateNewControl(new DailyChoresViewModel());
        }

        public void MealsButton()
        {
            ActivateNewControl(new MealsViewModel());
        }

        public void RemindersButton()
        {
            ActivateNewControl(new RemindersViewModel());
        }
        #endregion
    }
}
