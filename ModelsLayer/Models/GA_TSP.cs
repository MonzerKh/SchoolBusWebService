using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    class GA_TSP

    {
        protected int cityCount;

        protected int populationSize;

        protected double mutationPercent;

        protected int matingPopulationSize;

        protected int favoredPopulationSize;

        protected int cutLength;

        protected int generation;

        protected Thread worker = null;

        protected bool started = false;

        protected City[] cities;

        protected Chromosome[] chromosomes;

        private string status = "";

        public GA_TSP()

        {

        }



        public void Initialization()

        {

            Random randObj = new Random();

            try

            {

                cityCount = 40;

                populationSize = 1000;

                mutationPercent = 0.05;

            }

            catch (Exception e)

            {

                cityCount = 100;

            }

            matingPopulationSize = populationSize / 2;

            favoredPopulationSize = matingPopulationSize / 2;

            cutLength = cityCount / 5;

            // create a random list of cities

            cities = new City[cityCount];

            for (int i = 0; i < cityCount; i++)

            {

                cities[i] = new City(

                          (int)(randObj.NextDouble() * 30), (int)(randObj.NextDouble() * 15));

            }



            // create the initial chromosomes

            chromosomes = new Chromosome[populationSize];

            for (int i = 0; i < populationSize; i++)

            {

                chromosomes[i] = new Chromosome(cities);

                chromosomes[i].assignCut(cutLength);

                chromosomes[i].assignMutation(mutationPercent);

            }

            Chromosome.sortChromosomes(chromosomes, populationSize);

            started = true;

            generation = 0;

        }



        public void TSPCompute()

        {

            double thisCost = 500.0;

            double oldCost = 0.0;

            double dcost = 500.0;

            int countSame = 0;

            Random randObj = new Random();

            while (countSame < 120)

            {

                generation++;

                int ioffset = matingPopulationSize;

                int mutated = 0;

                for (int i = 0; i < favoredPopulationSize; i++)

                {

                    Chromosome cmother = chromosomes[i];

                    int father = (int)(randObj.NextDouble() * (double)matingPopulationSize);

                    Chromosome cfather = chromosomes[father];

                    mutated += cmother.mate(cfather, chromosomes[ioffset], chromosomes[ioffset + 1]);

                    ioffset += 2;

                }

                for (int i = 0; i < matingPopulationSize; i++)

                {

                    chromosomes[i] = chromosomes[i + matingPopulationSize];

                    chromosomes[i].calculateCost(cities);

                }

                // Now sort the new population

                Chromosome.sortChromosomes(chromosomes, matingPopulationSize);

                double cost = chromosomes[0].getCost();

                dcost = Math.Abs(cost - thisCost);

                thisCost = cost;

                double mutationRate = 100.0 * (double)mutated / (double)matingPopulationSize;

                System.Console.WriteLine("Generation = " + generation.ToString() + " Cost = " + thisCost.ToString() + " Mutated Rate = " + mutationRate.ToString() + "%");

                if ((int)thisCost == (int)oldCost)

                {

                    countSame++;

                }

                else

                {

                    countSame = 0;

                    oldCost = thisCost;

                    //System.Console.WriteLine("oldCost = " + oldCost.ToString());

                }

            }

            for (int i = 0; i < cities.Length; i++)

            {

                chromosomes[i].PrintCity(i, cities);

            }

        }
    }
}
