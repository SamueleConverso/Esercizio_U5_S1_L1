using Esercizio_U5_S1_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S1_L1.Data {
    public class Esercizio_U5_S1_L1_EfCore : DbContext {

        public Esercizio_U5_S1_L1_EfCore(DbContextOptions<Esercizio_U5_S1_L1_EfCore> options) : base(options) { }

        public DbSet<Book> Books {
            get; set;
        }

        public DbSet<Genere> Generi {
            get; set;
        }

        public DbSet<Prestito> Prestiti {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Prestito>()
                .Property(a => a.DataPrestito)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Prestito>()
               .Property(a => a.DataRestituzione)
               .HasComputedColumnSql("DATEADD(day, 10, DataPrestito)");
        }
    }
}
