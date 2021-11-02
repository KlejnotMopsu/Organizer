using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class NoteModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Is_highlighted { get; set; }
        #endregion

        #region Methods
        public void SwitchHighlight()
        {
            DataAcces.SwitchHighlight(this);
            Is_highlighted = !Is_highlighted;
        }
        #endregion
    }
}
