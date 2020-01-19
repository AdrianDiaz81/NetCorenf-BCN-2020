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

        public DbSet<AvengerFilm> AvengerFilm { get; set; }

        public AvengerDbContext(DbContextOptions<AvengerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AvengerFilm>()
        .HasKey(bc => new { bc.AvengerId, bc.FilmId });
            modelBuilder.Entity<AvengerFilm>()
                .HasOne(bc => bc.Avenger)
                .WithMany(b => b.AvengerFilm)
                .HasForeignKey(bc => bc.AvengerId);
            modelBuilder.Entity<AvengerFilm>()
                .HasOne(bc => bc.Film)
                .WithMany(c => c.AvengerFilm)
                .HasForeignKey(bc => bc.FilmId);

            var dataCustomer = JObject.Parse(File.ReadAllText(@"./Data/avengers.json"));
            var customerCollection = (JArray)dataCustomer["d"];
            IEnumerable<Avenger> avengersCollection = customerCollection.ToObject<IList<Avenger>>();
            modelBuilder.Entity<Avenger>().HasData(avengersCollection);

            var dataFilms = JObject.Parse(File.ReadAllText(@"./Data/films.json"));
            var filmsCollection = (JArray)dataFilms["d"];
            IEnumerable<Film> filsCollection = filmsCollection.ToObject<IList<Film>>();
            modelBuilder.Entity<Film>().HasData(filsCollection);

            var dataAvengerFilms = JObject.Parse(File.ReadAllText(@"./Data/avengerFilms.json"));
            var avenverFilmsCollection = (JArray)dataAvengerFilms["d"];
            IEnumerable<AvengerFilm> avengerFilsCollection = avenverFilmsCollection.ToObject<IList<AvengerFilm>>();
            modelBuilder.Entity<AvengerFilm>().HasData(avengerFilsCollection);
        }

    }
}
