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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using polomka.db;

namespace polomka.pages
{
    /// <summary>
    /// Логика взаимодействия для add_edit_client_page.xaml
    /// </summary>
    public partial class add_edit_client_page : Page
    {
        Client client;
        public add_edit_client_page(Client _client)
        {
            InitializeComponent();
            client = _client;
            this.DataContext = client;

            var genderlist = App.db.Gender.ToList();
            gender_cb.ItemsSource = genderlist;
            gender_cb.DisplayMemberPath = "Name";
            
            if (client != null)
            {
                
                gender_cb.SelectedItem = genderlist.FirstOrDefault(x => x.Code == client.GenderCode);

                if (client.image_bin != null)
                {
                    using (var stream = new MemoryStream(client.image_bin))
                    {
                        var image = new BitmapImage();
                        image.BeginInit();
                        image.StreamSource = stream;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                        c_image.Source = image;
                    }
                }
            }


        }
        
        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new clients_list_page());
        }

        private void add_image_btn_Click(object sender, RoutedEventArgs e)
        {
            Photo();
            App.db.SaveChanges();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            var genderItem = gender_cb.SelectedItem as Gender;
            var birthday = birthday_dp.SelectedDate;

            if (string.IsNullOrWhiteSpace(fisrtname_tb.Text) ||
                string.IsNullOrWhiteSpace(lastname_tb.Text) ||
                string.IsNullOrWhiteSpace(patronymic_tb.Text) ||
                string.IsNullOrWhiteSpace(phone_tb.Text) ||
                string.IsNullOrWhiteSpace(email_tb.Text) ||
                genderItem == null || 
                birthday == null)  
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            string genderCode = genderItem.Code.ToString() == "Мужской" ? "1" : "2";

            if (client.ID == 0)
            {
                var c = new Client
                {
                    FirstName = fisrtname_tb.Text,
                    LastName = lastname_tb.Text,
                    Patronymic = patronymic_tb.Text,
                    Phone = phone_tb.Text,
                    Email = email_tb.Text,
                    RegistrationDate = DateTime.Now,
                    Birthday = birthday.Value,
                    GenderCode = genderCode
                };
                App.db.Client.Add(c);
                MessageBox.Show("Клиент успешно добавлен!");

            }
            else
            {
                client.GenderCode = genderCode;
            }


            App.db.SaveChanges();
            
            NavigationService.Navigate(new clients_list_page());
        }
        private byte[] Photo()
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                var filePath = openFile.FileName;
                client.image_bin = File.ReadAllBytes(filePath);
                c_image.Source = new BitmapImage(new Uri(filePath));
            }
            return client.image_bin;
        }

    }
}
