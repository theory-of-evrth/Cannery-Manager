using System;
using System.Net;

namespace SummerPractise
{
    class WebRequesterToAPI
    {
        private static string NBURequestToCurrentDay = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        //yyyymmdd
        private static string NBURequestToDate = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=";
        //dd.mm.yyyy
        private static string PrivatRequestToDate = "https://api.privatbank.ua/p24api/exchange_rates?json&date=";

        private WebRequest request;
        private WebResponse response;

        public void MakeRequestToCurrentDay()
        {
            request = WebRequest.Create(NBURequestToCurrentDay);
        }
        public void MakeRequestToDate(string date) //yyyymmdd
        {
            request = WebRequest.Create(NBURequestToDate + date + "&json");
        }
        public void MakeRequestToDatePrivat(string date) //dd.mm.yyyy
        {
            request = WebRequest.Create(PrivatRequestToDate + date);
        }
        public void MakeRequestToCurrentDatePrivat()
        {
            request = WebRequest.Create(PrivatRequestToDate + DateTime.Today.Day + '.' + DateTime.Today.Month + '.' + DateTime.Today.Year);
        }
        public WebResponse GetResponse()
        {
            response = request.GetResponse();
            return response;
        }
    }
}
