using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace SummerPractise
{
    public class Parser
    {
        private string jsonResponse;
        private List<CurrencyRateNBU> currencyRatesNBU;

        public void FillListFromJSONToCurrentDayNBU()
        {
            WebRequesterToAPI webRequesterToAPI = new WebRequesterToAPI();
            webRequesterToAPI.MakeRequestToCurrentDay();
            using (WebResponse webResponse = webRequesterToAPI.GetResponse())
            {
                using(Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }
            currencyRatesNBU = JsonConvert.DeserializeObject<List<CurrencyRateNBU>>(jsonResponse);
        }

        public void FillListFromJSONToDayNBU(string date)
        {
            WebRequesterToAPI webRequesterToAPI = new WebRequesterToAPI();
            webRequesterToAPI.MakeRequestToDate(date);
            using (WebResponse webResponse = webRequesterToAPI.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }
            currencyRatesNBU = JsonConvert.DeserializeObject<List<CurrencyRateNBU>>(jsonResponse);
        }

        public List<CurrencyRateNBU> GetCurrencyRatesNBU()
        {
            return currencyRatesNBU;
        }
        
    }
}
