namespace ImageAndTextToDatabase.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ImageAndTextToDatabase.Models;

    public partial class AHDRCContext : DbContext
    {
        public AHDRCContext()
            : base("name=AHDRCConnection")
        {
        }

        public virtual DbSet<Object> Objects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Object>()
                .Property(e => e.Identifier)
                .IsFixedLength();

           /* modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);*/
        }
    }
}
