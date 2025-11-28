using oculus_sport.Models;

namespace oculus_sport.Services;

public interface IBookingService
{
    Task<List<Booking>> GetUserBookingsAsync(string userId);
    Task AddBookingAsync(Booking booking);
}