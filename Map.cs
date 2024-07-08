using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    internal class Map
    {
        char[][] map;

        public Map(int level)
        {
            Map_Loader(level);
        }

        public char[][] Map_Loader(int level_Num)
        {
            string[] level_Lines;
            level_Lines = File.ReadAllLines(@"C:\Git\Dungeon_Master\level" + $"{level_Num}.txt");
            map = new char[level_Lines.Length][];
            for (int i = 0; i < level_Lines.Length; i++)
            {
                map[i] = level_Lines[i].ToCharArray();
            }
            return map; 
        }

        public void Draw(char[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'X')
                    {
                        //actual_Level[i][j] = ' ';
                        Console.Write(' ');
                    }
                    else if (map[i][j] == 'F')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        //actual_Level[i][j] = ' ';
                        Console.Write(' ');
                        Console.ResetColor();
                    }
                    else if (map[i][j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.BackgroundColor = ConsoleColor.Green;
                        map[i][j] = 'P';
                        Console.Write(map[i][j]);
                        Console.ResetColor();

                    }
                    else if (map[i][j] == '~')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        //actual_Level[i][j] = ' ';
                        Console.Write(map[i][j]);
                        Console.ResetColor();
                    }
                    else if (map[i][j] == 'I')
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        //actual_Level[i][j] = ' ';
                        Console.Write(map[i][j]);
                        Console.ResetColor();
                    }
                    else if (map[i][j] == 'H')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        //actual_Level[i][j] = ' ';
                        Console.Write(map[i][j]);
                        Console.ResetColor();
                    }
                    else if (map[i][j] == 'E')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        //actual_Level[i][j] = ' ';
                        map[i][j] = 'E';
                        Console.Write(map[i][j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map[i][j]);
                        Console.ResetColor();
                    }


                }
                    Console.WriteLine();
                }
        }
    }
}
