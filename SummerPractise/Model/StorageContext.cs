using Microsoft.EntityFrameworkCore;

namespace SummerPractise.Model
{
    class StorageContext : DbContext
    {
        public StorageContext()
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Good_in_Stock> Goods_In_Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Provider_Offer> Provider_Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=../../../db.db");
        }
        public override void Dispose()
        {
            Database.CloseConnection();
            base.Dispose();
        }
    }
}