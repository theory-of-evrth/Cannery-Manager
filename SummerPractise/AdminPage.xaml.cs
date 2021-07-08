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
using System.Linq;

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
            FillDateTables();
        }

        private void FillDateTables()
        {
            Model.StorageContext storageContext = new Model.StorageContext();
            ObservableCollection<Model.User> users = new ObservableCollection<Model.User>(storageContext.Users);
            UsersDataTable.DataContext = users;

            IQueryable<Model.Change> changes = from change in storageContext.Changes
                                               where change.approved == false
                                               select change;
            ObservableCollection<Model.Change> changesCollection = new ObservableCollection<Model.Change>(changes);
            ChangesDataTable.DataContext = changesCollection;
        }
        private void AddUser_Button(Object sender, RoutedEventArgs e)
        {

        }
    }
}
