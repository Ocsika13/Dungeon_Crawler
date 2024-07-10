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
        Random random = new Random();
        int level_Num = 1;
        

        public void StartGame()
        {
            maps = current_Map.Map_Loader(level_Num); 
            Console.WriteLine($"Level: {level_Num}");
            current_Map.Draw(maps);
            player.Player_Stats();
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
        }

        public void Run_Game()
        {
            start:
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
                player.Controll_Settings(maps, X, Y,ref level_Num);
                if(player.isDoor == true)
                {
                    if (File.Exists($@"C:\Git\Dungeon_Master\level{level_Num}.txt"))
                    {
                        current_Map = new Map(level_Num);
                        maps = current_Map.Map_Loader(level_Num);
                        gameover = true;
                        Thread.Sleep(1000);
                        player.isDoor = false;
                        goto start;
                    }
                    
                }
                if(player.isEnemy == true)
                {
                    List<Enemy> enemies = new List<Enemy>();
                    enemies.Add(new Enemy(50, 15, "Bone", "Sword", "Skeleton"));
                    enemies.Add(new Enemy(70, 25, "Leather", "Axe", "Cyclops"));
                    Battle_Manager battle = new Battle_Manager();
                    battle.Battle_Operator(player, enemies[random.Next(0,enemies.Count)]);
                    player.isEnemy = false;
                }
                Console.Clear();
                Console.WriteLine($"Level: {level_Num}");
                current_Map.Draw(maps);
                player.Player_Stats();
            }
        }
    }
}
