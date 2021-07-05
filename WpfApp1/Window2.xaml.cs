using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

      
    }
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public bool order_permission { get; set; }
        public bool edit_permission { get; set; }
    }

    private void AdminWindow(object sender, RoutedEventArgs e)
    {
        var query =
        from User in dataEntities.Products
        orderby User.ListPrice
        select new { User.name, User.id, Categoryname = User.ProductCategory.Name, product.ListPrice };

        dataGrid1.ItemsSource = query.ToList();
    }
}
