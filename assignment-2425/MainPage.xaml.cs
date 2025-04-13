#if ANDROID
using Android.Locations;
#endif

using System.Text.Json;
using System.Reflection;
using System.Threading;

namespace assignment_2425
{
    public partial class MainPage : ContentPage
    {
        private List<string> _slideshowImages = new();
        private int _currentImangeIndex = 0;
        private CancellationTokenSource _rotationCancellationTokenSource;

        public MainPage()
        {
            InitializeComponent();
            LoadSlideshowImagesFromJsonFile();

            // Automatically switch logo when theme changes (dark/light)
            SetHeroLogo(App.Current.RequestedTheme);
            App.Current.RequestedThemeChanged += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    SetHeroLogo(e.RequestedTheme);
                });
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartSlideshow(); // Begin image rotation
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StopSlideshow(); // Stop when user navigates away
        }

        // Loads image filenames from an embedded JSON resource
        private void LoadSlideshowImagesFromJsonFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "assignment_2425.Resources.Data.slideshow.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            string json = reader.ReadToEnd();

            _slideshowImages = JsonSerializer.Deserialize<List<string>>(json);

            // Set first image right away
            SlideshowImage.Source = _slideshowImages[_currentImangeIndex];
        }

        // Rotates images with a fade effect every 6 seconds
        private void StartSlideshow()
        {
            StopSlideshow(); // Clean previous run
            _rotationCancellationTokenSource = new CancellationTokenSource();
            var token = _rotationCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    _currentImangeIndex = (_currentImangeIndex + 1) % _slideshowImages.Count;

                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await SlideshowImage.FadeTo(0, 1000); // Fade out
                        SlideshowImage.Source = _slideshowImages[_currentImangeIndex];
                        await SlideshowImage.FadeTo(1, 2000); // Fade in
                    });

                    try
                    {
                        await Task.Delay(6000, token);
                    }
                    catch (TaskCanceledException)
                    {
                        break; // Safely exit if cancelled
                    }
                }
            }, token);
        }

        // Stops the rotating slideshow task
        private void StopSlideshow()
        {
            if (_rotationCancellationTokenSource != null)
            {
                _rotationCancellationTokenSource.Cancel();
                _rotationCancellationTokenSource.Dispose();
                _rotationCancellationTokenSource = null;
            }
        }

        // Fades in the appropriate hero logo based on the current theme
        private async void SetHeroLogo(AppTheme theme)
        {
            await HeroLogo.FadeTo(0, 150); // Fade out

            HeroLogo.Source = theme == AppTheme.Dark
                ? "casalogocomplex_dark.png"
                : "casalogocomplex_light.png";

            await HeroLogo.FadeTo(1, 250); // Fade in
        }
    }
}
