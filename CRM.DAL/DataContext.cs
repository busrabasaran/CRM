namespace CRM.DAL

{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CRM.Entity;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Emails)
                .WithOptional(e => e.Customers)
                .HasForeignKey(e => e.EmailTo);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.EmployeeRoles)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.EmployeeRoles)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);
        }
    }
}
