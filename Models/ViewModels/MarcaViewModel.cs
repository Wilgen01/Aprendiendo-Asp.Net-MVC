using System.ComponentModel.DataAnnotations;

namespace AprendiendoAsp.Net.Models.ViewModels
{
    public class MarcaViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
