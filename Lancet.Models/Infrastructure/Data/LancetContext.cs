using System;
using Microsoft.EntityFrameworkCore;

namespace Lancet.Models.Domain.Model
{
    public class LancetContext : DbContext
    {
        public LancetContext(DbContextOptions<LancetContext> options) : base(options)
        {
        }
        public DbSet<MetaData> MetaDatas { get; set; }
        public DbSet<MetaObject> MetaObjects { get; set; }
        public DbSet<MetaType> MetaTypes { get; set; }
        public DbSet<ObjectRelation> ObjectRelations { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
