
using SummerPractise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace SummerPractise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StorageContext db = new StorageContext();
            
            //    // создаем два объекта User
            //User user1 = new User { id = 1, name = "Kolya", password = "Nikolay" };
            //User user2 = new User { id = 2, name = "Sam", password = "1234567890" };
            //User user1 = new User { id = 3, name = "Kolya", password = "Nikolay" };
            //User user2 = new User { id = 4, name = "Sam", password = "1234567890" };
            
            //    // добавляем их в бд
            //db.Users.Add(user1);
            //db.Users.Add(user2);
            //db.SaveChanges();

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.id == 4)
                    MessageBox.Show($"{u.id}.{u.name} - {u.password}");
                }

        }
        private void Button_Login(Object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text;
            string password = passwordBox.Password;

            StorageContext db = new StorageContext();
            var users = db.Users;
            foreach (User u in users)
            {
                if (u.name == login && u.password == password)
                    MessageBox.Show($"Успешный логин, человек с id {u.id}");
            }
        }
    }
}
