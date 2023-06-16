using System;
using System.Collections.Generic;

namespace AprendiendoAsp.Net.Models;

public partial class Celular
{
    public int CelularId { get; set; }

    public string Modelo { get; set; } = null!;

    public int MarcaId { get; set; }

    public decimal Precio { get; set; }

    public virtual Marca Marca { get; set; } = null!;
}
