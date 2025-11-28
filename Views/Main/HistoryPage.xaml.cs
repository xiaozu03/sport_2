using oculus_sport.ViewModels.Main;

namespace oculus_sport.Views.Main;

public partial class HistoryPage : ContentPage
{
    private readonly HistoryPageViewModel _viewModel;

    public HistoryPage(HistoryPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Force refresh every time the user opens this tab
        if (_viewModel.LoadBookingsCommand.CanExecute(null))
        {
            _viewModel.LoadBookingsCommand.Execute(null);
        }
    }
}