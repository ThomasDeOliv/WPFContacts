using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using WPFContacts.Datas.Models;

namespace WPFContacts.Datas
{
    public class DbBusiness
    {
        private string _dbPath;

        public DbBusiness()
        {
            // Name of the db file
            string dbName = "Contacts.db";

            // Name of the app
            string appName = "WPFContacts";

            // File to the db folder
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Create the folder if not exist
            Directory.CreateDirectory(Path.Combine(folderPath, appName));

            // Path to the db file
            _dbPath = Path.Combine(folderPath, appName, dbName);
        }

        public List<Contact> ReadAll()
        {
            List<Contact> contacts;

            using (SQLiteConnection connection = new SQLiteConnection(_dbPath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>()
                    .OrderBy(c => c.Name)
                    .ThenBy(c => c.FirstName)
                    .ToList();
            }

            return contacts;
        }

        public void Insert(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_dbPath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
        }

        public void Update(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_dbPath))
            {
                connection.Update(contact);
            }
        }

        public void Delete(Contact contact)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_dbPath))
            {
                connection.Delete(contact);
            }
        }
    }
}
