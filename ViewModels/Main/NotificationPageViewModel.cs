using CommunityToolkit.Mvvm.ComponentModel;
using oculus_sport.Models;
using oculus_sport.ViewModels.Base;
using System.Collections.ObjectModel;

namespace oculus_sport.ViewModels.Main;

public partial class NotificationPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<NotificationItem> _notifications = new();

    public NotificationPageViewModel()
    {
        Title = "Notifications";
        LoadNotifications();
    }

    private void LoadNotifications()
    {
        Notifications = new ObservableCollection<NotificationItem>
        {
            new NotificationItem
            {
                Title = "Booking Confirmed",
                Message = "Your booking for Badminton Court 1 has been confirmed.",
                Time = "2 mins ago",
                IsRead = false
            },
            new NotificationItem
            {
                Title = "System Maintenance",
                Message = "The app will be undergoing maintenance on Sunday 2AM-4AM.",
                Time = "1 hour ago",
                IsRead = true
            },
            new NotificationItem
            {
                Title = "New Event: Basketball Cup",
                Message = "Registration is now open for the Inter-Faculty Basketball Cup.",
                Time = "Yesterday",
                IsRead = true
            }
        };
    }
}