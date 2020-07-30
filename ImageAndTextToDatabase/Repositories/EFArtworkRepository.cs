using ImageAndTextToDatabase.EF;
using ImageAndTextToDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*public Artwork GetOne(string name)
        {
            //var SelectedArtwork = (from artwork in context.Artworks where artwork.Name == name select artwork).SingleOrDefault();
            //return SelectedArtwork;
            //return Artwork;
        }*/

        public void Update(Artwork artwork)
        {
            context.SaveChanges();
        }
    }
}
