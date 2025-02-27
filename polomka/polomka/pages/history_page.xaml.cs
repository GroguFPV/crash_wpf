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
using polomka.db;
using polomka.ucs;

namespace polomka.pages
{
    /// <summary>
    /// Логика взаимодействия для history_page.xaml
    /// </summary>
    public partial class history_page : Page
    {
        public history_page()
        {
            InitializeComponent();
            ServiceCb.SelectedIndex = 0;
            Refresh();
        }
        public void Refresh()
        {
            if (history_wp == null) return;
            IEnumerable<ClientService> history = App.db.ClientService.ToList().OrderBy(c => c.StartTime).OrderBy(c => c.Client.FirstName);
            var searchText = search_tb.Text.ToLower();

            if (!string.IsNullOrEmpty(searchText))
            {
                history = history.Where(p => p.Client.LastName.ToLower().Contains(searchText)
                || p.Client.FirstName.ToLower().Contains(searchText)
                || p.Client.Patronymic.ToLower().Contains(searchText)


                );
            }
            if (ServiceCb.SelectedIndex == 1)
            {
                history = history.OrderByDescending(h => h.StartTime);
            }
            else if (ServiceCb.SelectedIndex == 2)
            {
                history = history.OrderBy(h => h.StartTime);
            }


            
            history_wp.Children.Clear();
            foreach (ClientService service in history)
            {
                history_wp.Children.Add(new history_uc(service));
            }
        }

        private void search_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddNeH_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new add_history_page());
        }

        private void ServiceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
