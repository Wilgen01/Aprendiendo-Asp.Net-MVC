using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AprendiendoAsp.Net.Models;

public partial class Marca
{
    public int MarcaId { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Celular> Celulars { get; set; } = new List<Celular>();
}
