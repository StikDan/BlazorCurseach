using BlazorCurseach.Data;
using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorCurseach.Services;

public class AuthService : IClient 
{
    private readonly AppDbContext _context = new();
    public AuthService(AppDbContext _context)
    {
        _context = context;
    }

    public List<Client> GetUserDetails()
    {
        return _context.Users
    }
}