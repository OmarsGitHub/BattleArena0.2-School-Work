using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena0._2
{
    class Battle
    {
        /// <summary>
        /// Skapar en instans av "Round" och kör sedan denna.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public void StartBattle(Character player, Character enemy)
        {
            //Skapar en fiende, enemy, med hjälp av "CreateCharacter". Namnet slumpgenereras
            //med hjälp av "GiveRandom" som stoppas in en en array av namn, enemyNames[]
            //Sätter också ett värde till CurrentEnemy för att hålla reda på vem man slåss mot
            enemy.CreateCharacter(enemy.enemyNames[enemy.GiveRandom()]);
            player.CurrentEnemy = enemy.Name;
            Console.Clear();

            // Metod som skriver ut båda Karaktärerna till konsolen
            DisplayCharacters(player, enemy);


            Round newRound = new Round();
            newRound.newRound(player, enemy);

        }

        /// <summary>
        /// Metod som visar både fiende och player-karaktärerna genom att använda funktionen "DisplayCharacter".
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void DisplayCharacters(Character player, Character enemy)
        {
            
            player.DisplayCharacter();
            Console.WriteLine();
            enemy.DisplayCharacter();
        }

    }
    
}
