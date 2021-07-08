using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Linq;
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
            FillDateTables();
        }

        private void FillDateTables()
        {
            db = new StorageContext();
            //ObservableCollection<User> users = new ObservableCollection<User>(storageContext.Users);
            //UsersDataTable.DataContext = users;
            db.Users.Load();
            UsersDataTable.ItemsSource = db.Users.Local.ToBindingList();
            
            IQueryable<Change> changes = from change in db.Changes
                                               where change.approved == false
                                               select change;
            //db.Changes.Load();
            //ChangesDataTable.ItemsSource = changes;
            ObservableCollection<Model.Change> changesCollection = new ObservableCollection<Model.Change>(changes);
            ChangesDataTable.DataContext = changesCollection;

            db.Provider_Offers.Load();
            ProvidersDataTable.ItemsSource = db.Provider_Offers.Local.ToBindingList();
            //ObservableCollection<Provider_Offer> provider_Offers = new ObservableCollection<Provider_Offer>(db.Provider_Offers);
            //ProvidersDataTable.DataContext = provider_Offers;
        }
        private void SaveButton_Click(Object sender, RoutedEventArgs e)
        { 
            db.SaveChanges();
        }
    }
}
