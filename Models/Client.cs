using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorCurseach.Models;

/// <summary>
/// Клиент веб-приложения (Пользователь)
/// </summary>
public partial class Client
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int idClient { get; set; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    public string firstName { get; set; } = null!;

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public string lastName { get; set; } = null!;

    /// <summary>
    /// Отчество клиента
    /// </summary>
    public string fatherName { get; set; } = null!;

    /// <summary>
    /// Телефон клиента
    /// </summary>
    public string? phone { get; set; }

    /// <summary>
    /// Электронная почта клиента
    /// </summary>
    public string email { get; set; } = null!;

    /// <summary>
    /// Логин клиента
    /// </summary>
    [Required(ErrorMessage = "Login Required")]
    public string login { get; set; } = null!;

    /// <summary>
    /// Пароль клиента
    /// </summary>
    [Required(ErrorMessage = "Password Required")]
    public string password { get; set; } = null!;

    /// <summary>
    /// Айди роли конкретного клиента
    /// </summary>
    public int idRole { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual UserRole idUserRoleNavigation { get; set; } = null!;
}
