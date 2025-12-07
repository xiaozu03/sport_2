using CommunityToolkit.Mvvm.ComponentModel;
using oculus_sport.Models;
using oculus_sport.ViewModels.Base;

namespace oculus_sport.ViewModels.Main;

[QueryProperty(nameof(SportEvent), "SportEvent")]
public partial class EventDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private SportEvent _sportEvent;

    public EventDetailsViewModel()
    {
        Title = "Event Details";
    }
}