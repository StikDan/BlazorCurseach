using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Таблица для обеспечения связи N:M (Item <-> ValueCharacteristic)
/// Каждый товар имеет одно значение для каждой характеристики своей категории
/// </summary>
public partial class ItemCharacteristicValue
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int idItemCharacteristicValue { get; set; }

    /// <summary>
    /// Айди товара для связи M:M (FK)
    /// </summary>
    public int idItem { get; set; }

    /// <summary>
    /// Айди значения характеристики для связи M:M (FK)
    /// </summary>
    public int idValueCharacteristic { get; set; }

    public virtual Item idItemNavigation { get; set; } = null!;

    public virtual ValueCharacteristic idValueCharacteristicNavigation { get; set; } = null!;
}