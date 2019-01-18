using System;
using Microsoft.EntityFrameworkCore;

namespace Lancet.Models.Domain.Model
{
    public class LancetContext : DbContext
    {
        public LancetContext(DbContextOptions<LancetContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
