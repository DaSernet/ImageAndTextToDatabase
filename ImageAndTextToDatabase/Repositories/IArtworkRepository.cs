using ImageAndTextToDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAndTextToDatabase.Repositories
{
    public interface IArtworkRepository
    {
        Artwork GetOne(string name);
        IList<Artwork> GetAll();
        void Add(Artwork artwork);
        void Update(Artwork artwork);
        void Delete(Artwork artwork);
    }
}
