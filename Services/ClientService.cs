using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;

namespace BlazorCurseach.Services;

public class ClientService<Client> : ICrudService<Client>
{
    private readonly AppDbContext _db;

    public ClientService(AppDbContext db)
    {
        _db = db;
        linqService = new LinqService(_db);
    }

    public async Task CreateAsync(Client parameter)
    {
        await Task.CompletedTask;
    }
    public async Task<Client?> ReadAsync(int id)
    {
        await Task.CompletedTask;   
    }
    public async Task UpdateAsync(Client parameter)
    {
        await Task.CompletedTask;
    }
    public async Task DeleteAsync(int id)
    {
        await Task.CompletedTask;
    }
}