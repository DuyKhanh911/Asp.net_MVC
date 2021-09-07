namespace DataProvider
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Connect : DbContext
    {
        public Connect()
            : base("name=Connect")
        {
        }

        public virtual DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.fullname)
                .IsUnicode(false);
        }
    }
}
