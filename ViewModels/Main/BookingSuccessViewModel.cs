using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using oculus_sport.Models;
using oculus_sport.ViewModels.Base;

namespace oculus_sport.ViewModels.Main;

[QueryProperty(nameof(Booking), "Booking")]
<<<<<<< HEAD
=======
[QueryProperty(nameof(IsFromHistory), "IsFromHistory")]
>>>>>>> master
public partial class BookingSuccessViewModel : BaseViewModel
{
    [ObservableProperty]
    private Booking _booking;

<<<<<<< HEAD
=======
    [ObservableProperty]
    private bool _isFromHistory;

>>>>>>> master
    public BookingSuccessViewModel()
    {
        Title = "Success";
    }

    [RelayCommand]
    async Task GoHome()
    {
<<<<<<< HEAD
        // Navigate back to the absolute root (Home Page), clearing the navigation stack
        await Shell.Current.GoToAsync("//HomePage");
=======
        if (IsFromHistory)
        {
            await Shell.Current.GoToAsync("..");

            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
>>>>>>> master
    }

    [RelayCommand]
    async Task ShareBooking()
    {
<<<<<<< HEAD
        // Placeholder for Share functionality
        if (Booking != null)
            await Shell.Current.DisplayAlert("Share", $"Sharing Booking ID: {Booking.Id}", "OK");
    }
}
=======
        if (Booking != null)
            await Shell.Current.DisplayAlert("Share", $"Sharing Booking ID: {Booking.Id}", "OK");
    }
}
>>>>>>> master
