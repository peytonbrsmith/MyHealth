using System;
using System.Threading.Tasks;

using myhealth.Helpers;

using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace myhealth.Services
{
    public static class ThemeSelectorService
    {
        private const string SettingsKey = "AppBackgroundRequestedTheme";
        //private static UISettings uiSettings;
        private static Window CurrentApplicationWindow;

        public static ElementTheme Theme { get; set; } = ElementTheme.Default;

        public static async Task InitializeAsync()
        {
            Theme = await LoadThemeFromSettingsAsync();      
        }


        public static async Task SetThemeAsync(ElementTheme theme)
        {
            Theme = theme;

            await SetRequestedThemeAsync();
            await SaveThemeInSettingsAsync(Theme);
            UpdateSystemCaptionButtonColors();
        }

        public static async Task SetRequestedThemeAsync()
        {
            foreach (var view in CoreApplication.Views)
            {
                await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (Window.Current.Content is FrameworkElement frameworkElement)
                    {
                        frameworkElement.RequestedTheme = Theme;
                    }
                });
            }
        }

        private static async Task<ElementTheme> LoadThemeFromSettingsAsync()
        {
            ElementTheme cacheTheme = ElementTheme.Default;
            string themeName = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKey);

            if (!string.IsNullOrEmpty(themeName))
            {
                Enum.TryParse(themeName, out cacheTheme);
            }

            return cacheTheme;
        }

        private static async Task SaveThemeInSettingsAsync(ElementTheme theme)
        {
            await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKey, theme.ToString());
        }

        public static bool IsDarkTheme()
        {
            if (Theme == ElementTheme.Default)
            {
                return Application.Current.RequestedTheme == ApplicationTheme.Dark;
            }
            return Theme == ElementTheme.Dark;
        }

        public static void UpdateSystemCaptionButtonColors()
        {
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            if (ThemeSelectorService.IsDarkTheme())
            {
                titleBar.ButtonForegroundColor = Colors.White;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonHoverForegroundColor = Colors.White;
                titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 90, 90, 90);
                titleBar.ButtonPressedForegroundColor = Colors.White;
                titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 120, 120, 120);

                // Set inactive window colors
                titleBar.InactiveForegroundColor = Colors.Gray;
                titleBar.InactiveBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveForegroundColor = Colors.Gray;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

                titleBar.BackgroundColor = Color.FromArgb(255, 45, 45, 45);
            }
            else
            {
                titleBar.ButtonForegroundColor = Colors.Black;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonHoverForegroundColor = Colors.Black;
                titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 180, 180, 180);
                titleBar.ButtonPressedForegroundColor = Colors.Black;
                titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 150, 150, 150);

                // Set inactive window colors
                titleBar.InactiveForegroundColor = Colors.DimGray;
                titleBar.InactiveBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveForegroundColor = Colors.DimGray;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

                titleBar.BackgroundColor = Color.FromArgb(255, 210, 210, 210);
            }
        }

        //private static async Task ApplyThemeForTitleBarButtons()
        //{
        //    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

        //    //ElementTheme theme = ThemeSelectorService.Theme;
        //    //if (theme == ElementTheme.Default)
        //    //{
                

        //    ElementTheme.Default.
        //    if (Theme == ElementTheme.Dark)
        //    {
        //        // Set active window colors
        //        titleBar.ButtonForegroundColor = Colors.White;
        //        titleBar.ButtonBackgroundColor = Colors.Transparent;
        //        titleBar.ButtonHoverForegroundColor = Colors.White;
        //        titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 90, 90, 90);
        //        titleBar.ButtonPressedForegroundColor = Colors.White;
        //        titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 120, 120, 120);

        //        // Set inactive window colors
        //        titleBar.InactiveForegroundColor = Colors.Gray;
        //        titleBar.InactiveBackgroundColor = Colors.Transparent;
        //        titleBar.ButtonInactiveForegroundColor = Colors.Gray;
        //        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

        //        titleBar.BackgroundColor = Color.FromArgb(255, 45, 45, 45);
        //    }
        //    else if (Theme == ElementTheme.Light)
        //    {
        //        // Set active window colors
        //        titleBar.ButtonForegroundColor = Colors.Black;
        //        titleBar.ButtonBackgroundColor = Colors.Transparent;
        //        titleBar.ButtonHoverForegroundColor = Colors.Black;
        //        titleBar.ButtonHoverBackgroundColor = Color.FromArgb(255, 180, 180, 180);
        //        titleBar.ButtonPressedForegroundColor = Colors.Black;
        //        titleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 150, 150, 150);

        //        // Set inactive window colors
        //        titleBar.InactiveForegroundColor = Colors.DimGray;
        //        titleBar.InactiveBackgroundColor = Colors.Transparent;
        //        titleBar.ButtonInactiveForegroundColor = Colors.DimGray;
        //        titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

        //        titleBar.BackgroundColor = Color.FromArgb(255, 210, 210, 210);
        //    }
        //}
    }
}
