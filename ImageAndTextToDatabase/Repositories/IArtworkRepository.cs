using ImageAndTextToDatabase.Models;
using System.Collections.Generic;

namespace ImageAndTextToDatabase.Repositories
{
    public interface IArtworkRepository
    {
        /*Artwork GetOne(string name);*/

        IList<Artwork> GetAll();

        void Add(Artwork artwork);

        void Update(Artwork artwork);

        void Delete(Artwork artwork);
    }
}