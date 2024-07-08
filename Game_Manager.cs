using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    internal class Game_Manager
    {
        Player player = new Player(100, 0, "Leather", "None",0);
        Enemy skeleton = new Enemy(50, 15, "Bone", "Sword", "Skeleton");
        Enemy cyclops = new Enemy(70, 25, "Leather", "Axe", "Cyclops");
        Map current_Map = new Map(1);
        char[][] maps;
        string button = "3";
        int X = 0;
        int Y = 0;


        public void StartGame()
        {
            
            maps = current_Map.Map_Loader(1);
            current_Map.Draw(maps);
            Console.WriteLine("Game Started");
            for (int i = 0; i < maps.Length; i++)
            {
                for (int j = 0; j < maps[i].Length; j++)
                {
                    if (maps[i][j] == 'P')
                    {
                        X = i;
                        Y = j;
                    }
                }
            }
            Thread.Sleep(1000);
        }

        public void Run_Game()
        {
            bool gameover = false;
            while(!gameover)
            {
                for (int i = 0; i < maps.Length; i++)
                {
                    for (int j = 0; j < maps[i].Length; j++)
                    {
                        if (maps[i][j] == 'P')
                        {
                            X = i;
                            Y = j;
                        }
                    }
                }
                player.Controll_Settings(maps, X, Y, 1);
                if(button == "2")
                {
                    if (File.Exists(@"C:\Git\Dungeon_Master\level2.txt"))
                    {
                        current_Map = new Map(2);
                        maps = current_Map.Map_Loader(2);
                        gameover = true;
                        Thread.Sleep(1000);
                    }
                    
                }
                Console.Clear();
                current_Map.Draw(maps);
                player.Player_Stats();
            }
        }
    }
}
