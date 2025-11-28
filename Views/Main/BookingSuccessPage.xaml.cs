using oculus_sport.ViewModels.Main;

namespace oculus_sport.Views.Main;

public partial class BookingSuccessPage : ContentPage
{
    public BookingSuccessPage(BookingSuccessViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    // REMOVED: OnBackButtonPressed override to allow navigation back
}