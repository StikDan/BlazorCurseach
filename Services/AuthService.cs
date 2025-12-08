using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;

namespace BlazorCurseach.Services;

public class AuthService
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private readonly AppDbContext _db;

    LinqService LinqService { get; }

    public AuthService(AppDbContext db, ProtectedSessionStorage protectedSessionStorage)
    {
        _protectedSessionStorage = protectedSessionStorage;
        _db = db;

        LinqService = new LinqService(_db);
    }

    public async Task SendDataAsync(string currentUser, Client Client)
    {
        await _protectedSessionStorage.SetAsync(currentUser, Client);
    }

    public async Task LoadDataAsync(string currentUser)
    {
        var result = await _protectedSessionStorage.GetAsync<Client?>(currentUser);
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
        var result = await _protectedSessionStorage.GetAsync<Client>(key);

        // If Success is false, there is no such item in session storage.
        return !result.Success || result.Value == null;
    }
}