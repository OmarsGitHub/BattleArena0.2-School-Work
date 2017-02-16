using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena0._2
{
    class Character
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Score { get; set; }
        public string CurrentEnemy { get; set; }
        public List<string> defeatedEnemies = new List<string>();

        /// <summary>
        /// Skriver ut Karaktären till konsolen.
        /// </summary>
        public void DisplayCharacter()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Strength: {0}", Strength);
            Console.WriteLine("Damage: {0}", Damage);
            Console.WriteLine("Health: {0}", Health);
        }

        /// <summary>
        /// Skapar en karaktär och sätter värden för denna karaktär baserat på input(namn) och GiveRandom()-funktionen(egenskaper som heltal).
        /// </summary>
        /// <param name="name"></param>
        public void CreateCharacter(string name)
        {
            Name = name;
            Strength = GiveRandom();
            Damage = GiveRandom();
            Health = GiveRandom();
        
        }

        /// <summary>
        /// Skapar och returnerar ett slumpmässigt tal som man får välja på förhand.
        /// </summary>
        /// <returns></returns>
        public int GiveRandom()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(1, 6);
        }

        /// <summary>
        /// Overloadad funktion av GiveRandom som nu kan ta emot två värden istället för att ha ett fast.
        /// </summary>
        /// <param name="numOne"></param>
        /// <param name="numTwo"></param>
        /// <returns></returns>
        public int GiveRandom(int numOne, int numTwo)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(numOne, numTwo);
        }

        /// <summary>
        /// Visar statistik över vad som har hänt i spelet. Bland annat sparas de fiender man har dödat i en namnlista
        /// och ett siffervärde(score) räknar antal vunna strider.
        /// </summary>
        public void DisplayStatistics(Character player)
        {
            Console.Clear();
            Console.WriteLine("Final Statistics: ");
            Console.WriteLine();
            Console.WriteLine("Name: {0} ", Name);
            Console.WriteLine("Strength: {0} ", Strength);
            Console.WriteLine("Damage: {0}", Damage);
            if (Health < 1)
            {
                Console.WriteLine("Health: Dead");
                Console.WriteLine("Omar was killed by {0}", player.CurrentEnemy);
            }
            else
            {
                Console.WriteLine("Health: {0} ", Health);
            }
            
            for(int i =0; i < defeatedEnemies.Count; i++)
            {
                Console.WriteLine("Omar fought and killed: {0}", defeatedEnemies[i]);
            }
            Console.WriteLine("{0}s total score is {1}", Name, Score);

            Console.ReadKey();
        }

        /// <summary>
        /// En array med ett antal fiendenamn som används för att slumpa ut namn till fienderna.
        /// </summary>
        public string[] enemyNames = new string[10] { "Omar1", "Omar2", "Omar3", "Omar4", "Omar5", "Omar6", "Omar7", "Omar8", "Omar9", "Omar10", };
    }
}
