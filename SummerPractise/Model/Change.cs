using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.Model
{
    class Change
    {
        public int id { get; set; }
        public User user { get; set; }
        public string type { get; set; }
        public Good_in_Stock obj { get; set; }
        public int value { get; set; }
        public int new_value { get; set; }
        public string date { get; set; }
        public bool approved { get; set; }
    }
}
