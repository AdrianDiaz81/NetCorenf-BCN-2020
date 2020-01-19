namespace NetCoreConf.BCN.API.Data
{
    using Microsoft.EntityFrameworkCore;
    using NetCoreConf.BCN.API.Model;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class AvengerDbContext : DbContext
    {
        public DbSet<Avenger> Avenger { get; set; }

        public DbSet<Film> Film { get; set; }

        public AvengerDbContext(DbContextOptions<AvengerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dataCustomer = JObject.Parse(File.ReadAllText(@"./Data/avengers.json"));
            var customerCollection = (JArray)dataCustomer["d"];
            IEnumerable<Avenger> avengersCollection = customerCollection.ToObject<IList<Avenger>>();
            modelBuilder.Entity<Avenger>().HasData(avengersCollection);
        }

    }
}
