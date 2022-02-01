using System;

using myhealth.ViewModels;

using Windows.UI.Xaml.Controls;

namespace myhealth.Views
{
    public sealed partial class BlankPage : Page
    {
        public BlankViewModel ViewModel { get; } = new BlankViewModel();

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
