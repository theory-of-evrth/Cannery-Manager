using SummerPractise.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SummerPractise
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        StorageContext db;
        BindingList<Good_in_Stock> basket = new BindingList<Good_in_Stock>();
        public OrderPage()
        {
            InitializeComponent();
            FillDataTables();
            AllGoods.IsReadOnly = true;
            Basket.ItemsSource = basket;
        }
        void FillDataTables()
        {
            db = new StorageContext();
            db.Goods_In_Stocks.Load();
            AllGoods.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllGoods_DragEnter(object sender, DragEventArgs e)
        {

        }

        private Point startPoint;

        private void dataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        private void List_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                DataGrid gridView = sender as DataGrid;
                DataGridRow gridViewItem =
                    FindAnchestor<DataGridRow>((DependencyObject)e.OriginalSource);


                Good_in_Stock good = 
                    (Good_in_Stock) gridView.SelectedItem;

                if (good != null && gridViewItem != null)
                {
                    DataObject dragData = new DataObject("myFormat", good);
                    DragDrop.DoDragDrop(gridViewItem, dragData, DragDropEffects.Move);
                }
            }
        }

        private static T FindAnchestor<T>(DependencyObject current)
    where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        private void DropList_DragEnter(object sender, DragEventArgs e)
        {

            if (!e.Data.GetDataPresent("myFormat") ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DropList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Good_in_Stock good = e.Data.GetData("myFormat") as Good_in_Stock;
                basket.Add(good);
                e.Handled = true;
            }
        }
    }
}
