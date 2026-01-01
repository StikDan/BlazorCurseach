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
            
    public void SuccessAuth()
    {
        _navigationManager.NavigateTo("/", forceLoad: true);
    }

    public void ToSignUp()
    {
        _navigationManager.NavigateTo("/join");
    }

    public void ToLogin()
    {
        _navigationManager.NavigateTo("/login");
    }

    public void ToProfile()
    {
        _navigationManager.NavigateTo("/profile");
    }
}