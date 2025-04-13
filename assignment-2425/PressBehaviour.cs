using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using assignment_2425.Models;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;

namespace assignment_2425
{
    public class PressBehaviour : Behavior<View>
    {
        private DateTime _pressStart;
        private bool _longPressHandled;

        public static readonly BindableProperty DishProperty =
            BindableProperty.Create(nameof(Dish), typeof(DishItem), typeof(PressBehaviour));

        public DishItem Dish
        {
            get => (DishItem)GetValue(DishProperty);
            set => SetValue(DishProperty, value);
        }

        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);

            // Setup gestures
            var tapGesture = new TapGestureRecognizer();

            tapGesture.Tapped += async (s, e) =>
            {
                var now = DateTime.UtcNow;
                var duration = now - _pressStart;

                if (Dish == null)
                    return;

                if (duration.TotalMilliseconds >= 600)
                {
                    _longPressHandled = true;

                    if (Shell.Current?.CurrentPage is OrderPage orderPage)
                        await orderPage.AddToBasketWithFeedback(Dish);
                }
                else
                {
                    if (Shell.Current?.CurrentPage is OrderPage orderPage)
                        await orderPage.NavigateToDetailPage(Dish);
                }
            };

            tapGesture.Command = new Command(() =>
            {
                _pressStart = DateTime.UtcNow;
                _longPressHandled = false;
            });

            bindable.GestureRecognizers.Add(tapGesture);

            bindable.BindingContextChanged += (s, e) =>
            {
                if (bindable.BindingContext is DishItem item)
                    Dish = item;
            };
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.GestureRecognizers.Clear(); // Clean up
        }
    }
}
