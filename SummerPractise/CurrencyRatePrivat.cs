using System.Collections.Generic;
using Newtonsoft.Json;

namespace SummerPractise
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CurrencyRatePrivat
    {
        [JsonProperty(PropertyName = "date")]
        public string date { get; set; }
        [JsonProperty(PropertyName = "bank")]
        public string bank { get; set; }
        [JsonProperty(PropertyName = "baseCurrency")]
        public int baseCurrency { get; set; }
        [JsonProperty(PropertyName = "baseCurrencyLit")]
        public string baseCurrencyLit { get; set; }
        [JsonProperty(PropertyName = "exchangeRate")]
        public List<Currencies> exchangeRate { get; set; }

        public class Currencies
        {
            [JsonProperty(PropertyName = "baseCurrency")]
            public string baseCurrency { get; set; }
            [JsonProperty(PropertyName = "currency")]
            public string currency { get; set; }
            [JsonProperty(PropertyName = "saleRateNB")]
            public double saleRateNB { get; set; }
            [JsonProperty(PropertyName = "purchaseRateNB")]
            public double purchaseRateNB { get; set; }
            [JsonProperty(PropertyName = "saleRate")]
            public double saleRate { get; set; }
            [JsonProperty(PropertyName = "purchaseRate")]
            public double purchaseRate { get; set; }
            public string[] ToStringArray()
            {
                string[] arr = new string[] { baseCurrency, currency, saleRateNB.ToString(),
                                                purchaseRateNB.ToString(), saleRate.ToString(), purchaseRate.ToString()};
                return arr;
            }
        }
        override public string ToString()
        {
            return date + " " + bank + " " + baseCurrency.ToString() + " " + baseCurrencyLit;
        }
    }
}
