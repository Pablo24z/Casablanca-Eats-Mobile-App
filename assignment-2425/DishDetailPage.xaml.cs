using assignment_2425.Models;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Devices;
using System;
using Microsoft.Maui.Controls;

namespace assignment_2425;

[QueryProperty(nameof(Dish), "Dish")]
public partial class DishDetailPage : ContentPage
{
    private DishItem _dish;
    public DishItem Dish
    {
        get => _dish;
        set
        {
            _dish = value;
            BindingContext = _dish;
        }
    }

    public DishDetailPage()
    {
        InitializeComponent();
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OrderPage");
    }

    private async void OnAddToBasketClicked(object sender, EventArgs e)
    {
        BasketManager.Instance.AddToBasket(Dish);
        HapticFeedback.Default.Perform(HapticFeedbackType.Click);
        await Toast.Make($"{Dish.Name} added to basket").Show();
        await Shell.Current.GoToAsync("..");
    }
}
