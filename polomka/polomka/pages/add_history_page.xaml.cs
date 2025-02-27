using polomka.db;
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
    /// Логика взаимодействия для add_history_page.xaml
    /// </summary>
    public partial class add_history_page : Page
    {
        public add_history_page()
        {
            InitializeComponent();
            date_dp.IsEnabled = false;
            date_dp.SelectedDate = DateTime.Today;

            Client_cb.ItemsSource = App.db.Client
                .ToList()  // Загружаем данные в память
                .Select(c => new { FullName = $"{c.FirstName} {c.LastName} {c.Patronymic}", Client = c })
                .OrderBy(c => c.FullName) // Сортируем по ФИО
                .ToList();

            Client_cb.DisplayMemberPath = "FullName";

            service_cb.ItemsSource = App.db.Service.ToList().OrderBy(c => c.Title);
            service_cb.DisplayMemberPath = "Title";
        }

        private void add_new_c_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new add_edit_client_page(new Client()));
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Client_cb.SelectedItem != null && service_cb.SelectedItem != null)
            {
                var selectedClient = (Client_cb.SelectedItem as dynamic)?.Client;
                var selectedService = service_cb.SelectedItem as Service;

                if (selectedClient != null && selectedService != null)
                {
                    ClientService newRecord = new ClientService
                    {
                        ClientID = selectedClient.ID,   
                        ServiceID = selectedService.ID, 
                        StartTime = DateTime.Now        
                    };

                    App.db.ClientService.Add(newRecord);
                    App.db.SaveChanges();  

                    MessageBox.Show("Запись добавлена!");
                    NavigationService.Navigate(new history_page()); 
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать клиента и услугу!");
            }
        }

    }
}
