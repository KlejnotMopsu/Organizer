using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class ReminderModel
    {
        #region Database properties
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Remind_date { get; set; }
        #endregion

        #region Properties
        public string FormatedRemindDate { get { return Remind_date.ToString("MM/dd/yyyy H:mm"); } }
        #endregion
    }
}
