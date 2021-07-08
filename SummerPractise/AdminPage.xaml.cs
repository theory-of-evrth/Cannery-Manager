using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SummerPractise.Model;

namespace SummerPractise
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        StorageContext db;
        public AdminPage()
        {
            InitializeComponent();
            db = new StorageContext();
            db.Users.Load();
            Users.ItemsSource = db.Users.Local.ToBindingList();
        }

        private void AddUser_Button(Object sender, RoutedEventArgs e)
        {
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
