using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocationTrackerApp.Repositories;
using LocationTrackerApp.Services;
using LocationTrackerApp.Models;

namespace LocationTrackerApp.ViewModels;
public partial class MainViewModel : ViewModel
{
    private readonly ILocationRepository locationRepository;
    private readonly ILocationTrackingService locationTrackingService;
    public MainViewModel(ILocationTrackingService locationTrackingService,
        ILocationRepository locationRepository)
    {
        this.locationTrackingService = locationTrackingService;
        this.locationRepository = locationRepository;
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            locationTrackingService.StartTracking();
            await LoadDataAsync();
        });
    }

    [ObservableProperty]
    private List<Models.Point> points;

    private async Task LoadDataAsync()
    {

        var locations = await locationRepository.GetAllAsync();
        var pointList = new List<Models.Point>();
        foreach (var location in locations)
        {
            //If no points exist, create a new one and continue to the next location in the list
            if (!pointList.Any())
            {
                pointList.Add(new Models.Point() { Location = location });
                continue;
            }
            var pointFound = false;
            //try to find a point for the current location
            foreach (var point in pointList)
            {
                var distance = Location.CalculateDistance(
                    new Location(point.Location.Latitude, point.Location.Longitude),
                    new Location(location.Latitude, location.Longitude),
                    DistanceUnits.Miles);
                if (distance < 0.2)
                {
                    pointFound = true;
                    point.Count++;
                    break;
                }
            }
            //if no point is found, add a new Point to the list of points
            if (!pointFound)
            {
                pointList.Add(new Models.Point() { Location = location });
            }
            if (pointList == null || !pointList.Any())
            {
                return;
            }
            var pointMax = pointList.Select(x => x.Count).Max();
            var pointMin = pointList.Select(x => x.Count).Min();
            var diff = (float)(pointMax - pointMin);
            foreach (var point in pointList)
            {
                var heat = (2f / 3f) - ((float)point.Count / diff);
                point.Heat = Color.FromHsla(heat, 1, 0.5);
            }
            Points = pointList;
        }
    }
    [RelayCommand]
    private async Task AddLegacyPoints()
    {
        // Adding legacy points for testing purposes
        var legacyPoints = new List<Models.Point>
        {
            new Models.Point { Location = new LocationData { Latitude = 37.7739, Longitude = -122.4312 } },
            new Models.Point { Location = new LocationData { Latitude = 37.8019, Longitude = -122.4188 } },
            new Models.Point { Location = new LocationData { Latitude = 37.8199, Longitude = -122.4786 } },
            new Models.Point { Location = new LocationData { Latitude = 37.7879, Longitude = -122.4228 } },
        };

        foreach (var point in legacyPoints)
        {
            await locationRepository.SaveAsync(point.Location);
        }
    }
}