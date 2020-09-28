using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCSTOGO.Data.Entities
{
    public class Post
    {
        [MaxLength(12)]
        [Key] public string Id { get; set; }
         public string NomPost { get; set; }
public string Prix { get; set; }
      public string Lieu { get; set; }
         public string Description { get; set; }
         public string TypeContrat { get; set; }
        // public string PhotoId { get; set; }
        [Column(name: "photourl")] public virtual ICollection<Photo> Photos { get; set; }

        public string EtatVente { get; set; }
        public string DateAjout { get; set; }
    }
}