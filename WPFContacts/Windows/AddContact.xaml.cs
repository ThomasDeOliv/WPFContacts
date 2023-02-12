using System;
using System.Collections.Generic;
using System.Windows;
using WPFContacts.Datas.Models;

namespace WPFContacts.Windows
{
    /// <summary>
    /// Page for adding contact to the database
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
            this.createContactButton.Click += _createContactAndCloseWindow;
        }

        private void _createContactAndCloseWindow(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.nameField.Text) && !string.IsNullOrWhiteSpace(this.firstnameField.Text) && !string.IsNullOrWhiteSpace(this.phoneField.Text))
            {
                // Instanciate a new contact object
                Contact newContact = new Contact()
                {
                    Name = this.nameField.Text.Trim().ToUpper(),
                    FirstName = this.firstnameField.Text.Trim().ToUpper(),
                    Phone = this.phoneField.Text.Trim(),
                    Mail = !string.IsNullOrWhiteSpace(this.mailField.Text) ? this.mailField.Text.Trim().ToLower() : null,
                };

                try
                {
                    // Inserting to the database
                    App.dbBusiness.Insert(newContact);
                    MessageBox.Show("Contact added to the database", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // Update the current listview
                App.mainWindow.RefreshListView(App.mainWindow.contactsListView, App.mainWindow.contacts);

                // Close the window
                this.Close();
            }
        }
    }
}
