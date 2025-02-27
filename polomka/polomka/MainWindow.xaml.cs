using System;
using System.Collections.Generic;
using System.IO;
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
using polomka.pages;

namespace polomka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.frame = this;
            MainFrame.Navigate(new history_page());

            //var path = @"C:\Users\Ahat\Desktop\Поломка\данные\Клиенты\";
            //foreach (var item in App.db.Client.ToArray())
            //{
            //    var fullPath = path + item.PhotoPath;
            //    item.image_bin = File.ReadAllBytes(fullPath);
            //}
            //App.db.SaveChanges();


        }



        private void history_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new history_page());
        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new clients_list_page());
        }
    }
}
