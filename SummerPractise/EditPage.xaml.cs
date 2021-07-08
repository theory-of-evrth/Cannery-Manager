using SummerPractise.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

//global current_login;

namespace SummerPractise
{
    
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        StorageContext db;
        public EditPage()
        {
            InitializeComponent();
            FillDateTables();
            chooseProvider.ItemsSource = typeof(Provider_Offer).GetProperties();
        }

        private void FillDateTables()
        {
            db = new StorageContext();
            db.Goods_In_Stocks.Load();
            db.Users.Load();
            Goods_Datagrid.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();
            db.Provider_Offers.Load();
            ProviderOffers_Datagrid.ItemsSource = db.Provider_Offers.Local.ToBindingList();
        }
        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void AddPendingGoods_Button(Object sender, RoutedEventArgs e)
        {
        }
        private void DeletePendingGoods_Button(Object sender, RoutedEventArgs e)
        {
        }
        private void EditPendingGoods_Button(Object sender, RoutedEventArgs e)
        {
        }
    }
}
