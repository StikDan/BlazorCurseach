using BlazorCurseach.Models;

namespace BlazorCurseach.Services;

public class OrderState
{
    public bool IsModalOpen { get; private set; }
    public Item? SelectedItem { get; private set; }

    public void OpenDialog(Item item)
    {
        SelectedItem = item;
        IsModalOpen = true;
    }

    public void CloseDialog()
    {
        IsModalOpen = false;
        SelectedItem = null;
    }

    public void AddToCart()
    {
        // Логика добавления в корзину
        CloseDialog();
    }
}
