using Caliburn.Micro;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModels
{
    public class RemindersViewModel : Screen
    {
        #region Properties
        private BindableCollection<ReminderModel> _remindersCollection;
        public BindableCollection<ReminderModel> RemindersCollection
        {
            get { return _remindersCollection; }
            set { _remindersCollection = value; }
        }
        #endregion

        #region Constructor
        public RemindersViewModel()
        {
            RemindersCollection = Globals.AllReminders;
        }
        #endregion

        #region Methods

        #endregion

        #region Button clicks
        public void AddReminderButton()
        {
            Console.WriteLine("Adding reminder...");
        }
        #endregion
    }
}
