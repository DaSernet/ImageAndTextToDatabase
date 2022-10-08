using System.ComponentModel.DataAnnotations;

namespace ImageAndTextToDatabase.Models
{
    public partial class ArtworkImage
    {
        [Key]
        public int Id { get; set; }

        public string ImageURL { get; set; }
        public string ImageSize { get; set; }
        public Artwork Artwork { get; set; }
        public int ArtworkId { get; set; }
    }
}