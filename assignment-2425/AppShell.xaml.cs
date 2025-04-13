namespace assignment_2425
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("FullscreenImagePage", typeof(FullscreenImagePage));
            Routing.RegisterRoute(nameof(DishDetailPage), typeof(DishDetailPage));
            Routing.RegisterRoute(nameof(BasketPage), typeof(BasketPage));
            Routing.RegisterRoute(nameof(CheckoutPage), typeof(CheckoutPage));

        }
    }
}
