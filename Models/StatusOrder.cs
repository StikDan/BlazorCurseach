using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Статус заказа
/// </summary>
public partial class StatusOrder
{
    /// <summary>
    /// Идентификатор статуса заказа
    /// </summary>
    public int idStatusOrder { get; set; }

    /// <summary>
    /// Название статуса заказа
    /// </summary>
    public string nameStatus { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
