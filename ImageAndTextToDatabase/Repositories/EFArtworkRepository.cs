using ImageAndTextToDatabase.EF;
using ImageAndTextToDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImageAndTextToDatabase.Repositories
{
    public class EFArtworkRepository : IArtworkRepository
    {
        private AHDRCContext context = new AHDRCContext();

        public void Add(Artwork artwork)
        {
            context.Artworks.Add(artwork);
            context.SaveChanges();
        }

        public void Delete(Artwork artwork)
        {
            context.Artworks.Remove(artwork);
            context.SaveChanges();
        }

        public IList<Artwork> GetAll()
        {
            return context.Artworks.ToList();
        }

        public void Update(Artwork artwork)
        {
            context.SaveChanges();
        }
    }
}