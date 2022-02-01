using System;

using myhealth.ViewModels;

using Windows.UI.Xaml.Controls;

namespace myhealth.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
