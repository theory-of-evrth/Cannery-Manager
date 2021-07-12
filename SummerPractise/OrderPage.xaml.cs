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
        BindingList<Order> basket = new BindingList<Order>();
        double commonprice = 0;
        public OrderPage()
        {
            InitializeComponent();
            FillDataTables();
            AllGoods.IsReadOnly = true;
                Basket.ItemsSource = basket;

            basket.ListChanged += Basket_ListChanged;

        }

        private void Basket_ListChanged(object sender, ListChangedEventArgs e)
        {
            CalculatePrice();
        }

        void FillDataTables()
        {
            db = new StorageContext();
            db.Goods_In_Stocks.Load();
            AllGoods.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();

            db.Currencies.Load();
            currencyBox.ItemsSource = db.Currencies.Local.ToBindingList();
            currencyBox.SelectedIndex = 0;
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

                if (gridViewItem != null)
                {
                    Good_in_Stock good =
                   (Good_in_Stock)gridViewItem.Item;
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

                Currency currency = currencyBox.SelectedItem as Currency;
                Order order = new Order()
                {
                    user = db.Users.Find(Current_User.id),
                    obj = good,
                    date = DateTime.Now.ToString(),
                    price = Math.Round(good.rel_price / currency.rate, 3),
                    goods_num = 1,
                    currency = currency,
                };
                basket.Add(order);
                CalculatePrice();

            }
        }

        private void currencyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Currency currency = currencyBox.SelectedItem as Currency;
            foreach (Order order in basket)
            {
                order.currency = currency;
                order.price = Math.Round(order.obj.rel_price / currency.rate, 3);
            }
            Basket.ItemsSource = null;
            Basket.ItemsSource = basket;
            CalculatePrice();
        }

        private void AddOrder_Button(object sender, RoutedEventArgs e)
        {
            Currency currency = currencyBox.SelectedItem as Currency;

            Order[] arr = new Order[basket.Count];
            basket.CopyTo(arr, 0);
            db.Orders.AddRange(arr);
            db.SaveChanges();
            CalculatePrice();
            MessageBox.Show($"Вы совершили страшное преступление, к оплате {commonprice} {currency.txt}");

            basket.Clear();
            CalculatePrice();

        }
        void CalculatePrice()
        {
            commonprice = 0;
            foreach (Order order in basket)
            {
                commonprice += order.price;
            }
            priceText.Text = $"Общая сумма заказа: \n {commonprice}";
        }
    }
}
