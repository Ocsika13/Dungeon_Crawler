using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    internal class Player : Entity, IMovable
    {
        string suit;
        string weapon;
        bool battle = false;
        int key_Count = 0;

        public string Suit { get; set; }
        public string Weapon { get; set; }
        public int Key_Count { get; set; }

        public bool isDoor = false;
        public bool isEnemy = false;

        public Player(int hp, int damage, string suit, string weapon, int key_Count) :base (hp, damage)
        {
            this.Suit = suit;
            this.Weapon = weapon;
            this.Key_Count = key_Count;
        }

        public void Controll_Settings(char[][] actual_Level, int coordinate_X, int coordinate_Y,ref int level)
        {
            ConsoleKey ck = Console.ReadKey(true).Key;

            // Eredeti pozíció mentése
            int old_X = coordinate_X;
            int old_Y = coordinate_Y;

            switch (ck)
            {
                case ConsoleKey.UpArrow:
                    if (coordinate_X > 0)
                    {
                        coordinate_X--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (coordinate_X < actual_Level.Length - 1)
                    {
                        coordinate_X++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (coordinate_Y > 0)
                    {
                        coordinate_Y--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (coordinate_Y < actual_Level[coordinate_X].Length - 1)
                    {
                        coordinate_Y++;
                    }
                    break;
            }

            // Új pozíció frissítése
            if (actual_Level[coordinate_X][coordinate_Y] == 'X')
            {
                // Mozgatás végrehajtása
                actual_Level[old_X][old_Y] = 'X';
                actual_Level[coordinate_X][coordinate_Y] = 'P';
            }
            else if (actual_Level[coordinate_X][coordinate_Y] == 'I')
            {
                actual_Level[old_X][old_Y] = 'X';
                actual_Level[coordinate_X][coordinate_Y] = 'P';
                Damage += 25;
            }
            else if (actual_Level[coordinate_X][coordinate_Y] == 'K')
            {
                actual_Level[old_X][old_Y] = 'X';
                actual_Level[coordinate_X][coordinate_Y] = 'P';
                Key_Count++;
            }
            else if (actual_Level[coordinate_X][coordinate_Y] == 'H')
            {
                actual_Level[old_X][old_Y] = 'X';
                actual_Level[coordinate_X][coordinate_Y] = 'P';
                HP += 25;
                if (HP > 100)
                {
                    HP = 100;
                }
            }
            else if (actual_Level[coordinate_X][coordinate_Y] == 'E')
            {
                isEnemy = true;
                actual_Level[old_X][old_Y] = 'X';
                actual_Level[coordinate_X][coordinate_Y] = 'P';
            }
            else if (Key_Count > 0 && actual_Level[coordinate_X][coordinate_Y] == 'D')
            {
                isDoor = true;
                actual_Level[old_X][old_Y] = 'X';
                actual_Level[coordinate_X][coordinate_Y] = 'P';
                Key_Count--;
                level++;
            }
            else
            {
                // Ha az új pozíció nem üres (pl. fal), visszaállítjuk az eredeti pozíciót
                coordinate_X = old_X;
                coordinate_Y = old_Y;
            }
            Console.Clear();

        }
        public void Player_Stats()
        {
            Console.WriteLine($"Player HP: {HP}");
            Console.WriteLine($"Player Attack: {Damage}");
            Console.WriteLine($"Key: {Key_Count}");
        }
    }
}
