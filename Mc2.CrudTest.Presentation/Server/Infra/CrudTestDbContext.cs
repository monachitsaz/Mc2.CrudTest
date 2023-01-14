using Mc2.CrudTest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Infra
{
    public class CrudTestDbContext : DbContext
    {
        public CrudTestDbContext()
        {

        }

        public CrudTestDbContext(DbContextOptions<CrudTestDbContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
                entity.HasIndex(c => c.Email).IsUnique();
                entity.Property(x => x.BankAccountNumber).HasMaxLength(20);
                entity.Property(c => c.Email).HasMaxLength(25);
                entity.Property(c => c.FirstName).HasMaxLength(25);
                entity.Property(c => c.LastName).HasMaxLength(25);

            });
            base.OnModelCreating(modelBuilder);

        }
    }
}
