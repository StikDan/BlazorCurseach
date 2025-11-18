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

    public List<Client> SelectClients()
    {
        return _db.Clients.ToList();
    }
}