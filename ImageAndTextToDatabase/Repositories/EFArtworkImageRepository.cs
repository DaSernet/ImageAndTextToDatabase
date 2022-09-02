using ImageAndTextToDatabase.EF;
using ImageAndTextToDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImageAndTextToDatabase.Repositories
{
    public class EFArtworkImageRepository : IArtworkImageRepository
    {
        private AHDRCContext context = new AHDRCContext();

        public void Add(ArtworkImage artworkImage)
        {
            context.ArtworkImages.Add(artworkImage);
            context.SaveChanges();
        }

        public void Delete(ArtworkImage artworkImage)
        {
            context.ArtworkImages.Remove(artworkImage);
            context.SaveChanges();
        }

        public IList<ArtworkImage> GetAll()
        {
            return context.ArtworkImages.ToList();
        }

        public void Update(ArtworkImage artworkImage)
        {
            context.SaveChanges();
        }
    }
}