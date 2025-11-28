using oculus_sport.Models;

namespace oculus_sport.Services;

public class BookingService : IBookingService
{
    // In-memory list to store bookings while the app is running
    private readonly List<Booking> _bookings = new();

    public async Task<List<Booking>> GetUserBookingsAsync(string userId)
    {
        // Simulate network delay
        await Task.Delay(500);

        // Return all bookings (filtering by UserID would happen here in a real app)
        return _bookings.OrderBy(b => b.Date).ToList();
    }

    public async Task AddBookingAsync(Booking booking)
    {
        await Task.Delay(500);
        _bookings.Add(booking);
    }
}