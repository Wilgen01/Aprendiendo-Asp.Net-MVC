using System.ComponentModel.DataAnnotations;

namespace AprendiendoAsp.Net.Models.ViewModels
{
    public class CelularViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int MarcaId { get; set; }

    }
}
