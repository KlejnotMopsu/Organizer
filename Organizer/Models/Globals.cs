using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Organizer.Models
{
    public static class Globals
    {
        #region App configs
        public static Color NoteHighlightBrush = Colors.Red;
        #endregion

        #region Properties
        public static BindableCollection<NoteModel> AllNotes;
        #endregion

        #region Methods
        public static void InitializeGlobals()
        {
            AllNotes = DataAcces.GetNotesFromDb();
        }

        public static void AddNoteToDb(string noteContent)
        {
            DataAcces.InsertNote(noteContent);
            AllNotes = DataAcces.GetNotesFromDb();
        }

        public static void DeleteNote(NoteModel noteModel)
        {
            DataAcces.DeleteNote(noteModel);
            AllNotes.Remove(noteModel);
        }
        #endregion
    }
}
