using LocationTrackerApp.Models;
using System;
using System.Threading.Tasks;

namespace LocationTrackerApp.Repositories;

public interface ILocationRepository
{
    Task SaveAsync(Models.LocationData location);
    Task<List<Models.LocationData>> GetAllAsync();
}
