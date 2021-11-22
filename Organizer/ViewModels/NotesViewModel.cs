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
    public class NotesViewModel : Conductor<object>.Collection.AllActive
    {
        #region Properties
        //Notes models
        private BindableCollection<NoteModel> _notes;
        public BindableCollection<NoteModel> Notes
        {
            get { return _notes; }
            set { _notes = value; NotifyOfPropertyChange(() => Notes); }
        }

        //Notes view model for display in view
        private BindableCollection<NoteEntryUserControlViewModel> _notesViewModels;
        public BindableCollection<NoteEntryUserControlViewModel> NotesViewModels
        {
            get { return _notesViewModels; }
            set { _notesViewModels = value; NotifyOfPropertyChange(() => NotesViewModels); }
        }

        //NoteAdder visibility
        private System.Windows.Visibility _noteAdderVisibility;
        public System.Windows.Visibility NoteAdderVisibility
        {
            get { return _noteAdderVisibility; }
            set { _noteAdderVisibility = value; NotifyOfPropertyChange(() => NoteAdderVisibility); }
        }

        //NoteAdder text
        private string _noteAdderText;
        public string NoteAdderText
        {
            get { return _noteAdderText; }
            set { _noteAdderText = value; NotifyOfPropertyChange(() => NoteAdderText); Console.WriteLine(NoteAdderText); }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// NotesViewModel constructor
        /// </summary>
        public NotesViewModel()
        {
            NoteAdderVisibility = System.Windows.Visibility.Hidden;
            Notes = DataAcces.GetNotesFromDb();
            GenerateViewModels();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds new note based on <see cref="NoteAdderText"/>,
        /// adds it to <see cref="Notes"/>
        /// and generates new <see cref="NotesViewModels"/> entry.
        /// </summary>
        private void AddNote()
        {
            NoteModel newNote = DataAcces.InsertNote(NoteAdderText);
            Notes.Add(newNote);
            NotesViewModels.Add(new NoteEntryUserControlViewModel(newNote));
        }

        /// <summary>
        /// Deletes all data in <see cref="NotesViewModels"/> and creates new view models based on <see cref="Notes"/>
        /// </summary>
        private void GenerateViewModels()
        {
            NotesViewModels = new BindableCollection<NoteEntryUserControlViewModel>();
            foreach (NoteModel note in Notes)
            {
                NotesViewModels.Add(new NoteEntryUserControlViewModel(note));
            }
        }

        /// <summary>
        /// Changes <see cref="NoteAdderVisibility"/> to Visible and focuses on <see cref="Views.NotesView.NoteAdderText"/>
        /// in <see cref="Views.NotesView"/>
        /// </summary>
        private void BringUpNoteAdder()
        {
            NoteAdderVisibility = System.Windows.Visibility.Visible;
            ( (Views.NotesView)GetView() ).NoteAdderText.Focus();
        }
        #endregion

        #region Button clicks
        /// <summary>
        /// Code for <see cref="Views.NotesView.AddNoteButton"/> click
        /// </summary>
        public void AddNoteButton()
        {
            BringUpNoteAdder();
        }
        #endregion

        #region Input
        /// <summary>
        /// Code for PreviewKeyDown in <see cref="Views.NotesView.NoteAdderText"/>
        /// </summary>
        /// <param name="context"></param>
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
