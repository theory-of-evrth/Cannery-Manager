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
        }

        private void FillDateTables()
        {
            db = new StorageContext();
            db.Goods_In_Stocks.Load();
            db.Users.Load();
            Goods_Datagrid.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();
            db.Provider_Offers.Load();
            ProviderOffers_Datagrid.ItemsSource = db.Provider_Offers.Local.ToBindingList();

            chooseProvider.ItemsSource = db.Provider_Offers.Local.ToBindingList();
        }
        private void products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void AddPendingGoods_Button(Object sender, RoutedEventArgs e)
        {
            if (Current_User.id == 666)
            {
                MessageBox.Show("Вы дебил чтоли!!!!! Ц ц ц ц!!!");
                return;
            }
            Provider_Offer provider_Offer = chooseProvider.SelectedItem as Provider_Offer;

            db.Changes.Add(new Change() {
                user = db.Users.Find(Current_User.id),
                type = "Добавление товара",
                obj=provider_Offer.obj,
                date= DateTime.Now.ToString(),
                approved=false,
                value = "-",
                new_value = howmany.Text,
            });
            db.SaveChanges();
            MessageBox.Show("Я вас добавил. А теперь нахер идите!!!!!");
        }
        private void DeletePendingGoods_Button(Object sender, RoutedEventArgs e)
        {
        }
        private void EditPendingGoods_Button(Object sender, RoutedEventArgs e)
        {
        }
    }
}
