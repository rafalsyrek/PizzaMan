using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace PizzaManDelivery
{
    class SA
    {
        private const int inf = 0;
        private List<List<int>> permsList = new List<List<int>>();
        private int deliverers;
        private int adresses;
        private List<List<int>> schedule = new List<List<int>>();
        private List<Task> tasks = new List<Task>();

        public SA(List<Task> tasks, int deliverers, int addresses)
        {
            this.tasks = tasks;
            this.deliverers = deliverers;
            this.adresses = addresses;
        }

        public List<List<int>> getPermList()
        {
            return this.permsList;
        }

        public int getCMax()
        {
            return this.cMax();
        }

        public void execute()
        {
            this.fillSchedule();
            this.fillPerms();
            List<int> temp = this.descendingAlgorithm();
            List<int> temp2 = this.simulatedAnnealing();
            int b = cMax();
            int a = 1;
        }

        private void fillSchedule()
        {
            for(int i = 0; i < this.adresses; i++)
            {
                this.schedule.Add(new List<int>());
                for (int j = 0; j < this.adresses; j++)
                {
                    this.schedule[i].Add(0);
                }
                this.schedule[i][i] = inf;
            }
            int index = 0;
            for (int i = 0; i < this.adresses; i++)
            {
                for (int j = 0; j < this.adresses; j++)
                {
                    if (i != j)
                    {
                        this.schedule[i][j] = this.tasks[index].getTime();
                        index++;
                    }
                }
            }

        }

        private void fillPerms()
        {
            for(int i = 0; i<this.deliverers; i++)
            {
                permsList.Add(new List<int>());
                permsList[i].Add(0);
            }
            for (int i = 1; i < this.adresses; i++ )
            {
                permsList[0].Add(i);
            }
            for(int i = 0; i<deliverers; i++)
            {
                permsList[i].Add(0);
            }
        }

        private int cMax()
        {
            List<int> cMaxes = new List<int>();
            int index = 0;
            foreach (List<int> perm in permsList)
            {
                cMaxes.Add(0);
                for(int i = 0; i<perm.Count - 1; i++)
                {
                    cMaxes[index] += schedule[perm[i]][perm[i+1]];
                }
                index++;
            }
            return cMaxes.Max();
        }

        private List<int> descendingAlgorithm()
        {
            Random rnd = new Random();
            List<int> cMaxes = new List<int>();
            int bestCMax = this.cMax();
            cMaxes.Add(bestCMax);
            int tempCMax = 0;
            List<List<int>> bestPerms = new List<List<int>>();
            
            //Skopiuj liste przez wartość
            bestPerms = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
            {
                return Branch.ConvertAll<int>(delegate(int Leaf){return Leaf;});
            });

            for (int i = 0; i < 100; i++)
            {
                int deliverySource = rnd.Next(0, deliverers);
                if (!isTaskOnPermutationListOfDeliverer(deliverySource)) continue;
                int taskSource = rnd.Next(1, permsList[deliverySource].Count - 1);
           
                int deliveryTarget = rnd.Next(0, deliverers);
                int taskTarget = rnd.Next(1, permsList[deliveryTarget].Count);
                if (isSourceEqualToTarget(deliverySource, taskSource, deliveryTarget, taskTarget)) continue;

                //Podmień task
                permsList[deliveryTarget].Insert(taskTarget, permsList[deliverySource][taskSource]);
                if (isInjectionMovingSourceIndex(deliverySource, taskSource, deliveryTarget, taskTarget))
                {
                    permsList[deliverySource].RemoveAt(taskSource + 1);
                }
                else permsList[deliverySource].RemoveAt(taskSource);

                tempCMax = this.cMax();
                cMaxes.Add(tempCMax);

                //Zamień globalny wynik jeżeli jest poprawa
                if (tempCMax < bestCMax)
                {
                    bestCMax = tempCMax;

                    //Skopiuj liste przez wartość
                    bestPerms = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
                    {
                        return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
                    });

                }

                //Przywróć wartości dotychczasowe, jeśli brak poprawy
                else
                {
                    //Skopiuj liste przez wartość
                    permsList = bestPerms.ConvertAll<List<int>>(delegate(List<int> Branch)
                    {
                        return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
                    });
                }
            }
            return cMaxes;
        }

        private static bool isInjectionMovingSourceIndex(int deliverySource, int taskSource, int deliveryTarget, int taskTarget)
        {
            return deliverySource == deliveryTarget && taskSource > taskTarget;
        }

        private static bool isSourceEqualToTarget(int deliverySource, int taskSource, int deliveryTarget, int taskTarget)
        {
            return deliverySource == deliveryTarget && (taskSource == taskTarget || taskSource == taskTarget + 1);
        }

        private bool isTaskOnPermutationListOfDeliverer(int deliverySource)
        {
            return permsList[deliverySource].Count > 2;
        }

        private List<int> simulatedAnnealing()
        {
            double Temperature = 1000000;
            Random rnd = new Random();
            List<int> cMaxes = new List<int>();
            int bestCMax = this.cMax();
            cMaxes.Add(bestCMax);
            int tempCMax = 0;
            int cMaxBeforeSwap = 0;
            List<List<int>> permsBeforeSwap = new List<List<int>>();

            //Skopiuj liste przez wartość
            permsBeforeSwap = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
            {
                return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
            });

            List<List<int>> bestPerms = new List<List<int>>();

            //Skopiuj liste przez wartość
            bestPerms = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
            {
                return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
            });

            while (Temperature > 0.1)
            {
                
                cMaxBeforeSwap = cMax();

                int deliverySource = rnd.Next(0, deliverers);
                if (!isTaskOnPermutationListOfDeliverer(deliverySource)) continue;
                int taskSource = rnd.Next(1, permsList[deliverySource].Count - 1);

                int deliveryTarget = rnd.Next(0, deliverers);
                int taskTarget = rnd.Next(1, permsList[deliveryTarget].Count);
                if (isSourceEqualToTarget(deliverySource, taskSource, deliveryTarget, taskTarget)) continue;

                //Podmień task
                permsList[deliveryTarget].Insert(taskTarget, permsList[deliverySource][taskSource]);
                if (isInjectionMovingSourceIndex(deliverySource, taskSource, deliveryTarget, taskTarget))
                {
                    permsList[deliverySource].RemoveAt(taskSource + 1);
                }
                else permsList[deliverySource].RemoveAt(taskSource);

                tempCMax = this.cMax();
                cMaxes.Add(tempCMax);

                //Zamień globalny wynik jeżeli jest poprawa
                if (tempCMax < bestCMax)
                {
                    bestCMax = tempCMax;

                    //Skopiuj liste przez wartość
                    bestPerms = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
                    {
                        return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
                    });

                    //Skopiuj liste przez wartość
                    permsBeforeSwap = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
                    {
                        return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
                    });
                }

                //Przyjmij z prawdopodobieństem jeśli brak poprawy
                else
                {
                    double exponent = Math.Exp((cMaxBeforeSwap - tempCMax) / (Temperature));
                    double Random = rnd.NextDouble();

                    //Przywróć permutację sprzed zmian
                    if (Random < exponent)
                    {

                        //Skopiuj liste przez wartość
                        permsBeforeSwap = permsList.ConvertAll<List<int>>(delegate(List<int> Branch)
                        {
                            return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
                        });
                    }

                    //Działaj na nowej permutacji ale nie zaposuj jej jako globalnie najlepsza
                    else
                    {

                        //Skopiuj liste przez wartość
                        permsList = permsBeforeSwap.ConvertAll<List<int>>(delegate(List<int> Branch)
                        {
                            return Branch.ConvertAll<int>(delegate(int Leaf) { return Leaf; });
                        });
                    }
                }
                Temperature = Temperature * 0.9999;
            }
            return cMaxes;
        }
       
    }
}
