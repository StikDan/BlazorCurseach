using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;
using BlazorCurseach.Models;

namespace BlazorCurseach.Services;

public class OrderState
{
    private readonly ProtectedLocalStorage _localStorage;
    
    public bool isModalOpen { get; private set; }
    private bool isCartLoaded = false;
    public Item? selectedItem { get; private set; }
    public List<Item>? cartItems { get; private set; } = new();

    public OrderState(ProtectedLocalStorage localStorage)
    {
        _localStorage = localStorage;
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

        var result = await _localStorage.GetAsync<List<Item>>("Cart");
        if (result.Success && result.Value != null)
            cartItems = result.Value;

        isCartLoaded = true;
    }

    public async Task SendCartAsync()
    {
        await _localStorage.SetAsync("Cart", cartItems);
    }

    public async Task AddToCart()
    {
        await IsCartLoadedAsync();

        if (selectedItem != null)
        {
            cartItems.Add(selectedItem);
            Console.WriteLine($"Count: {cartItems.Count}");
            await SendCartAsync();
        }
        CloseDialog();
    }
}