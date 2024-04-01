using System.Runtime.InteropServices;

namespace TravelingSalesmanProblemSolver
{
    public class Location
    {
        public int Id { get; }
        public string Name { get; }
        int[] LocationTravelTimes { get; }


        public Location(int id, string name, int[] locationTravelTimes)
        {
            Id = id;
            LocationTravelTimes = locationTravelTimes;
            Name = name;
        }

        public int GetTravelTimeTo(Location other)
        {
            return LocationTravelTimes[other.Id - 1];
        }
    }
}
