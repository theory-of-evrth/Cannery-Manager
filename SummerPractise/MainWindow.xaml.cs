using SummerPractise.Model;
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
        }
        private void Button_Login(Object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string password = PassBox.Password;

            if (login == "root" && password == "root")
            {
                //переход в админскую
                MessageBox.Show("Добро пожаловать, хозяин!");

            }

            StorageContext db = new StorageContext();
            var users = db.Users;
            foreach (User u in users)
            {
                if (u.name == login && u.password == password)
                {
                    MessageBox.Show($"Успешный логин, человек с id {u.id}");

                    if (u.edit_permission)
                    {
                        //открыть окно(вкладку) редактирования
                        MessageBox.Show("Добро пожаловать в окно редактирования");
                    }
                    else if (u.order_permission)
                    {
                        //открыть окно(вкладку) заказа
                        MessageBox.Show("Добро пожаловать в окно заказа");
                    }
                    else
                    {
                        //открыть финальное окно(вкладку)
                        MessageBox.Show("Добро пожаловать и до свидания");
                    }
                }  
            }
        }
    }
}
