using SQLite;
using LocationTrackerApp.Models;

namespace LocationTrackerApp.Repositories;

public class LocationRepository : ILocationRepository
{
    private SQLiteAsyncConnection connection;
    private async Task CreateConnectionAsync()
    {
        if (connection != null)
        {
            return;
        }
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "locations.db");
        connection = new SQLiteAsyncConnection(databasePath);
        await connection.CreateTableAsync<Models.LocationData>();
    }
    public async Task SaveAsync(Models.LocationData locationEntry)
    {
        await CreateConnectionAsync();
        await connection.InsertAsync(locationEntry);
    }
    public async Task<List<LocationData>> GetAllAsync()
    {
        await CreateConnectionAsync();
        var locations = await connection.Table<LocationData>().ToListAsync();
        return locations;
    }
}