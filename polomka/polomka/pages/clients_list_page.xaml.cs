using polomka.db;
using polomka.ucs;
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

namespace polomka.pages
{
    /// <summary>
    /// Логика взаимодействия для clients_list_page.xaml
    /// </summary>
    public partial class clients_list_page : Page
    {
        public clients_list_page()
        {
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            IEnumerable<Client> clients = App.db.Client.ToList();
            client_wp.Children.Clear();
            foreach (Client c in clients)
            {
                client_wp.Children.Add(new client_uc(c));
            }
        }

    }
}
