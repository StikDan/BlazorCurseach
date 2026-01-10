using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FuzzySharp;
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

    public async Task<List<Client>> FindClient(Client newClient)
    {
        return await _db.Clients
            .Where(c => c.login == newClient.login && c.password == newClient.password)
            .ToListAsync();
    }

    public async Task<List<Item>> SelectItems()
    {
        return await _db.Items.ToListAsync();
    }

    public async Task<Dictionary<string, string>> GetItemCharacteristicsAsync(int itemId)
    {
        var itemValues = await _db.ItemCharacteristicValues
            .Include(icv => icv.idValueCharacteristicNavigation)
                .ThenInclude(vc => vc.idCharacteristicItemNavigation)
            .Where(icv => icv.idItem == itemId)
            .ToListAsync();
        
        var result = new Dictionary<string, string>();
        
        foreach (var itemValue in itemValues)
        {
            var valueChar = itemValue.idValueCharacteristicNavigation;
            var charName = valueChar.idCharacteristicItemNavigation.nameCharacteristicItem;
            result[charName] = valueChar.selfValue;
        }
        
        return result;
    }

    public async Task<Order> CreateOrderAsync(Order order, List<Item> items)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        foreach (var item in items)
        {
            var orderItem = new OrderItemTemp
            {
                idOrder = order.idOrder,
                idItem = item.idItem
            };
            _db.OrderItemTemps.Add(orderItem);
        }

        await _db.SaveChangesAsync();
        return order;
    }

    public async Task<List<Order>> GetUserOrders(int clientId)
    {
        return await _db.Orders
            .Where(o => o.idClient == clientId)
            .OrderByDescending(o => o.dateCreated)
            .ToListAsync();
    }

    public async Task<StatusOrder?> GetStatusOrderById(int statusId)
    {
        return await _db.StatusOrders.FirstOrDefaultAsync(s => s.idStatusOrder == statusId);
    }

    public async Task<Client?> GetClientById(int clientId)
    {
        return await _db.Clients.FirstOrDefaultAsync(c => c.idClient == clientId);
    }
}