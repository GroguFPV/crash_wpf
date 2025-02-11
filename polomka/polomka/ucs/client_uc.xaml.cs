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
            client_date_tb.Text = client.RegistrationDate.ToShortDateString();
        }
    }
}
