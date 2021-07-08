using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SummerPractise.Model;

namespace SummerPractise
{
    public static class DataBaseRequester
    {
        private static StorageContext storageContext;
        static DataBaseRequester()
        {
            storageContext = new StorageContext();
        }

        public static void MakeInsertRequestCurrency(Currency currency)
        {
            if (FindOrAdd(currency) == null)
            {
                storageContext.Add(currency);
                storageContext.SaveChanges();
            }
        }
        public static Currency FindOrAdd(Currency currency)
        {
            return storageContext.Currencies.Find(currency.id)
                ?? null;
        }
    }
}
//