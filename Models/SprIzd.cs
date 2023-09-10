using System;
using System.Collections.Generic;

namespace ASP.Models;

public partial class SprIzd
{
    public string? Izd { get; set; }

    public int Id { get; set; }

    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
