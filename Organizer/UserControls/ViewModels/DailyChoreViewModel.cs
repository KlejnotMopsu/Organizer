using Caliburn.Micro;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UserControls.ViewModels
{
    public class DailyChoreViewModel : Screen
    {
        #region Properties
        DailyChoreModel AssignedDailyChore { get; set; }


        private string _isAccomplishedString = "hjgffgh";
        public string IsAccomplishedString
        {
            get { return _isAccomplishedString; }
            set { _isAccomplishedString = value; NotifyOfPropertyChange(() => IsAccomplishedString); }
        }
        #endregion

        #region Constructor
        public DailyChoreViewModel()
        {
            Console.WriteLine("Benc benc wizowiefani");
        }
        public DailyChoreViewModel(Models.DailyChoreModel dailyChoreModel)
        {
            AssignedDailyChore = dailyChoreModel;
            Console.WriteLine($"AssignedDailyChore - {AssignedDailyChore.Description}");
        }
        #endregion
    }
}
