using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ASP.Models;

public partial class BooksNew
{

    public int N { get; set; }

    [DisplayName("Код")]
    public double? Code { get; set; }

	[DisplayName("Нова?")]
	public bool New { get; set; }

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

	[DisplayName("Видавництво")]
	public int? IzdId { get; set; }

	[DisplayName("Формат")]
	public int? FormatId { get; set; }

	[DisplayName("Теми")]
	public int? ThemesId { get; set; }

	[DisplayName("Категорія")]
	public int? KategoryId { get; set; }

	[DisplayName("Формат")]
	public virtual SprFormat? Format { get; set; }

	[DisplayName("Видавництво")]
	public virtual SprIzd? Izd { get; set; }

	[DisplayName("Категорія")]
	public virtual SprKategory? Kategory { get; set; }

	[DisplayName("Теми")]
	public virtual SprTheme? Themes { get; set; }
}
