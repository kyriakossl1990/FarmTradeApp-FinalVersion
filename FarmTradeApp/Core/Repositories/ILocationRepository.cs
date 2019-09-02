using System.Collections.Generic;
using FarmTradeApp.Core.Models;

namespace FarmTradeApp.Core.Repositories
{
    public interface ILocationRepository
    {
        void Add(Location location);
        Location GetLocation(int id);
        IEnumerable<Location> GetLocations();
        IEnumerable<Location> GetLocationsOrderedByCity();
        void Remove(Location location);
    }
}