using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    abstract internal class Entity
    {
        int hp;
        int damage;
        public int HP { get { return hp; } set { hp = value; } }
        public int Damage { get { return damage; } set { damage = value; } }
        public Entity(int hp, int damage)
        {
            HP = hp;
            Damage = damage;
        }
    }
}
