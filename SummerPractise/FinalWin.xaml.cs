using System.Collections.ObjectModel;
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
            
            Model.StorageContext storageContext = new Model.StorageContext();
            ObservableCollection<Model.Good_in_Stock> good_in_stocks = new ObservableCollection<Model.Good_in_Stock>(storageContext.Goods_In_Stocks);
            dataGrid1.DataContext = good_in_stocks;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



    }
}