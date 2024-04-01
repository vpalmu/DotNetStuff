namespace TravelingSalesmanProblemSolver
{
    public class Chromosome : IComparable<Chromosome>
    {
        public List<Location> Locations { get; }
        public double Fitness { get; private set; }

        // includes the time taken to travel back to the starting point
        public int[] travelTimesFromHereTo = new int[] { 0, 0, 0, 0, 0, 0, 0 };

        private readonly int _lowerBoundary;
        private readonly int _upperBoundary;

        public Chromosome(List<Location> locations, int lowerBoundary, int upperBoundary)
        {
            Locations = locations;
            _lowerBoundary = lowerBoundary;
            _upperBoundary = upperBoundary;
            CalculateFitness();
        }

        public void CalculateFitness()
        {
            int travelTimeInRoute = 0;
            int travelTime = 0;
            for (int i = 0; i < Locations.Count - 1; i++)
            {
                // one leg at the time
                travelTime = Locations[i].GetTravelTimeTo(Locations[i + 1]);  
                travelTimeInRoute += travelTime;
                travelTimesFromHereTo[i+1] = travelTime;
            }
            // final leg back to the starting point
            travelTime = Locations[Locations.Count - 1].GetTravelTimeTo(Locations[0]);
            travelTimesFromHereTo[Locations.Count] = travelTime;
            travelTimeInRoute += travelTime;

            Fitness = (double) 1 / travelTimeInRoute;
        }

        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < Locations.Count; i++)
            {
                if (new Random().NextDouble() < mutationRate)
                {
                    int index = new Random().Next(Locations.Count);
                    Location temp = Locations[i];
                    Locations[i] = Locations[index];
                    Locations[index] = temp;
                }
            }

            CalculateFitness();
        }

        public void Print()
        {
            string result = "";
            int index = 0;

            foreach (Location city in Locations)
            {
                result += $"{city.Name} -> ({travelTimesFromHereTo[index+1]} min) -> ";
                index++;
            }
            result += $"{Locations[0].Name} tot: {Convert.ToInt32(1 / this.Fitness)} min";
            Console.WriteLine(result);
        }

        public bool IsBetweenBoundaries()
        {
            var currentFitness = (double)1 / this.Fitness;
            bool isBetween = (currentFitness < _upperBoundary && currentFitness > _lowerBoundary);

            return isBetween;
        }

        public int CompareTo(Chromosome other)
        {
            return other.Fitness.CompareTo(Fitness);
        }
    }
}
