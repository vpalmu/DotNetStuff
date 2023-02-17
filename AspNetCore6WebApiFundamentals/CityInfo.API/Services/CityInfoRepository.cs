using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext cityInforContext)
        {
            _context = cityInforContext ?? throw new ArgumentNullException(nameof(cityInforContext));
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(string? name, string? searchQuery)
        {
            if (string.IsNullOrWhiteSpace(name) && 
                string.IsNullOrWhiteSpace(searchQuery))
            {
                return await GetCitiesAsync();
            }

            var collection = _context.Cities as IQueryable<City>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery)) 
            { 
                searchQuery = searchQuery.Trim();

                collection = collection.Where(
                    n => n.Name.Contains(searchQuery) || 
                    (
                        n.Description != null && 
                        n.Description.Contains(searchQuery)
                    )
                );
            }

            return await collection.OrderBy(c => c.Name)
                                   .ToListAsync();
        }

        public async Task<City?> GetCityAsync(int CityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return await _context.Cities.Include(c => c.PointsOfInterest)
                                            .Where(c=> c.Id == CityId)
                                            .FirstOrDefaultAsync();
            }
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == CityId); 
        }

        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
           return await _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
                                                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest.Where(p => p.CityId == cityId)
                                                  .ToListAsync();
        }

        public async Task<bool> CityExists(int cityId) 
        { 
            return await _context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);

            if (city != null)
            {
                city.PointsOfInterest.Add(pointOfInterest);
            }  
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
    }
}
