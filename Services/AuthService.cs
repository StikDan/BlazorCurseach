using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;
using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;

namespace BlazorCurseach.Services;

public class AuthService
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    private readonly AppDbContext _db;
    LinqService linqService { get; }
    NavigationService navigationService {get; set;}

    public AuthService(
            ProtectedSessionStorage protectedSessionStorage,
            AppDbContext db
        )
    {
        _protectedSessionStorage = protectedSessionStorage;
        _db = db;
        linqService = new LinqService(_db);
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

    public void LogOut()
    {
        _protectedSessionStorage.DeleteAsync("CurrentClient");
        navigationService.ToLogin();
    }

    public async Task<bool> CheckValidClientAsync(List<Client> clientData)
    {
        var dbClients = await linqService.SelectClients();

        if (clientData == null || clientData.Count == 0)
            return await Task.FromResult(false);

        Client inputClient = clientData[0];

        foreach (Client client in dbClients)
        {
            if (client.login == inputClient.login 
                && client.password == inputClient.password)
            {
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> isAdminRoleAsync()
    {
        var client = await LoadDataAsync();
        var dbAdmins = await linqService.SelectClientAdmins();

        if(client == null || dbAdmins.Count == 0)
        {
            return await Task.FromResult(false);
        }
        
        foreach(var admin in dbAdmins)
        {
            if(admin.login == client.login && admin.idRole == 2)
            {
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }

    public async Task<bool> IsStorageEmptyAsync()
    {
        var result = await LoadDataAsync();
        if(result == null)
        {
            await Task.FromResult(true);
            return true;
        }
        else
        {
            await Task.FromResult(false);
            return false;
        }
    }
}