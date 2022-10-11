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
                .HasKey(x => x.ArtworkId)
                .HasMany(p => p.ArtworkImage)
                .WithRequired(p => p.Artwork);


            modelBuilder.Entity<ArtworkImage>()
                .HasKey(b => b.ArtworkImageId)
                .HasRequired(p => p.Artwork)
                .WithMany(d => d.ArtworkImage)
                .HasForeignKey(p => p.ArtworkId);


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