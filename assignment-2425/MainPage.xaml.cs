#if ANDROID
using Android.Locations;
#endif

using System.Text.Json;
using System.Reflection;

namespace assignment_2425
{
    public partial class MainPage : ContentPage
    {
        private List<string> _slideshowImages = new();
        private int _currentImangeIndex = 0;
        private System.Timers.Timer _imageTimer;
        public MainPage()
        {
            InitializeComponent();
            LoadSlideshowImagesFromJsonFile();

            SetHeroLogo(App.Current.RequestedTheme);

            App.Current.RequestedThemeChanged += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    SetHeroLogo(e.RequestedTheme);
                });
            };
        }

        private void LoadSlideshowImagesFromJsonFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "assignment_2425.Resources.Data.slideshow.json";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);
            string json = reader.ReadToEnd();

            _slideshowImages = JsonSerializer.Deserialize<List<string>>(json);

            //starts slideshow after being loaded
            SlideshowImage.Source = _slideshowImages[_currentImangeIndex];
            StartSlideshow();
        }

        private void StartSlideshow()
        {
            _imageTimer = new System.Timers.Timer(6000); //6 secs
            _imageTimer.Elapsed += (s, e) =>
                MainThread.BeginInvokeOnMainThread(() => RotateImage());
            _imageTimer.AutoReset = true;
            _imageTimer.Start();
        }

        private async void RotateImage()
        {
            _currentImangeIndex = (_currentImangeIndex + 1) % _slideshowImages.Count;

            await SlideshowImage.FadeTo(0, 1000);
            SlideshowImage.Source = _slideshowImages[_currentImangeIndex];
            await SlideshowImage.FadeTo(1, 2000);
        }

        private async void SetHeroLogo(AppTheme theme)
        {
            await HeroLogo.FadeTo(0, 150); // fade out

            HeroLogo.Source = theme == AppTheme.Dark
                ? "casalogosimple_dark.png"
                : "casalogosimple_light.png";

            await HeroLogo.FadeTo(1, 250); // fade in
        }


    }

}