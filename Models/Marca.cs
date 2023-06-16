using System;
using System.Collections.Generic;

namespace AprendiendoAsp.Net.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Celulare> Celulares { get; set; } = new List<Celulare>();
}
