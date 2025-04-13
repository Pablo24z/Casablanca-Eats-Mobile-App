using assignment_2425.Models;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Controls;
using System;

namespace assignment_2425;

// Accepts a query parameter when navigating to this page (dish passed from OrderPage)
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
            BindingContext = _dish; // Bind the dish info to the UI
        }
    }

    public DishDetailPage()
    {
        InitializeComponent();
    }

    // Called when the close (X) button is tapped
    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OrderPage");
    }

    // Called when "Add to Basket" button is tapped
    private async void OnAddToBasketClicked(object sender, EventArgs e)
    {
        // Add item to basket, give haptic feedback and show confirmation toast
        BasketManager.Instance.AddToBasket(Dish);
        HapticFeedback.Default.Perform(HapticFeedbackType.Click);
        await Toast.Make($"{Dish.Name} added to basket").Show();

        // Navigate back to previous screen
        await Shell.Current.GoToAsync("..");
    }
}
