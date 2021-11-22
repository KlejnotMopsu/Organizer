﻿using Caliburn.Micro;
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
                n.Is_accomplished_today = FindDailyChoreAccomplishment(n.Id);
                OutV.Add(n);
            }

            return OutV;
        }

        /// <summary>
        /// Gets all reminders from database
        /// </summary>
        /// <returns></returns>
        public static BindableCollection<ReminderModel> GetRemindersFromDb()
        {
            BindableCollection<ReminderModel> OutV = new BindableCollection<ReminderModel>();
            List<ReminderModel> DbGetterList = new List<ReminderModel>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                DbGetterList = db.Query<ReminderModel>("SELECT * FROM REMINDERS").ToList();
            }

            foreach (ReminderModel n in DbGetterList)
            {
                OutV.Add(n);
            }

            return OutV;
        }
        #endregion

        #region Inserting data with Dapper
        /// <summary>
        /// Inserts note to database
        /// </summary>
        /// <param name="noteContent">Contents of the note</param>
        public static NoteModel InsertNote(string noteContent)
        {
            NoteModel OutV = null;

            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("INSERT INTO NOTES(Content) VALUES(@content)", new { content = noteContent });

                try
                {
                    OutV = connection.QuerySingleOrDefault<NoteModel>("SELECT TOP 1 * FROM NOTES ORDER BY Id DESC");
                }
                catch
                {
                    Console.WriteLine("ERROR: Could not get newly added note in DataAcces.InsertNote()");
                }
            }            

            return OutV;
        }

        /// <summary>
        /// Inserts reminder into database
        /// </summary>
        /// <param name="reminderDescription">Reminder Description</param>
        /// <param name="remindDate">Reminder date and time of firing</param>
        public static void InsertReminder(string reminderDescription, DateTime remindDate)
        {
            using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                connection.Execute("INSERT INTO REMINDERS(Description, Remind_date) VALUES(@content, @dateandtime)",
                    new {
                        content = reminderDescription,
                        dateandtime = remindDate
                    });
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

        #region Helpers
        public static bool FindDailyChoreAccomplishment(int choreId)
        {
            bool OutV = false;

            int? checker = null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string query = "SELECT d.Id FROM CHORES_DAYS cd " +
                    "JOIN DAYS d ON d.Id = cd.Id_day " +
                    "WHERE cd.Id_chore = @cid " +
                    "AND d.Date = getdate()";

                var param = new { cid = choreId };

                checker = db.QuerySingleOrDefault<int?>(query, param);
            }

            if (checker != null)
                OutV = true;

            return OutV;
        }
        #endregion
    }
}
