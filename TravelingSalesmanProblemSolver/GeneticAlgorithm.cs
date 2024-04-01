using System.Net.NetworkInformation;
using System.Threading.Channels;

namespace TravelingSalesmanProblemSolver
{
    public class GeneticAlgorithm
    {
        private List<Chromosome> _population;
        private double _mutationRate;
        private readonly int _lowerBoundary;
        private readonly int _upperBoundary;
        private int _populationSize;
        private List<Location> _locationsToVisit;

        public GeneticAlgorithm(List<Location> locationsToVisit, int populationSize, double mutationRate, int lowernBoundary, int upperBoundary)
        {
            _locationsToVisit = locationsToVisit;
            _populationSize = populationSize;
            _mutationRate = mutationRate;
            _lowerBoundary = lowernBoundary;
            _upperBoundary = upperBoundary;
            _population = new List<Chromosome>(_populationSize);
            InitializePopulation();
        }

        // This method initializes the population of the genetic algorithm with _populationSize number of chromosomes,
        // each representing a random route that visits all locations.
        private void InitializePopulation()
        {           
            for (int i = 0; i < _populationSize; i++)
            {
                Chromosome cr;
                List<Location> randomRoute = new List<Location>(_locationsToVisit);
                do
                {
                    randomRoute = randomRoute.OrderBy(x => new Random().Next()).ToList();
                    cr = new Chromosome(randomRoute, _lowerBoundary, _upperBoundary);

                } while (!cr.IsBetweenBoundaries());
               
                _population.Add(cr);
            }
        }       

        public Chromosome Run(int generations)
        {
            for (int i = 0; i < generations; i++)
            {
                List<Chromosome> newPopulation = new List<Chromosome>();
                _population.Sort();

                // Elitism: keep the best solutions
                int eliteSize = (int)(_populationSize * 0.1);
                for (int j = 0; j < eliteSize; j++)
                {
                    newPopulation.Add(_population[j]);
                }

                // Selection, crossover and mutation
                for (int j = eliteSize; j < _populationSize; j++)
                {
                    Chromosome parent1 = SelectParent();
                    Chromosome parent2 = SelectParent();

                    List<Location> childRoute = Crossover(parent1, parent2);
                    Chromosome child = new Chromosome(childRoute, _lowerBoundary, _upperBoundary);
                    child.Mutate(_mutationRate);

                    if (child.IsBetweenBoundaries())
                    {
                        //child.Print();
                        newPopulation.Add(child);
                    }
                }

                _population = newPopulation;
            }

            _population.Sort();            
            return _population[0]; // Best solution
        }

        // This method implements a selection strategy known as "fitness proportionate selection" or "roulette wheel selection",
        // where chromosomes with higher fitness have a higher chance of being selected as parents
        private Chromosome SelectParent()
        {
            double totalFitness = _population.Sum(ch => ch.Fitness);
            double target = new Random().NextDouble() * totalFitness;
            double currentSum = 0;

            foreach (Chromosome ch in _population)
            {
                currentSum += ch.Fitness;
                if (currentSum >= target)
                {
                    return ch;
                }
            }

            return _population[_population.Count - 1];
        }

        // This method implements a crossover strategy known as "ordered crossover" or "OX1",
        // which is a method used in genetic algorithms for the Traveling Salesman Problem (TSP)
        // to combine two parent solutions (routes) to produce a child solution.
        private List<Location> Crossover(Chromosome parent1, Chromosome parent2)
        {
            int start = new Random().Next(parent1.Locations.Count);
            int end = new Random().Next(start, parent1.Locations.Count);

            List<Location> childRoute = parent1.Locations.Skip(start).Take(end - start).ToList();
            List<Location> remainingCities = parent2.Locations.Except(childRoute).ToList();

            return childRoute.Concat(remainingCities).ToList();
        }
    }
}
