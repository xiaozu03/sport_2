using CommunityToolkit.Mvvm.ComponentModel;

namespace oculus_sport.Models;

public partial class TimeSlot : ObservableObject
{
    // The missing property causing the error
    public string TimeRange { get; set; } = string.Empty;

    public TimeSpan StartTime { get; set; }
    public bool IsAvailable { get; set; } = true;

    [ObservableProperty]
    private bool _isSelected;
}