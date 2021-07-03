using System.IO;
using System.Net;

namespace SummerPractise
{
    class WebRequesterToAPI
    {
        private static string NBURequestToCurrentDay = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        //yyyymmdd
        private static string NBURequestToDate = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=";

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

        public WebResponse GetResponse()
        {
            response = request.GetResponse();
            return response;
        }
    }
}
