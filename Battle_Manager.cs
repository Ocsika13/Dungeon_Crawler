using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    internal class Battle_Manager
    {
        public void Battle_Operator(Player player, Enemy enemy)
        {
            bool battle_End = true;
            do
            {
                
                Console.WriteLine($"Player HP: {player.HP}              Enemy HP: {enemy.HP}");
                Console.WriteLine($"Player Damage: {player.Damage}      Enemy Damage: {enemy.Damage}");
                Console.WriteLine("Press (A)ttack (D)efense");
                string choosed = Console.ReadLine().ToUpper();
                if( choosed == "A")
                {
                    enemy.HP -= player.Damage;
                }
                if(player.HP <= 0 || enemy.HP <= 0)
                {
                    battle_End= false;
                }
            }
            while(battle_End);
        }
    }
}
