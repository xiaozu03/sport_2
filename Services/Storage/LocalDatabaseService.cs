using SQLite;
using oculus_sport.Models;

namespace oculus_sport.Services.Storage;

public class LocalDatabaseService
{
    private SQLiteAsyncConnection _database;

    async Task Init()
    {
        if (_database is not null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "OculusSport.db3");

        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<Booking>();
    }

    public async Task<List<Booking>> GetBookingsAsync()
    {
        await Init();
        return await _database.Table<Booking>().ToListAsync();
    }

    public async Task SaveBookingsAsync(List<Booking> bookings)
    {
        await Init();
        if (bookings != null && bookings.Count > 0)
        {
            await _database.DeleteAllAsync<Booking>();
            await _database.InsertAllAsync(bookings);
        }
    }
}