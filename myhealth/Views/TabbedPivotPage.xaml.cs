using System;

using myhealth.ViewModels;

using Windows.UI.Xaml.Controls;

namespace myhealth.Views
{
    public sealed partial class TabbedPivotPage : Page
    {
        public TabbedPivotViewModel ViewModel { get; } = new TabbedPivotViewModel();

        public TabbedPivotPage()
        {
            InitializeComponent();
        }
    }
}
