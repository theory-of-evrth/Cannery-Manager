using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace SummerPractise
{
    public class Parser
    {
        private string jsonResponse;
        private List<CurrencyRateNBU> currencyRatesNBU;
        private CurrencyRatePrivat currencyRatePrivat;

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
        public void FillListFromJSONToDateNBU(string date)
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
        public void FillCurrencyRateToCurrentDayPrivat()
        {
            WebRequesterToAPI webRequesterToAPI = new WebRequesterToAPI();
            webRequesterToAPI.MakeRequestToCurrentDatePrivat();
            using (WebResponse webResponse = webRequesterToAPI.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }
            currencyRatePrivat = JsonConvert.DeserializeObject<CurrencyRatePrivat>(jsonResponse);
        }
        public void FillCurrencyRateToDatePrivat(string date)
        {
            WebRequesterToAPI webRequesterToAPI = new WebRequesterToAPI();
            webRequesterToAPI.MakeRequestToDatePrivat(date);
            using (WebResponse webResponse = webRequesterToAPI.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(dataStream);
                    jsonResponse = streamReader.ReadToEnd();
                }
            }
            currencyRatePrivat = JsonConvert.DeserializeObject<CurrencyRatePrivat>(jsonResponse);
        }

        public List<CurrencyRateNBU> GetCurrencyRatesNBU()
        {
            return currencyRatesNBU;
        }
        public CurrencyRatePrivat GetCurrencyRatePrivat()
        {
            return currencyRatePrivat;
        }
        
    }
}
