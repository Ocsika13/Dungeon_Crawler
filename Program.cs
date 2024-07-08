namespace Dungeon_Crawler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Game_Manager game_Starter = new Game_Manager();
            game_Starter.StartGame();
            game_Starter.Run_Game();
            Console.ReadLine();
        }
    }
}
