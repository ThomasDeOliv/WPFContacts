using System;
using System.Windows;
using System.Windows.Controls;
using WPFContacts.Datas.Models;

namespace WPFContacts.Controls
{
    /// <summary>
    /// Logique d'interaction pour ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public Contact DisplayedContact
        {
            get { return (Contact)GetValue(DisplayedContactProperty); }
            set { SetValue(DisplayedContactProperty, value); }
        }

        public static readonly DependencyProperty DisplayedContactProperty =
            DependencyProperty.Register(
                "DisplayedContact",
                typeof(Contact),
                typeof(ContactControl),
                new PropertyMetadata(null, (d, e) =>
                {
                    ContactControl contactControl = d as ContactControl;

                    if (contactControl is not null)
                    {
                        contactControl.DataContext = e.NewValue as Contact;
                    }
                })
            );

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
