﻿using Esercizio_U5_S1_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S1_L1.Data {
    public class Esercizio_U5_S1_L1_EfCore : DbContext {

        public Esercizio_U5_S1_L1_EfCore(DbContextOptions<Esercizio_U5_S1_L1_EfCore> options) : base(options) { }

        public DbSet<Book> Books {
            get; set;
        }
    }
}
