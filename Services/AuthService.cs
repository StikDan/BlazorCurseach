using BlazorCurseach.Data;
using BlazorCurseach.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCurseach.Services;

public class AuthService(AppDbContext appDbContext)
{
    private readonly AppDbContext _appDbContext = appDbContext;
}