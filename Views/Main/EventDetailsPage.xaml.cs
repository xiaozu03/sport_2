using oculus_sport.ViewModels.Main;

namespace oculus_sport.Views.Main;

public partial class EventDetailsPage : ContentPage
{
    public EventDetailsPage(EventDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}