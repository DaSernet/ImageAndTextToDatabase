using ImageAndTextToDatabase.Models;
using System.Collections.Generic;

namespace ImageAndTextToDatabase.Repositories
{
    public interface IArtworkImageRepository
    {
        /*Artwork GetOne(string name);*/

        IList<ArtworkImage> GetAll();

        void Add(ArtworkImage artworkImage);

        void Update(ArtworkImage artworkImage);

        void Delete(ArtworkImage artworkImage);
    }
}