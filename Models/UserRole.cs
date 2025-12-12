using System;
using System.Collections.Generic;

namespace BlazorCurseach.Models;

public partial class UserRole
{
    /// <summary>
    /// Идентификатор роли пользователя
    /// </summary>
    public int idRole { get; set; }

    /// <summary>
    /// Название роли
    /// </summary>
    public string nameRole { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
