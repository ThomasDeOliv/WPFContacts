using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFContacts.Windows
{
    /// <summary>
    /// Interaction logic for ContactsList.xaml
    /// </summary>
    public partial class ContactsList : Window
    {
        public ContactsList()
        {
            InitializeComponent();
            this.addContactButton.Click += _openAddContactWindow;
        }

        private void _openAddContactWindow(object sender, RoutedEventArgs e)
        {
            AddContact addContactWindow = new AddContact();
            addContactWindow.ShowDialog();
        }
    }
}
