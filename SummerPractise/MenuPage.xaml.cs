using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SummerPractise;
using SummerPractise.Model;

namespace SummerPractise
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        readonly StorageContext db;

        public MenuPage()
        {
            InitializeComponent();
        }

        private void ToFinal_Button(Object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"Успешный логин, человек с id {CurrentUser.id}");
            MainWindow finalWIN = new MainWindow();
            finalWIN.Content = new FinalWinXaml();
            finalWIN.Show();
        }
        private void Admin_Button(Object sender, RoutedEventArgs e)
        {
            if (CurrentUser.id == 666)
            {
                MainWindow navWIN = new MainWindow();
                navWIN.Content = new AdminPage();
                navWIN.Show();
            } 
            else
            {
                MessageBox.Show("Извините, но у вас нет админских прав!");
            }
        }
        private void ToEdit_Button(Object sender, RoutedEventArgs e)
        {
            if (CurrentUser.id == 666)
            {
                MainWindow EditWIN = new MainWindow();
                EditWIN.Content = new EditPage();
                EditWIN.Show();
            }

            StorageContext db = new StorageContext();
            var users = db.Users;
            foreach (User u in users)
            {
                if (u.id == CurrentUser.id)
                {
                    if (u.edit_permission)
                    {
                        MainWindow EditWIN = new MainWindow();
                        EditWIN.Content = new EditPage();
                        EditWIN.Show();
                    }
                    else
                    {
                        MessageBox.Show("Извините, но у вас нет прав на редактирование! Кажется, вы не бухгалтер, чтобы сюда заходить.");
                    }
                }
            }
        }

        private void Order_Button(Object sender, RoutedEventArgs e)
        {
            if (CurrentUser.id == 666)
            {
                MainWindow OrderWIN = new MainWindow();
                OrderWIN.Content = new OrderPage();
                OrderWIN.Show();
            }

            StorageContext db = new StorageContext();
            var users = db.Users;
            foreach (User u in users)
            {
                if (u.id == CurrentUser.id)
                {
                    if (u.edit_permission)
                    {
                        MainWindow OrderWIN = new MainWindow();
                        OrderWIN.Content = new OrderPage();
                        OrderWIN.Show();
                    }
                    else
                    {
                        MessageBox.Show("Извините, но у вас нет прав на оформление заказов!");
                    }
                }
            }
        }
    }
}
