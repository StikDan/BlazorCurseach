using BlazorCurseach.Models;
using BlazorCurseach.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCurseach.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClient _IClient;

    public ClientController(IClient iClient)
    {
        _IClient = iClient;
    }

    [HttpGet]
    public async Task<List<Client>> GetData()
    {
        return await Task.FromResult(_IClient.GetClientDetails());
    }

    [HttpGet("{id}")]
    public IActionResult GetDataById(int idClient)
    {
        Client client = _IClient.GetClientData(idClient);
        if (client != null)
        {
            return Ok(client);
        }
        return NotFound();
    }
}