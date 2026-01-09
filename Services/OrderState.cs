using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;
using BlazorCurseach.Models;

namespace BlazorCurseach.Services;

public class OrderState
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;
    
    public bool isModalOpen { get; private set; }
    private bool isCartLoaded = false;
    public Item? selectedItem { get; private set; }
    public List<Item> cartItems { get; private set; } = new();

    public OrderState(ProtectedSessionStorage protectedSessionStorage)
    {
        _protectedSessionStorage = protectedSessionStorage;
    }

    public void OpenDialog(Item item)
    {
        selectedItem = item;
        isModalOpen = true;
    }

    public void CloseDialog()
    {
        isModalOpen = false;
        selectedItem = null;
    }

    public async Task IsCartLoadedAsync()
    {
        if (isCartLoaded) return;

        var result = await _protectedSessionStorage.GetAsync<List<Item>>("Cart");
        if (result.Success && result.Value != null)
            cartItems = result.Value;

        isCartLoaded = true;
    }

    public async Task SendCartAsync()
    {
        await _protectedSessionStorage.SetAsync("Cart", cartItems);
    }

    public async Task AddToCart()
    {
        await IsCartLoadedAsync();

        if (selectedItem != null)
        {
            cartItems.Add(selectedItem);
            await SendCartAsync();
        }
        CloseDialog();
    }

    public async Task DeleteFromCartAsync(Item item)
    {
        cartItems.Remove(item);
        await SendCartAsync();
    }
}