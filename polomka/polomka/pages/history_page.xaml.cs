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
            Refresh();
        }
        public void Refresh()
        {
            IEnumerable<ClientService> history = App.db.ClientService.ToList();
            history_wp.Children.Clear();
            foreach (ClientService service in history)
            {
                history_wp.Children.Add(new history_uc(service));
            }
        }
    }
}
