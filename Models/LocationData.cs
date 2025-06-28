using SQLite;

namespace LocationTrackerApp.Models;

public class LocationData
{
    public LocationData() { }
    public LocationData(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
    
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

}