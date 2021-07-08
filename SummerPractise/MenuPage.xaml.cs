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
            
            MessageBox.Show($"Успешный логин, человек с id {Current_User.id}");
            MainWindow finalWIN = new MainWindow();
            finalWIN.Content = new FinalWinXaml();
            finalWIN.Show();
        }
        private void Admin_Button(Object sender, RoutedEventArgs e)
        {
            MainWindow navWIN = new MainWindow();
            navWIN.Content = new AdminPage();
            navWIN.Show();
        }
        private void ToEdit_Button(Object sender, RoutedEventArgs e)
        {
            MainWindow EditWIN = new MainWindow();
            EditWIN.Content = new EditPage();
            EditWIN.Show();
        }

        private void Order_Button(Object sender, RoutedEventArgs e)
        {
            MainWindow OrderWIN = new MainWindow();
            OrderWIN.Content = new OrderPage();
            OrderWIN.Show();
        }
    }
}
