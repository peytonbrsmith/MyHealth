using System;

using myhealth.ViewModels;

using myhealth.Core.Helpers;
using myhealth.Core.Services;
using myhealth.Helpers;
using myhealth.Services;

using Windows.ApplicationModel.Core;
using System.ComponentModel;

using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;


namespace myhealth.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView, KeyboardAccelerators);
            //Window.Current.SetTitleBar(AppTitleBar);
            //_coreTitleBar.ExtendViewIntoTitleBar = true;
            //_coreTitleBar.Visibility = Visibility.Collapsed;
            //Window.Current.SetTitleBar(null);
            ThemeSelectorService.UpdateSystemCaptionButtonColors();
        }

        private void NavigationView_OnCollapsed(NavigationView sender, NavigationViewItemCollapsedEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
