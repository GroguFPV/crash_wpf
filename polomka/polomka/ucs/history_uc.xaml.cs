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
    /// Логика взаимодействия для history_uc.xaml
    /// </summary>
    public partial class history_uc : UserControl
    {
        public history_uc(ClientService history)
        {
            InitializeComponent();
            var c = App.db.Client.FirstOrDefault(x => x.ID == history.ClientID);
            client_name_tb.Text = c.LastName;
            client_firstname_tb.Text = c.FirstName;
            client_patronymic_tb.Text = c.Patronymic;
            var s = App.db.Service.FirstOrDefault(x => x.ID == history.ServiceID);
            service_name_tb.Text = s.Title;

            service_date_tb.Text = $"Дата: {history.StartTime.ToShortDateString()}";
            service_time_tb.Text = $"Время: {history.StartTime.ToShortTimeString()}";

        }
    }
}
