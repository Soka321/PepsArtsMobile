using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsArts_Mobile.Models
{
   public  class ExhibitionArtPiece
    {

        public int Id { get; set; }
        public int Exhibition_Id { get; set; }
        [ForeignKey("Exhibition_Id")]
        public Exhibition exhibition { get; set; }
        public int ArtPiece_Id { get; set; }
        [ForeignKey("ArtPiece_Id")]
        public ArtPiece Piece { get; set; }
    }
}
