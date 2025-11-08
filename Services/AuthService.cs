using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorCurseach.Services;

public class AuthService : IClient 
{
    private readonly AppDbContext _db;

    public AuthService(AppDbContext db)
    {
        _db = db;
    }

    public List<Client> GetClientDetails()
    {
        return _db.Clients.ToList();
    }

    public Client GetClientData(int idClient)
    {
        Client? client = _db.Clients.Find(idClient);
        if (client != null)
        {
            return client;
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
}