using System;
using System.Collections.Generic;

namespace AprendiendoAsp.Net.Models;

public partial class Celulare
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public int IdMarca { get; set; }

    public decimal Precio { get; set; }

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
