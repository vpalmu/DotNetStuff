namespace TravelingSalesmanProblemSolver
{
    public class Program
    {       
        static void Main(string[] args)
        {
            int _lowerBoundary = 132;
            int _upperBoundary = 159;
            int _populationSize = 100;
            double _mutationRate = 0.01;

            int[] locationTravelTimes1 = new int[] { 0, 23, 31, 39, 39, 26 };
            int[] locationTravelTimes2 = new int[] { 23, 0, 26, 29, 24, 18 };
            int[] locationTravelTimes3 = new int[] { 31, 26, 0, 13, 37, 27 };
            int[] locationTravelTimes4 = new int[] { 39, 29, 13, 0, 36, 25 };
            int[] locationTravelTimes5 = new int[] { 39, 24, 37, 36, 0, 27 };
            int[] locationTravelTimes6 = new int[] { 26, 18, 27, 25, 27, 0 };

            List<Location> locationsToVisit = new List<Location>
            {
                new Location(id: 1, name: "I", locationTravelTimes: locationTravelTimes1),
                new Location(id: 2, name: "K", locationTravelTimes: locationTravelTimes2),
                new Location(id: 3, name: "M", locationTravelTimes: locationTravelTimes3),
                new Location(id: 4, name: "P", locationTravelTimes: locationTravelTimes4),
                new Location(id: 5, name: "Q", locationTravelTimes: locationTravelTimes5),
                new Location(id: 6, name: "W", locationTravelTimes: locationTravelTimes6)
            };

            Console.WriteLine("Initializing...");
            Console.WriteLine($"Parameters:");
            Console.WriteLine($"- Population size: {_populationSize}");
            Console.WriteLine($"- Mutation rate: {_mutationRate}");
            Console.WriteLine($"- Lower boundary: {_lowerBoundary} minutes");
            Console.WriteLine($"- Upper boundary: {_upperBoundary} minutes");

            GeneticAlgorithm ga = new GeneticAlgorithm(
                locationsToVisit: locationsToVisit,
                populationSize: _populationSize, mutationRate: _mutationRate,
                lowernBoundary: _lowerBoundary, upperBoundary: _upperBoundary 
            );

           

            Console.WriteLine("Looking for best solution...");
            Chromosome bestSolution = ga.Run(1000);

            Console.WriteLine("");
            Console.WriteLine("Fastest route found:");
            Console.WriteLine("");

            bestSolution.Print();
            Console.WriteLine("");

            Console.WriteLine($"Total travel time: {Convert.ToInt32(1 / bestSolution.Fitness)} min");
            Console.WriteLine("");

            Console.WriteLine("Press anykey to exit");
            Console.ReadKey();

            System.Environment.Exit(0);
        }   
    }
}