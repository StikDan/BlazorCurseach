using Microsoft.AspNetCore.Components;
using BlazorCurseach.Data;
using BlazorCurseach.Models;

namespace BlazorCurseach.Services;

public class NavigationService {

    private readonly NavigationManager _navigationManager;
    
    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }
            
    public void ToHome()
    {
        _navigationManager.NavigateTo("/", forceLoad: true);
    }

    public void ToSignUp()
    {
        _navigationManager.NavigateTo("/join", forceLoad: true);
    }

    public void ToLogin()
    {
        _navigationManager.NavigateTo("/login", forceLoad: true);
    }

    public void ToProfile()
    {
        _navigationManager.NavigateTo("/profile", forceLoad: true);
    }

    public void ToCart()
    {
        _navigationManager.NavigateTo("/cart");
    }

    public void ToOrder()
    {
        _navigationManager.NavigateTo("/orders");
    }
}