namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start a new singleplayer game
            Game game = new Game(new Computer());
            game.Start();
        }
    }
}
