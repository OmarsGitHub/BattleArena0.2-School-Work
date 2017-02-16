﻿using System;
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
            AfterBattle(player);

        }

        public static void AfterBattle(Character player)
        {
            Console.WriteLine("You have {0} Gold and {1} Xp", player.Gold, player.Xp);
            Console.WriteLine("What would you like to spend them on?");
            Console.WriteLine("S - Strength");
            Console.WriteLine("D - Damage");
            Console.WriteLine("H - Health");
            Console.WriteLine("Press any other key to keep your money");

            ConsoleKey keyPressed = Console.ReadKey(true).Key;
            switch (keyPressed)
            {
                case ConsoleKey.A:
                    Console.WriteLine("Du har tryckt på a");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("Du har tryckt på d");
                    break;
                case ConsoleKey.H:
                    Console.WriteLine("Du har tryckt på h");
                    break;
                default:
                    Console.WriteLine("Du har int tryckt på a, d eller h");
                    break;
            }
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
