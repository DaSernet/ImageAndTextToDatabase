using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageAndTextToDatabase.Models
{
    public partial class ArtworkImage
    {
        [Key]
        public int ArtworkImageId { get; set; }

        public string ImageURL { get; set; }
        public string ImageSize { get; set; }
        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }
        public int ArtworkId { get; set; }
    }
}