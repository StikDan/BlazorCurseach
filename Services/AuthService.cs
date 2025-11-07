using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorCurseach.Services;

public class AuthService : IClient 
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public List<Client> GetClientDetails()
    {
        return _context.Clients.ToList();
    }

    public Client GetClientData(int idClient)
    {
        Client? client = _context.Clients.Find(idClient);
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