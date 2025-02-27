using polomka.db;
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

namespace polomka.pages
{
    /// <summary>
    /// Логика взаимодействия для client_info_page.xaml
    /// </summary>
    public partial class client_info_page : Page
    {
        Client c;
        public client_info_page(Client _client)
        {
            InitializeComponent();
            c = _client;


            client_fullname_tb.Text = $"{c.FirstName} {c.LastName} {c.Patronymic}";


            client_image.Source = GetImageSources(c.image_bin);

            date_tb.Text = $"Дата рождения: {c.Birthday.Value.ToShortDateString()}";


            phone_number.Text = $"Номер: {c.Phone.ToString()}"; ;
            reg_tb.Text = $"Дата регистрации: {c.RegistrationDate.ToShortDateString()}";
            email.Text = $"Почта: {c.Email}";


        }
        private BitmapImage GetImageSources(byte[] byteImage)
        {
            if (byteImage != null)
            {
                MemoryStream byteStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                return image;
            }
            return new BitmapImage(new Uri(@"images\logo.png", UriKind.Relative));

        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new clients_list_page());
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new add_edit_client_page(c));
        }

        private void delbtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Клиент {c.LastName} удален!");
            App.db.Client.Remove(c);
            App.db.SaveChanges();
            App.frame.MainFrame.Navigate(new clients_list_page());
        
    }
    }
}
