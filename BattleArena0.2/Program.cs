using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena0._2
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateMenu();
        }

        /// <summary>
        /// Spelloopen som innehåller en switch-statement där användaren ges två val. Skriver ut statistik när loopen avslutas.
        /// </summary>
        public static void CreateMenu()
        {
            //Ändrar textfärgen till vit och skapar sedan en instans av klassen Character.
            //Därefter skapas en karaktär genom metoden "CreatePlayer()" som behöver ett namn
            //som fås genom "GetPlayerName". Till sist så skrivs karaktären ut till konsolen genom 
            //funktionen "DisplayCharacter()".
            Console.ForegroundColor = ConsoleColor.White;
            Character player = new Character();
            player.CreateCharacter(GetPlayerName());

            bool loop = true;
            while (player.Health > 0 && loop)
            {
                player.DisplayCharacter();

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("H - Hunt for an opponent");
                Console.WriteLine("R - Retire from fighting");
                ConsoleKey KeyPressed = Console.ReadKey(true).Key;
                switch (KeyPressed)
                {
                    case ConsoleKey.H:
                        Battle newBattle = new Battle();
                        Character enemy = new Character();
                        newBattle.StartBattle(player, enemy);
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine("You have ended the violence by not fighting");
                        Console.ReadKey();
                        loop = false;
                        break;
                    default:
                        Console.Clear();
                        break;

                }
                Console.Clear();

            }
            player.DisplayStatistics(player);

        }

        /// <summary>
        /// Metod som tar emot en sträng och sedan returnerar denna
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerName()
        {
            Console.WriteLine("Enter the name of your character:");
            string playerName = Console.ReadLine();
            
            return playerName;
        }

    }
}
