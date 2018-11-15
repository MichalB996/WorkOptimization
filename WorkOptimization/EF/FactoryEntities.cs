namespace WorkOptimization.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FactoryEntities : DbContext
    {
        public FactoryEntities()
            : base("name=FactoryDataBaseEntities")
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Factories> Factories { get; set; }
        public virtual DbSet<Machines> Machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factories>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Factories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factories>()
                .HasMany(e => e.Machines)
                .WithRequired(e => e.Factories)
                .WillCascadeOnDelete(false);
        }
    }
}
