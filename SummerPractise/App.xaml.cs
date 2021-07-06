using Microsoft.EntityFrameworkCore;
using SummerPractise.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SummerPractise
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() 
        {
            this.InitializeComponent();
            using (var db = new StorageContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
