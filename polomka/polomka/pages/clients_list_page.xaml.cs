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

            RegDate.SelectedIndex = 0;

            Refresh();
        
        }
        public void Refresh()
        {
            if (client_wp == null) return;
            string searchText = search_tb.Text.ToLower().Trim();


            IEnumerable<Client> clients = App.db.Client.OrderBy(c => c.FirstName);
            if (!string.IsNullOrEmpty(searchText))
            {
                clients = clients.Where(c =>
                    c.LastName.ToLower().Contains(searchText) ||
                    c.FirstName.ToLower().Contains(searchText) ||
                    (c.Patronymic != null && c.Patronymic.ToLower().Contains(searchText))
                );
            }
            if (RegDate.SelectedIndex == 1)
            {
                clients = clients.OrderByDescending(c => c.RegistrationDate);
            }
            else if (RegDate.SelectedIndex == 2)
            {
                clients = clients.OrderBy(c => c.RegistrationDate);
            }

            client_wp.Children.Clear();
            foreach (Client c in clients)
            {
                client_wp.Children.Add(new client_uc(c));
            }
        }




        private void new_c_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new add_edit_client_page(new Client()));
        }

        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void RegDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
