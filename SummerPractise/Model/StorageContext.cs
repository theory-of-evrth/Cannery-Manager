using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerPractise.Model
{
    class StorageContext : DbContext
    {
        public StorageContext()
            : base("DbConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}
