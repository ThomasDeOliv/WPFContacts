using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using WPFContacts.Datas.Models;

namespace WPFContacts.Datas
{
    public class DbContext
    {
        private string _dbPath;

        public DbContext()
        {
            string dbName = "Contacts.db";
            string appName = "WPFContacts";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _dbPath = Path.Combine(folderPath, appName, dbName);
        }

        public List<Contact> ReadAll()
        {
            List<Contact> contacts;

            using (SQLiteConnection connection = new SQLiteConnection(_dbPath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
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
    }
}
