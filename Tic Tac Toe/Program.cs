namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start a new game
            Game game = Game.CreateSingleplayer();
            game.Start();
        }
    }
}
