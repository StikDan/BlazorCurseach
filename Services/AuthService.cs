using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;
using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;
using Microsoft.JSInterop;

namespace BlazorCurseach.Services;

public class AuthService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly NavigationManager _navigationManager;
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private readonly AppDbContext _db;

    LinqService LinqService { get; }

    public AuthService(AppDbContext db, ProtectedSessionStorage protectedSessionStorage, 
                        IJSRuntime jsRuntime, NavigationManager navigationManager)
    {
        _protectedSessionStorage = protectedSessionStorage;
        _db = db;
        _jsRuntime = jsRuntime;
        _navigationManager = navigationManager;

        LinqService = new LinqService(_db);
    }

    public async Task SendDataAsync(Client Client)
    {
        await _protectedSessionStorage.SetAsync("CurrentClient", Client);
    }

    public async Task<Client?> LoadDataAsync()
    {
        var result = await _protectedSessionStorage.GetAsync<Client?>("CurrentClient");
        return result.Value;
    }

    public void SuccessAuth()
    {
        _navigationManager.NavigateTo("/", forceLoad: true);
    }

    public async Task<bool> CheckValidClientAsync(List<Client> clientData)
    {
        List<Client> dbClients = LinqService.SelectClients();

        if (clientData == null || clientData.Count == 0)
            return false;

        Client inputClient = clientData[0];

        for (int i = 0; i < dbClients.Count; i++)
        {
            if (dbClients[i].login == inputClient.login 
                && dbClients[i].password == inputClient.password)
            {
                return await Task.FromResult(true);
            }
        }

        return await Task.FromResult(false);
    }

    public async Task<bool> IsStorageEmptyAsync()
    {
        string key = "CurrentClient";
        var result = await _jsRuntime.InvokeAsync<string>(
            "sessionStorage.getItem", key
        );
        return string.IsNullOrEmpty(result);
    }
}