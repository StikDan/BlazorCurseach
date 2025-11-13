/*
1) В базе есть хешированные пароли SHA1 +
2) При вводе в форму логина и пароля +
3) логин отправляется на проверку вместе с паролем, +
4) Хешируется пароль для проверки +
5) Получение данных из базы 
6) Проверка данных на валидность
7) Если верно - записывать в сессию браузера
8) Иначе - "Неправильный логин или пароль"
*/
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;

namespace BlazorCurseach.Services;

public class AuthService : IClient
{
    private readonly ProtectedSessionStore _protectedSessionStore;

    public AuthService(ProtectedSessionStore protectedSessionStore)
    {
        _protectedSessionStore = protectedSessionStore;
    }

    protected async Task LoadDataAsync()
    {
        var result = await ProtectedSessionStore.GetAsync<Client?>("CurrentUser");
    }

    protected async Task SendDataAsync()
    {
        await ProtectedSessionStore.SetAsync("CurrentUser", ClientData);
    }
}