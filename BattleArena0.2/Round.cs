using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena0._2
{
    class Round


    {
        /// <summary>
        ///Initerar ett antal värden och använder dessa för att utföra själva rundan. Beroende på hur värdena ser ut blir scenariot olika för varje omgång rundan körs.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public void newRound(Character player, Character enemy)
        {

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("-------------------");

                int rollPlayer = Roll(player);
                int rollEnemy = Roll(enemy);
                int fightingValuePlayer = rollPlayer + player.Strength;
                int fightingValueEnemy = rollEnemy + enemy.Strength;
                 
                Console.WriteLine("Rolls: {0} {1} ({2}+{3}) vs {4} {5} ({6}+{7})", player.Name, fightingValuePlayer, player.Strength, rollPlayer, enemy.Name, fightingValueEnemy, enemy.Strength, rollEnemy);

                if (fightingValuePlayer > fightingValueEnemy)
                {
                    DisplayRoundWin(player, enemy);

                }

                else if (fightingValuePlayer == fightingValueEnemy)
                {
                    DisplayRoundDraw(player, enemy);
                }

                else if (fightingValuePlayer < fightingValueEnemy)
                {
                    DisplayRoundDefeat(player, enemy);
                }

                if (player.Health < 1 || enemy.Health < 1)
                {
                    DisplayEndBattle(player, enemy);
                }

                else
                {
                    Console.WriteLine("Remaining Health: {0} ({1}), {2} ({3})", player.Name, player.Health, enemy.Name, enemy.Health);
                }

                Console.ReadKey();

            }
        }

        /// <summary>
        /// Skriver ut till konsolen om spelaren vinner ronden i grönt och minskar fiendes HP.
        /// Ställer därefter tillbaka färgen till vit.
        /// </summary>
        public void DisplayRoundWin(Character player, Character enemy)
        {
            int damage = Damage(player);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} attacks {1}! {2} takes {3} damage", player.Name, enemy.Name, enemy.Name, damage);
            enemy.Health -= damage;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Skriver ut till konsolen om ronden blir lika
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public void DisplayRoundDraw(Character player, Character enemy)
        {
            Console.WriteLine("Evenly matched, the combatant circle each other, looking for a better opportunity.");
        }

        /// <summary>
        /// Skriver ut till konsolen om fienden vinner ronden i rött och minskar spelarens HP.
        /// Ställer därefter tillbaka färgen till vit.
        /// </summary>
        public void DisplayRoundDefeat(Character player, Character enemy)
        {
            int damage = Damage(enemy);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} attacks {1}! {2} takes {3} damage", enemy.Name, player.Name, player.Name, damage);
            player.Health -= damage;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        ///Kollar vem det är som har dött(mindre liv än 1) och skriver därefter ut vem som har dött och vem som har vunnit
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public void DisplayEndBattle(Character player, Character enemy)
        {
            if (player.Health < 1)
            {
                Console.WriteLine("Remaining Health: {0} ({1}), {2} ({3})", player.Name, "Dead", enemy.Name, enemy.Health);
                Console.ReadKey();
                Console.WriteLine("--------------");
                Console.WriteLine("{0} is victorious!", enemy.Name);
            }

            else
            {
                Console.WriteLine("Remaning Health: {0} ({1}), {2} ({3})", player.Name, player.Health, enemy.Name, "Dead");
                Console.ReadKey();
                Console.WriteLine("--------------");
                Console.WriteLine("{0} is victorious!", player.Name);
                player.Score++;
                player.defeatedEnemies.Add(enemy.Name);

            }

        }

        /// <summary>
        /// Rullar ett random nummer genom att använda randomfunktionen i klassen Character
        /// </summary>
        /// <param name="randomNumber"></param>
        /// <returns></returns>
        public int Roll(Character randomNumber)
        {
            int roll = randomNumber.GiveRandom();
            return roll;
        }

        /// <summary>
        /// Skapar ett "damagevärde" som returneras. Detta värde kan justeras i metoden
        /// </summary>
        /// <param name="randomDamage"></param>
        /// <returns></returns>
        public int Damage(Character randomDamage)
        {
            int damage = randomDamage.GiveRandom(1, 3);
            return damage;
        }

        //Test
        
    }
}
