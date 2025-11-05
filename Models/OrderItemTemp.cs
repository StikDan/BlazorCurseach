using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Таблица для обеспечения связи N:M (Item &lt;-&gt; Order)
/// </summary>
public partial class OrderItemTemp
{
    /// <summary>
    /// Айди товара для связи M:M (FK)
    /// </summary>
    public int idItem { get; set; }

    /// <summary>
    /// Айди заказа для связи M:M (FK)
    /// </summary>
    public int idOrder { get; set; }

    public virtual Item idItemNavigation { get; set; } = null!;

    public virtual Order idOrderNavigation { get; set; } = null!;
}
