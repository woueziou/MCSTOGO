using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MCSTOGO.Models
{
    public class PostInputModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Entrer le nom du post")]
        [Display(Name = "Nom")]
        public string NomPost { get; set; }

        [Required(ErrorMessage = "Renseigner le prix svp")]
        [Display(Name = "Prix")]
        public string Prix { get; set; }

        [Display(Name = "Quartier/Ville/Emplacement")]
        [Required(ErrorMessage = "Svp entrez le lieu")]
        public string Lieu { get; set; }  
        [Display(Name = "Type de contrat")]
        [Required(ErrorMessage = "Svp entrez le type de contrat")]
        public string TypeContrat { get; set; }

        public string Description { get; set; }
        [Display(Name = "Date d'ajout")] public string DateAjout { get; set; }
        [Display(Name = "Photo principale")] public IFormFile Photo1 { get; set; }
        [Display(Name = "Photo Secondaire")] public IFormFile Photo2 { get; set; }
        [Display(Name = "Photo Optionnel")] public IFormFile Photo3 { get; set; }
        [Display(Name = "Photo optionnel")] public IFormFile Photo4 { get; set; }
    }

    public class PostViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Entrer le nom du post")]
        [Display(Name = "Nom")]
        public string NomPost { get; set; }

        [Required(ErrorMessage = "Renseigner le prix svp")]
        [Display(Name = "Prix")]
        public string Prix { get; set; }


        public string Description { get; set; }

        [Display(Name = "Quartier/Ville/Emplacement")]
        [Required(ErrorMessage = "Svp entrez le lieu")]
        public string Lieu { get; set; }

        [Display(Name = "Contrat")] public string TypeContrat { get; set; }
        public List<string> PhotoUrls { get; set; }
    }
}