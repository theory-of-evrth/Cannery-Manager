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
            db.Currencies.Load();


            FillUsersDataTable(); // заполнение таблицы пользователей
            FillChangesDataTable(); // заполнение таблицы изменений 
            FillProvidersDataTable(); // заполнение таблицы поставщиков
            FillGoodsDataTable(); // заполнение таблицы товаров
        }
        
        private void FillUsersDataTable()
        {
            db.Users.Load();
            UsersDataTable.ItemsSource = db.Users.Local.ToBindingList(); 
        }
        
        private void FillChangesDataTable()
        {
            db.Changes.Load();
            IQueryable<Change> changes = from change in db.Changes
                                         where change.approved == false
                                         select change;
            ObservableCollection<Change> changesCollection = new ObservableCollection<Change>(changes);
            ChangesDataTable.DataContext = changesCollection; 
        }
        
        private void FillProvidersDataTable()
        {
            db.Provider_Offers.Load();
            ProvidersDataTable.ItemsSource = db.Provider_Offers.Local.ToBindingList(); 
        }
        private void FillGoodsDataTable()
        {
            db.Goods_In_Stocks.Load();
            GoodsDataTable.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();
        }
        private void SaveButton_Click(Object sender, RoutedEventArgs e)
        { 
            db.SaveChanges();
        }
        private void SaveButtonApproves_Click(Object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            db.Changes.Load();
            foreach(var ch in db.Changes)
            {
                ApproveChange(ch);
            }
            FillChangesDataTable();
            FillGoodsDataTable();
        }


        private void ApproveChange(Change change)
        {
            if(change.approved == true)
            {
                if(change.type == "Добавление товара")
                {
                    try
                    {
                        if (db.Goods_In_Stocks.Find(change.obj.id) != null)
                        {
                            db.Goods_In_Stocks.Find(change.obj.id).num = Convert.ToInt32(change.new_value);
                        }
                        else
                        {
                            db.Add(change.obj);
                        }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else if(change.type == "Удаление товара")
                {
                    try
                    {
                        if (db.Goods_In_Stocks.Find(change.obj.id) != null)
                        {
                            db.Goods_In_Stocks.Find(change.obj.id).num = Convert.ToInt32(change.new_value);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else if(change.type == "Изменение товара")
                {
                    try
                    {
                        string[] changes = change.new_value.Split(':');
                        if (changes[0] == "name")
                        {
                            db.Goods_In_Stocks.Find(change.obj.id).name = changes[1];
                        }
                        else if(changes[0] == "price")
                        {
                            db.Goods_In_Stocks.Find(change.obj.id).rel_price = Convert.ToDouble(changes[1]);
                        }
                        else if (changes[0] == "description")
                        {
                            db.Goods_In_Stocks.Find(change.obj.id).description = changes[1];
                        }
                        else if (changes[0] == "num")
                        {
                            db.Goods_In_Stocks.Find(change.obj.id).num = Convert.ToInt32(changes[1]);
                        }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            db.SaveChanges();
        }
    }
}
