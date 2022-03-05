using SummerPractise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Parser parser = new Parser();
            parser.FillListFromJSONToCurrentDayNBU();
            foreach(var cur in parser.GetCurrencyRatesNBU())
            {
                Currency currency = new Currency(cur);
                DataBaseRequester.MakeInsertRequestCurrency(currency);
            }
        }
        private void Button_Login(Object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string password = PassBox.Password;
            
        
            if (login == "root" && password == "root")
            {
                CurrentUser.id = 666;
                MainWindow MenuWIN = new MainWindow();
                MenuWIN.Content = new MenuPage();
                this.Close();
                MenuWIN.Show();
                /*
                //переход в админскую
                MessageBox.Show("Добро пожаловать, хозяин!");
                //var AdminPage = new AdminPage();
                //AdminPage.Show();
                MainWindow navWIN = new MainWindow();
                navWIN.Content = new AdminPage();
                navWIN.Show(); */
            }
        
            StorageContext db = new StorageContext();
            var users = db.Users;
            foreach (User u in users)
            {
                if (u.name == login && u.password == password)
                {
                    MessageBox.Show($"Успешный логин, человек с id {u.id}");
                    CurrentUser.id = u.id;
                    MainWindow MenuWIN = new MainWindow();
                    MenuWIN.Content = new MenuPage();
                    this.Close();
                    MenuWIN.Show();
                    /*
                    if (u.edit_permission)
                    {
                        //открыть окно(вкладку) редактирования
                        MessageBox.Show("Добро пожаловать в окно редактирования");
                        MainWindow EditWIN = new MainWindow();
                        EditWIN.Content = new EditPage();
                        EditWIN.Show();
                    }
                    if (u.order_permission)
                    {
                        //открыть окно(вкладку) заказа
                        MessageBox.Show("Добро пожаловать в окно заказа");
                        MainWindow OrderWIN = new MainWindow();
                        OrderWIN.Content = new OrderPage();
                        OrderWIN.Show();
                    }
                    else
                    {
                        //открыть финальное окно(вкладку)
                        MessageBox.Show("Добро пожаловать и до свидания");
                        MainWindow finalWIN = new MainWindow();
                        finalWIN.Content = new FinalWinXaml();
                        finalWIN.Show();
                    } */
                }  
            }
        }
    }
}
