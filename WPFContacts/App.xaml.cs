using System.Windows;
using WPFContacts.Datas;
using WPFContacts.Windows;

namespace WPFContacts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DbBusiness dbBusiness;
        public static ContactsList mainWindow;

        public App()
        {
            dbBusiness = new DbBusiness();
        }

        private void AppStartup(object sender, StartupEventArgs e)
        {
            mainWindow = new ContactsList();
            mainWindow.Show();
        }
    }
}
