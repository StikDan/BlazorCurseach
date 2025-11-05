using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Характеристика товара
/// </summary>
public partial class CharacteristicItem
{
    /// <summary>
    /// Идентификатор характеристики товара
    /// </summary>
    public int idCharacteristicItem { get; set; }

    /// <summary>
    /// Название характеристики
    /// </summary>
    public string nameCharacteristicItem { get; set; } = null!;

    /// <summary>
    /// Айди товара (FK)
    /// </summary>
    public int idItem { get; set; }

    public virtual Item idItemNavigation { get; set; } = null!;
}
