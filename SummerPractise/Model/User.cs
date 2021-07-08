using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.Model
{
    public class User 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public bool order_permission { get; set; }
        public bool edit_permission { get; set; }
        public bool is_provider { get; set; }
    }

}
