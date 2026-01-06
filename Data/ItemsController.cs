using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCurseach.Models;

namespace BlazorCurseach.Data;

[Route("items")]
[ApiController]
public class ItemsController : Controller
{
    private readonly AppDbContext _db;

    public ItemsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetItems()
    {
        return (await _db.Items.ToListAsync()).OrderByDescending(s => s.price).ToList();
    }
}