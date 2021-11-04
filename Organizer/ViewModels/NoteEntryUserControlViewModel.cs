using Caliburn.Micro;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModels
{
    public class NoteEntryUserControlViewModel : Screen
    {
        #region Properties
        private NoteModel _assignedNote;
        public NoteModel AssignedNote
        {
            get { return _assignedNote; }
            set { _assignedNote = value; NotifyOfPropertyChange(() => AssignedNote); }
        }
        #endregion

        #region Constructor
        public NoteEntryUserControlViewModel(NoteModel noteModel)
        {
            AssignedNote = noteModel;
        }
        #endregion

        #region Methods

        #endregion
    }
}
