using System;
using System.Collections.Generic;

namespace AprendiendoAsp.Net.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Celular> Celulars { get; set; } = new List<Celular>();
}
