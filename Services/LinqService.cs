using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlazorCurseach.Models;
using BlazorCurseach.Data;

namespace BlazorCurseach.Services;

public class LinqService
{
    private readonly AppDbContext _db;

    public LinqService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Client>> SelectClients()
    {
        return await _db.Clients.ToListAsync();
    }

    public async Task<List<Client>> SelectClientAdmins()
    {
        return await _db.Clients
            .Where(c => c.idRole == 2)
            .ToListAsync();
    }

    public async Task<Client> InsertClient(Client newClient)
    {
        _db.Clients.Add(newClient);
        await _db.SaveChangesAsync();
        return newClient;
    }

    public async Task<Client> DeleteClient(Client newClient)
    {
        _db.Clients.Remove(newClient);
        await _db.SaveChangesAsync();
        return newClient;
    }
}