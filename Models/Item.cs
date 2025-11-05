using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Товар
/// </summary>
public partial class Item
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public int idItem { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string nameItem { get; set; } = null!;

    /// <summary>
    /// Цена товара
    /// </summary>
    public double price { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string descItem { get; set; } = null!;

    /// <summary>
    /// Флаг, определяющий, в корзине ли товар (по умолчанию false)
    /// </summary>
    public sbyte inCart { get; set; }

    /// <summary>
    /// Доступное количество товаров
    /// </summary>
    public int countItem { get; set; }

    /// <summary>
    /// Идентификатор категории товара (FK)
    /// </summary>
    public int idCategory { get; set; }

    public virtual ICollection<CharacteristicItem> CharacteristicItems { get; set; } = new List<CharacteristicItem>();

    public virtual Category idCategoryNavigation { get; set; } = null!;
}
