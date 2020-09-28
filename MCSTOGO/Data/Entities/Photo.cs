using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCSTOGO.Data.Entities
{
    public class Photo
    {
        [MaxLength(12)]
        [Key] public string Id { get; set; }
        public string Url { get; set; }
        [Column(TypeName = "varchar(10)")] public string Etat { get; set; }
        [Column(TypeName = "varchar(20)")] public string DateAjout { get; set; }
         public string PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}