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
    /// Айди категории (FK)
    /// </summary>
    public int idCategory { get; set; }

    public virtual Category idCategoryNavigation { get; set; } = null!;

    public virtual ICollection<ValueCharacteristic> ValuesCharacteristic { get; set; } = new List<ValueCharacteristic>();
}