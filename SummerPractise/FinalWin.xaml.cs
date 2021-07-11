using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using SummerPractise.Model;

namespace SummerPractise
{
    //public class DataObject
    //{
    //    public int A { get; set; }
    //    public int B { get; set; }
    //    public int C { get; set; }
    //}
    public partial class FinalWinXaml : Page
    {
        public FinalWinXaml()
        {
            InitializeComponent();
            // var list = new ObservableCollection<DataObject>();
            // list.Add(new DataObject() { A = 0, B = 0, C = 0 });
            //list.Add(new DataObject() { A = 0, B = 0, C = 0 });
            //  list.Add(new DataObject() { A = 0, B = 0, C = 0 });
            // this.dataGrid1.ItemsSource = list; 
            

            StorageContext db = new StorageContext();
            ObservableCollection<Good_in_Stock> good_in_stocks = 
                new ObservableCollection<Good_in_Stock>(
                    db.Goods_In_Stocks
                );
            dataGrid1.DataContext = good_in_stocks;

            db.Currencies.Load();
            db.Orders.Load();
            ordersGridView.ItemsSource = db.Orders.Local.ToBindingList();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



    }
}