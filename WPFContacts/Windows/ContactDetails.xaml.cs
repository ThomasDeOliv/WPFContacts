using System;
using System.Windows;
using WPFContacts.Datas.Models;

namespace WPFContacts.Windows
{
    /// <summary>
    /// Page for update or delete a contact from the database
    /// </summary>
    public partial class ContactDetails : Window
    {
        public ContactDetails(Contact selectedContact)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            DataContext = selectedContact;

            this.updateContactButton.Click += _updateContact;
            this.deleteContactButton.Click += _deleteContact;
        }

        private void _updateContact(object sender, RoutedEventArgs e)
        {
            // Trying delete the selected contact and showing appropriate message
            try
            {
                Contact updatedContact = this.DataContext as Contact;

                updatedContact.Name = updatedContact.Name.Trim().ToUpper();
                updatedContact.FirstName = updatedContact.FirstName.Trim().ToUpper();
                updatedContact.Phone = updatedContact.Phone.Trim();
                updatedContact.Mail = updatedContact.Mail is not null? updatedContact.Mail.Trim().ToLower() : null;

                App.dbBusiness.Update(updatedContact);
                MessageBox.Show("Contact updated", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Closing the window
            this.Close();
        }

        private void _deleteContact(object sender, RoutedEventArgs e)
        {
            // Trying delete the selected contact and showing appropriate message
            try
            {
                Contact deletedContact = this.DataContext as Contact;
                App.dbBusiness.Delete(deletedContact);
                MessageBox.Show("Contact deleted from the database", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Closing the window
            this.Close();
        }
    }
}
