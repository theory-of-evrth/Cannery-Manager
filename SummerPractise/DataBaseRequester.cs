using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SummerPractise
{
    class DataBaseRequester
    {
        private Model.StorageContext storageContext;
        public DataBaseRequester()
        {
            storageContext = new Model.StorageContext();
        }

        public void MakeInsertRequest<TEntity>(TEntity entity)
        {
            storageContext.Add(entity);
            storageContext.SaveChanges();
        }
    }
}
//