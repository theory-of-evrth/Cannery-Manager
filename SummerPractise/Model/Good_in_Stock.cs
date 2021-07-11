using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.Model
{
    public class Good_in_Stock
    {
        public Good_in_Stock(Good_in_Stock obj)
        {
            this.id = obj.id;
            this.name = obj.name;
            this.price = obj.price;
            this.description = obj.description;
            this.num = obj.num;
        }
        public Good_in_Stock()
        {

        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int num { get; set; }
    }
}
