using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec_97
{
    class DataAccess
    {
        //Initialize the SQLite database
        public  static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (userID INTEGER PRIMARY KEY, " +
                    "firstName NVARCHAR(20) NOT NULL, "+
                    "lastName NVARCHAR(20) NOT NULL, " +
                    "EMail NVARCHAR(20) NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        //Insert
        public static void AddData(string inputuserID, string inputfirstName, string inputlastName, string inputemail)
        {
            using (SqliteConnection db =
              new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Customers VALUES (@userID, @firstName, @lastName, @email);";
                insertCommand.Parameters.AddWithValue("@userID", inputuserID);
                insertCommand.Parameters.AddWithValue("@firstName", inputfirstName);
                insertCommand.Parameters.AddWithValue("@lastName", inputlastName);
                insertCommand.Parameters.AddWithValue("@email", inputemail);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        //Retrieve data from the SQLite database
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT userID, firstName, lastName, email from Customers", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }

                db.Close();
            }

            return entries;
        }
    }
}
