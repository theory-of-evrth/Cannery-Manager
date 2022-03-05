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
            chooseItem.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();
            good.ItemsSource = db.Goods_In_Stocks.Local.ToBindingList();
        }

        private void AddPendingGoods_Button(Object sender, RoutedEventArgs e)
        {
            if (CurrentUser.id == 666)
            {
                MessageBox.Show("Зачем администратору отправлять запросы самому себе? Пожалуйста, редактируйте всё, что хотите, напрямую.");
                return;
            }
            ProviderOffer provider_Offer = chooseProvider.SelectedItem as ProviderOffer;

            if (provider_Offer == null)
            {
                MessageBox.Show("Выберите предложение поставщика, которое вас заинтересовало.");
                return;
            }
            if (howmany.Text.Length == 0)
            {
                MessageBox.Show("Выберите количество товара, которое хотите приобрести.");
                return;
            }

            db.Changes.Add(new Change() {
                user = db.Users.Find(CurrentUser.id),
                type = "Добавление товара",
                obj=provider_Offer.obj,
                date= DateTime.Now.ToString(),
                approved=false,
                value = "-",
                new_value = howmany.Text,
            });
            db.SaveChanges();
            MessageBox.Show("Ваш запрос был отправлен на рассмотрение.");
        }
        private void DeletePendingGoods_Button(Object sender, RoutedEventArgs e)
        {
            if (CurrentUser.id == 666)
            {
                MessageBox.Show("Зачем администратору отправлять запросы самому себе? Пожалуйста, редактируйте всё, что хотите, напрямую.");
                return;
            }

            Good_in_Stock our_good = chooseItem.SelectedItem as Good_in_Stock;

            if (our_good == null)
            {
                MessageBox.Show("Выберите товар, который хотите удалить.");
                return;
            }
            if (howmany1.Text.Length == 0)
            {
                MessageBox.Show("Выберите количество товара, которое хотите удалить.");
                return;
            }

            _ = db.Changes.Add(new Change()
            {
                user = db.Users.Find(CurrentUser.id),
                type = "Удаление товара",
                obj = our_good,
                date = DateTime.Now.ToString(),
                approved = false,
                value = (our_good.num).ToString(),
                new_value = howmany1.Text,
            });

            db.SaveChanges();
            MessageBox.Show("Ваш запрос был отправлен на рассмотрение.");
        }
        private void EditPendingGoods_Button(Object sender, RoutedEventArgs e)
        {
            if (CurrentUser.id == 666)
            {
                MessageBox.Show("Зачем администратору отправлять запросы самому себе? Пожалуйста, редактируйте всё, что хотите, напрямую.");
                return;
            }

            Good_in_Stock our_good = good.SelectedItem as Good_in_Stock;

            if (our_good == null)
            {
                MessageBox.Show("Выберите товар, который хотите изменить.");
                return;
            }
            if (oldvalue.Text.Length == 0 || newvalue.Text.Length == 0)
            {
                MessageBox.Show("Напишите значение, которое собираетесь изменить.");
                return;
            }

            db.Changes.Add(new Change()
            {
                user = db.Users.Find(CurrentUser.id),
                type = "Изменение товара",
                obj = our_good,
                date = DateTime.Now.ToString(),
                approved = false,
                value = oldvalue.Text,
                new_value = newvalue.Text
            });
            db.SaveChanges();
            MessageBox.Show("Ваш запрос был отправлен на рассмотрение.");
        }
    }
}
