using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    internal class Weapon : Item
    {
        int damage;

        public int Damage {  get; set; }

        public Weapon(int damage)
        {
            Damage = damage;
        }
    }
}
