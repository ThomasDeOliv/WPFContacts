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

        public App()
        {
            dbBusiness = new DbBusiness();
        }
    }
}
