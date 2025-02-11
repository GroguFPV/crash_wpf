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
            client_name_tb.Text = c.FirstName;
        }
    }
}
