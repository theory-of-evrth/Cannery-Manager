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

namespace SummerPractise
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            Model.StorageContext storageContext = new Model.StorageContext();
            ObservableCollection<Model.User> users = new ObservableCollection<Model.User>(storageContext.Users);
            Users.DataContext = users;
        }

        private void AddUser_Button(Object sender, RoutedEventArgs e)
        {

        }
    }
}
