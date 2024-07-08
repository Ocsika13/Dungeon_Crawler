using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    internal class Enemy : Entity, IMovable
    {
        string suit;
        string weapon;
        string type;

        public string Suit { get; set; }
        public string Weapon { get; set; }

        public string Type { get; set; }
        public Enemy(int hp, int damage, string suit, string weapon, string type) : base(hp, damage)
        {
            this.Suit = suit;
            this.Weapon = weapon;
            this.Type = type;
        }
    }
}
