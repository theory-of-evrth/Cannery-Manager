using SummerPractise.Model;
using System;
using System.Windows;

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
           // DataBaseRequester dataBaseRequester = new DataBaseRequester();
            
            //Parser parser = new Parser();
            //parser.FillListFromJSONToCurrentDayNBU();
            //foreach(var cur in parser.GetCurrencyRatesNBU())
           // {
            //    Model.Currency currency = new Model.Currency(cur);
             //   dataBaseRequester.MakeInsertRequest<Model.Currency>(currency);
            //}
            
        }
        private void Button_Login(Object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string password = PassBox.Password;

            if (login == "root" && password == "root")
            {
                //переход в админскую
                MessageBox.Show("Добро пожаловать, хозяин!");
                //var AdminPage = new AdminPage();
                //AdminPage.Show();
                MainWindow navWIN = new MainWindow();
                navWIN.Content = new AdminPage();
                navWIN.Show();
            }
            else
            {
                StorageContext db = new StorageContext();
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.name == login && u.password == password)
                    {
                        MessageBox.Show($"Успешный логин, человек с id {u.id}");

                        if (u.edit_permission)
                        {
                            //открыть окно(вкладку) редактирования
                            MessageBox.Show("Добро пожаловать в окно редактирования");
                        }
                        else if (u.order_permission)
                        {
                            //открыть окно(вкладку) заказа
                            MessageBox.Show("Добро пожаловать в окно заказа");
                        }
                        else
                        {
                            //открыть финальное окно(вкладку)
                            MessageBox.Show("Добро пожаловать и до свидания");
                            MainWindow finalWIN = new MainWindow();
                            finalWIN.Content = new FinalWinXaml();
                            finalWIN.Show();
                        }
                    }
                }
            }
        }

    }
}
