using Caliburn.Micro;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModels
{
    public class DailyChoresViewModel : Screen
    {
        #region Properties
        private BindableCollection<DailyChoreModel> _dailyChores;
        public BindableCollection<DailyChoreModel> DailyChores
        {
            get { return _dailyChores; }
            set { _dailyChores = value; NotifyOfPropertyChange(() => DailyChores); }
        }
        #endregion

        #region Constructor
        public DailyChoresViewModel()
        {
            DailyChores = Globals.AllDailyChores;
        }
        #endregion

        #region Methods

        #endregion
    }
}
