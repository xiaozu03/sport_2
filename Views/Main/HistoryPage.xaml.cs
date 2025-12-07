using Microsoft.Maui.Controls;
using oculus_sport.ViewModels.Main;

namespace oculus_sport.Views.Main;

public partial class HistoryPage : ContentPage
{
    private readonly HistoryPageViewModel _viewModel;
    public HistoryPage(HistoryPageViewModel vm)
    {
        InitializeComponent();
        //_viewModel = vm;
        BindingContext = vm; // Set BindingContext directly
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Force refresh every time the user opens this tab
        if (BindingContext is HistoryPageViewModel viewModel)
        {
            viewModel.OnAppearing();
        }

    }
}