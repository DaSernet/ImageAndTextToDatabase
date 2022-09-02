namespace ImageAndTextToDatabase.EF
{
    using ImageAndTextToDatabase.Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    public partial class AHDRCContext : DbContext
    {
        public AHDRCContext()
            : base("name=AHDRCConnection")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Artwork> Artworks { get; set; }

        public virtual DbSet<ArtworkImage> ArtworkImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>()
                .Property(e => e.Identifier)
                .IsFixedLength();

            modelBuilder.Entity<Artwork>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<ArtworkImage>()
                .HasKey(b => b.Id);

            /*modelBuilder.Entity<ArtworkImage>()
                .HasRequired(p => p.Artwork)
                .WithMany(d => d.ArtworkImage)
                .HasForeignKey(p => p.Artwork);*/
                
            Database.SetInitializer<AHDRCContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}