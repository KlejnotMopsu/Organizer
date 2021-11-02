using Caliburn.Micro;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Organizer.Models
{
    public static class DataAcces
    {
        /// <summary>
        /// Get SqlConnection for more direct operaions
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            try
            {
                string cn_string = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                SqlConnection _out = new SqlConnection(cn_string);

                if (_out.State != ConnectionState.Open)
                    _out.Open();

                return _out;
            }
            catch (Exception e)
            {

                System.Windows.MessageBox.Show("Unable to connect with database.");
                Environment.Exit(1);
                return null;

            }
        }

        #region Getting data with Dapper
        /// <summary>
        /// Gets all notes from database
        /// </summary>
        /// <returns></returns>
        public static BindableCollection<NoteModel> GetNotesFromDb()
        {
            BindableCollection<NoteModel> OutV = new BindableCollection<NoteModel>();
            List<NoteModel> DbGetterList = new List<NoteModel>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DbGetterList = db.Query<NoteModel>("SELECT * FROM NOTES").ToList();
            }

            foreach (NoteModel n in DbGetterList)
            {
                OutV.Add(n);
            }

            return OutV;
        }

        /// <summary>
        /// Gets all daily chores from database
        /// </summary>
        /// <returns></returns>
        public static BindableCollection<DailyChoreModel> GetDailyChoresFromDb()
        {
            BindableCollection<DailyChoreModel> OutV = new BindableCollection<DailyChoreModel>();
            List<DailyChoreModel> DbGetterList = new List<DailyChoreModel>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DbGetterList = db.Query<DailyChoreModel>("SELECT * FROM DAILY_CHORES").ToList();
            }

            foreach (DailyChoreModel n in DbGetterList)
            {
                OutV.Add(n);
            }

            return OutV;
        }
        #endregion

        #region Inserting data with Dapper
        public static void InsertNote(string noteContent)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("INSERT INTO NOTES(Content) VALUES(@content)", new { content = noteContent });
            }
        }
        #endregion

        #region Deleting data with Dapper
        /// <summary>
        /// This method only calls <ref>DeleteNote(int)</ref>
        /// </summary>
        /// <param name="noteModel">Note for deletion</param>
        public static void DeleteNote(NoteModel noteModel)
        {
            DeleteNote(noteModel.Id);
        }

        /// <summary>
        /// Deletes note from Database
        /// </summary>
        /// <param name="noteId"></param>
        public static void DeleteNote(int noteId)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("DELETE FROM NOTES WHERE Id = @id", new { id = noteId });
            }
        }
        #endregion

        #region Updating data with Dapper
        public static void SwitchHighlight(NoteModel noteModel)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                var param = new { id = noteModel.Id,
                                  value = !noteModel.Is_highlighted};
                string query = "UPDATE NOTES " +
                               "SET Is_highlighted = @value " +
                               "WHERE Id = @id ";

                connection.Execute(query, param);
            }
        }
        #endregion
    }
}
