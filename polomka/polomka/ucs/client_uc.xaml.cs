using polomka.db;
using polomka.pages;
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

namespace polomka.ucs
{
    /// <summary>
    /// Логика взаимодействия для client_uc.xaml
    /// </summary>
    public partial class client_uc : UserControl
    {
        Client client;
        public client_uc(Client _client)
        {
            InitializeComponent();
            client = _client;
            client_name_tb.Text = client.LastName;
            client_firstname_tb.Text = client.FirstName;
            client_patronymic_tb.Text = client.Patronymic;
            client_number_tb.Text = client.Phone.ToString();
            client_date_tb.Text = $"Регистрация: {client.RegistrationDate.ToShortDateString()}";
        }

        private void info_btn_Click(object sender, RoutedEventArgs e)
        {
            App.frame.MainFrame.Navigate(new client_info_page(client));
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            App.frame.MainFrame.Navigate(new add_edit_client_page(client));
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Клиент {client.LastName} удален!");
            App.db.Client.Remove(client);
            App.db.SaveChanges();
            App.frame.MainFrame.Navigate(new clients_list_page());
        }
    }
}
