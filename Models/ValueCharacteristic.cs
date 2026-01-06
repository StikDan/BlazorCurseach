using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Значение характеристики товара
/// </summary>
public partial class ValueCharacteristic
{
    /// <summary>
    /// Идентификатор значения характеристики
    /// </summary>
    public int idValueCharacteristic { get; set; }

    /// <summary>
    /// Само значение характеристики (Spell Power = 15%)
    /// </summary>
    public string selfValue { get; set; } = null!;

    /// <summary>
    /// Айди характеристики (FK)
    /// </summary>
    public int idCharacteristicItem { get; set; }

    public virtual CharacteristicItem idCharacteristicItemNavigation { get; set; } = null!;
}
