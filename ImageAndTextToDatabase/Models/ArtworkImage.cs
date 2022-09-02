using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAndTextToDatabase.Models
{
    public partial class ArtworkImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Courtesy { get; set; }
        public string Photographer { get; set; }
        public string Copyright { get; set; }
        public string ImageSize { get; set; }
        public Artwork Artwork { get; set; }
    }
}
