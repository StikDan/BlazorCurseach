using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorCurseach.Models;

/// <summary>
/// Гость веб-приложения (Потенциальный пользователь)
/// </summary>
public partial class Guest
{
    /// <summary>
    /// Логин гостя
    /// </summary>
    [Required]
    public string login { get; set; } = null!;

    /// <summary>
    /// Пароль гостя
    /// </summary>
    [Required]
    public string password { get; set; } = null!;
}
