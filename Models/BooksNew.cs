using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Models;

public partial class BooksNew
{

    public int N { get; set; }

    [DisplayName("Код")]
    public double? Code { get; set; }

	[DisplayName("Нова?")]
	public bool New { get; set; }

    [Column("Name")]
    [DisplayName("Назва")]
	public string? Name { get; set; }

	[DisplayName("Ціна")]
	public decimal? Price { get; set; }

	[DisplayName("Сторінки")]
	public double? Pages { get; set; }

	[DisplayName("Дата")]
	public DateTime? Date { get; set; }

	[DisplayName("Копії")]
	public double? Pressrun { get; set; }

    [Column("Izd")]
    [DisplayName("Видавництво")]
	public int? IzdId { get; set; }

	[DisplayName("Формат")]
	public int? FormatId { get; set; }

	[DisplayName("Теми")]
	public int? ThemesId { get; set; }

    [Column("Category")]
    [DisplayName("Категорія")]
	public int? KategoryId { get; set; }

	[DisplayName("Формат")]
	public virtual SprFormat? Format { get; set; }

    [Column("Izd")]
    [DisplayName("Видавництво")]
	public virtual SprIzd? Izd { get; set; }

    [Column("Category")]
    [DisplayName("Категорія")]
	public virtual SprKategory? Kategory { get; set; }

	[DisplayName("Теми")]
	public virtual SprTheme? Themes { get; set; }
}
