using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

/// <summary>
/// Заказ
/// </summary>
public partial class Order
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public int idOrder { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime dateCreated { get; set; }

    /// <summary>
    /// Описание заказа
    /// </summary>
    public string? descOrder { get; set; }

    /// <summary>
    /// Идентификатор статуса заказа (FK)
    /// </summary>
    public int idStatusOrder { get; set; }

    /// <summary>
    /// Айди клиента (FK)
    /// </summary>
    public int idClient { get; set; }

    public virtual Client idClientNavigation { get; set; } = null!;

    public virtual StatusOrder idStatusOrderNavigation { get; set; } = null!;
}
