using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IbrahimEyyupInan_Hafta2.Model;

namespace IbrahimEyyupInan_Hafta2.Data
{
    public class W2Context : DbContext
    {
        public W2Context (DbContextOptions<W2Context> options)
            : base(options)
        {
        }

        public DbSet<IbrahimEyyupInan_Hafta2.Model.Category> Category { get; set; }

        public DbSet<IbrahimEyyupInan_Hafta2.Model.Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Category>()
                .HasMany(e => e.products).WithOne(e => e.category);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());


        }
    }
}
