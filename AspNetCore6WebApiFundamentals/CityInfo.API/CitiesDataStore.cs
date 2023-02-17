using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        //public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() { 
                    Id = 1, Name = "New York", Description = "Big Apple", 
                    PointsOfInterest = new List<PointOfInterestDto>() {
                        new PointOfInterestDto() {
                            Id=1, Name ="point 1", Description = "desc"
                        },
                        new PointOfInterestDto() {
                            Id=2, Name ="point 2", Description = "desc 2"
                        }
                    }
                },
                new CityDto() { Id = 2, Name = "Paris", Description = "Eiffel tower",
                    PointsOfInterest = new List<PointOfInterestDto>() {
                        new PointOfInterestDto() {
                            Id=3, Name ="point 3", Description = "desc 3"
                        },
                        new PointOfInterestDto() {
                            Id=4, Name ="point 4", Description = "desc 4"
                        }
                    }
                },
                new CityDto() { Id = 3, Name = "Antwerp", Description = "Catherdal (unfinished)",
                    PointsOfInterest = new List<PointOfInterestDto>() {
                        new PointOfInterestDto() {
                            Id=5, Name ="point 5", Description = "desc 5"
                        },
                        new PointOfInterestDto() {
                            Id=6, Name ="point 6", Description = "desc 6"
                        }
                    }
                },
            };
        }
    }
}
