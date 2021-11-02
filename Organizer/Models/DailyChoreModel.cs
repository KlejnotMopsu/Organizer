using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class DailyChoreModel
    {
        #region Database properties
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date_of_addition { get; set; }
        #endregion

        #region Properties
        public bool Is_accomplished_today { get; set; }
        #endregion

        #region Methods
        public void CheckOut()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
