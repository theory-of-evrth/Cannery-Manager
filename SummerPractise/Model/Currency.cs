using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.Model
{
    public class Currency
    {
        public int id { get; set; }
        public string txt { get; set; }
        public double rate { get; set; }
        public string ccy { get; set; }
        public double buy { get; set; }
        public double sale { get; set; }
        public string date { get; set; }
        public Currency()
        { }
        public Currency(CurrencyRateNBU currencyRateNBU)
        {
            this.txt = currencyRateNBU.txt;
            this.rate = currencyRateNBU.rate;
            this.ccy = currencyRateNBU.cc;
            this.date = currencyRateNBU.exchangedate;
        }
    }
}
