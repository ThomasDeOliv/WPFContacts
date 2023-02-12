using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFContacts.Datas.Models;

namespace WPFContacts.Windows
{
    /// <summary>
    /// Page showing the list of contacts
    /// </summary>
    public partial class ContactsList : Window
    {
        public List<Contact> contacts;

        public Action<ListView, List<Contact>> RefreshListView = (listView, contacts) =>
        {
            contacts = new List<Contact>(App.dbBusiness.ReadAll());

            if (contacts is not null)
            {
                listView.ItemsSource = contacts;
            }
        };

        public ContactsList()
        {
            InitializeComponent();

            this.addContactButton.Click += _openAddContactWindow;
            this.searchContactTextBox.TextChanged += _filterContactsList;

            contacts = new List<Contact>(App.dbBusiness.ReadAll());

            if (contacts is not null)
            {
                this.contactsListView.ItemsSource = contacts;
            }
        }

        private void _openAddContactWindow(object sender, RoutedEventArgs e)
        {
            AddContact addContactWindow = new AddContact();
            addContactWindow.ShowDialog();
        }

        private void _filterContactsList(object sender, TextChangedEventArgs e)
        {
            Func<string, string, bool> _checkMailExistAndCorrespondingQuery = (string mail, string query) =>
            {
                if (!string.IsNullOrEmpty(mail))
                {
                    return mail.Contains(query, StringComparison.OrdinalIgnoreCase);
                }

                return false;
            };

            if(!string.IsNullOrWhiteSpace(this.searchContactTextBox.Text))
            {
                TextBox textBox = sender as TextBox;
                string query = textBox.Text.Trim();

                List<Contact> filtredContacts = contacts.Where(c => 
                    (c.FirstName + " " + c.Name).Contains(query, StringComparison.OrdinalIgnoreCase)
                    || c.Phone.Contains(query, StringComparison.OrdinalIgnoreCase)
                    || _checkMailExistAndCorrespondingQuery(c.Mail, query)

                ).ToList();

                this.contactsListView.ItemsSource = filtredContacts;
            }
            else
            {
                this.contactsListView.ItemsSource = contacts;
            }
        }
    }
}
