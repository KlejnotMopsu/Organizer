using Caliburn.Micro;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Organizer.ViewModels
{    
    public class NotesViewModel : Screen
    {
        #region Properties
        private System.Windows.Visibility _noteAdderVisibility = System.Windows.Visibility.Hidden;
        public System.Windows.Visibility NoteAdderVisibility
        {
            get { return _noteAdderVisibility; }
            set { _noteAdderVisibility = value; NotifyOfPropertyChange(() => NoteAdderVisibility); }
        }

        private string _noteAdderText;
        public string NoteAdderText
        {
            get { return _noteAdderText; }
            set { _noteAdderText = value; NotifyOfPropertyChange(() => NoteAdderText); }
        }


        private BindableCollection<NoteModel> _notes;
        public BindableCollection<NoteModel> Notes
        {
            get { return _notes; }
            set { _notes = value; NotifyOfPropertyChange(() => Notes); }
        }
        #endregion

        #region Constructor
        public NotesViewModel()
        {
            Notes = Globals.AllNotes;
        }
        #endregion

        #region Methods
        private void AddNote()
        {
            Globals.AddNoteToDb(NoteAdderText);
            Notes = Globals.AllNotes;
            NoteAdderText = "";
        }
        #endregion

        #region Button clicks
        public void AddNoteButton()
        {
            NoteAdderVisibility = System.Windows.Visibility.Visible;
        }
        #endregion

        #region Input
        public void AddNoteTextBox_PreviewKeyDown(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;

            if (keyArgs != null)
            {
                if (keyArgs.Key == Key.Enter)
                {
                    NoteAdderVisibility = System.Windows.Visibility.Hidden;
                    AddNote();
                }
            }
        }
        #endregion
    }
}
