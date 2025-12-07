namespace oculus_sport.Models;

public class NotificationItem
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty; // e.g. "10 mins ago"
    public bool IsRead { get; set; }
}