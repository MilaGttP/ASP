using System;
using System.Collections.Generic;

namespace ASP.Models;

public partial class BooksNew
{
    public int N { get; set; }

    public double? Code { get; set; }

    public bool New { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public double? Pages { get; set; }

    public DateTime? Date { get; set; }

    public double? Pressrun { get; set; }

    public int? IzdId { get; set; }

    public int? FormatId { get; set; }

    public int? ThemesId { get; set; }

    public int? KategoryId { get; set; }

    public virtual SprFormat? Format { get; set; }

    public virtual SprIzd? Izd { get; set; }

    public virtual SprKategory? Kategory { get; set; }

    public virtual SprTheme? Themes { get; set; }
}
