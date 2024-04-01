
# Genetic Algorithm for the Traveling Salesman Problem

This project implements a genetic algorithm to solve the Traveling Salesman Problem(TSP) as described below:

Theory: https://visualstudiomagazine.com/Articles/2022/12/20/traveling-salesman-problem.aspx?Page=1
Code: https://bilenmehmet.com/gonderi/traveling_salesman_genetic_algorithms_cSharp


## Code Explanation

### InitializePopulation Method

            This method initializes the population of the genetic algorithm with `_populationSize` number of chromosomes, 
            each representing a random route that visits all cities.

### SelectParent Method

            This method implements a selection strategy known as "fitness proportionate selection" or "roulette wheel selection", 
            where chromosomes with higher fitness have a higher chance of being selected as parents.

### Crossover Method

            This method implements a crossover strategy known as "ordered crossover" or "OX1", which is a method used in genetic 
            algorithms for the TSP to combine two parent solutions(routes) to produce a child solution.

### Mutate Method

            This method implements a mutation strategy where each city in the chromosome has a chance to be swapped with another 
            city, based on the `mutationRate`. The purpose of mutation in a genetic algorithm is to maintain and introduce diversity
            in the population, which can help prevent the algorithm from getting stuck in local optima.
            