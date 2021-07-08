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

        //public IQueryable<TEntity> GetEntities<TEntity>(TEntity entity)
        //{
            //IQueryable<Model.Change> changes = from change in storageContext.Changes
             //                                  where change.approved == false
               //                                select change;
            //IQueryable<TEntity> entities = from entity in storageContext.(entity.GetType())
            //                               where ;
            //return entities;
        //}

    }
}
//