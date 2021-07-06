using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.Model
{
    class Order
    {
        public int id { get; set; }
        public User user { get; set; }
        public double price { get; set; }
        public Currency currency { get; set; }
        public int goods_num { get; set; }
        public string date { get; set; }
        public Good_in_Stock obj { get; set; }

    }
}
