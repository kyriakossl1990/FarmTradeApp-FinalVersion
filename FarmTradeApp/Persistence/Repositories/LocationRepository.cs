using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmTradeApp.Core.Repositories;

namespace FarmTradeApp.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Location GetLocation(int id)
        {
            return _context.Locations.Single(l => l.Id == id);
        }

        public IEnumerable<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public IEnumerable<Location> GetLocationsOrderedByCity()
        {
            return _context.Locations
                .OrderBy(l => l.City)
                .ToList();
        }

        public void Add(Location location)
        {
            _context.Locations.Add(location);
        }

        public void Remove(Location location)
        {
            _context.Locations.Remove(location);
        }
    }
}