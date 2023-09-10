using System;
using System.Collections.Generic;

namespace ASP.Models;

public partial class SprFormat
{
    public string? Format { get; set; }

    public int Id { get; set; }

    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
