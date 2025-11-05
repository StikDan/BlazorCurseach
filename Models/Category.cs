using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Категория товара
/// </summary>
public partial class Category
{
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public int idCategory { get; set; }

    /// <summary>
    /// Название категории товаров
    /// </summary>
    public string nameCategory { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
