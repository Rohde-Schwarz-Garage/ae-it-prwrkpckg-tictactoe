namespace Tic_Tac_Toe
{
    internal class Game
    {
        private int[,] board;
        private IPlayer player1;
        private IPlayer player2;

        // Base constructor
        public Game(IPlayer player1, IPlayer player2)
        {
            board = new int[3, 3];

            this.player1 = player1.SetSymbol('X').SetNumber(1);
            this.player2 = player2.SetSymbol('O').SetNumber(2);
        }

        // Constructor for singleplayer
        public Game(IPlayer computer) : this(new PhysPlayer(), computer) { }

        // Constructor for multiplayer
        public Game() : this(new PhysPlayer(), new PhysPlayer()) { }

        // Start the game
        public void Start()
        {
            IPlayer curPlayer = player1;
            while (true)
            {
                if (this.Tick(curPlayer))
                {
                    RenderBoard();
                    Console.WriteLine("\n Player {0} won!", curPlayer.GetSymbol());
                    break;
                }
                curPlayer = curPlayer == player1 ? player2 : player1;
                if (CheckDraw())
                {
                    RenderBoard();
                    Console.WriteLine("\n Draw!");
                    break;
                }
            }
        }

        // Game tick
        private bool Tick(IPlayer player)
        {
            int[] move;
            do
            {
                move = player.Move(board);
            } while (!ValidateMove(move));

            board[move[0], move[1]] = player.GetNumber(); ;
            RenderBoard();

            if (CheckWin()) return true;
            return false;
        }

        // Check if a move is valid
        private bool ValidateMove(int[] move)
        {
            return board[move[0], move[1]] == 0;
        }

        // Check if a player has won
        private bool CheckWin()
        {
            // Check for completed rows
            if (board[0, 0] != 0 && board[0, 1] == board[0, 0] && board[0, 2] == board[0, 0]) return true;
            if (board[1, 0] != 0 && board[1, 1] == board[1, 0] && board[1, 2] == board[1, 0]) return true;
            if (board[2, 0] != 0 && board[2, 1] == board[2, 0] && board[2, 2] == board[2, 0]) return true;

            // Check for completed columns
            if (board[0, 0] != 0 && board[1, 0] == board[0, 0] && board[2, 0] == board[0, 0]) return true;
            if (board[0, 1] != 0 && board[1, 1] == board[0, 1] && board[2, 1] == board[0, 1]) return true;
            if (board[0, 2] != 0 && board[1, 2] == board[0, 2] && board[2, 2] == board[0, 2]) return true;

            // Check for completed diagonals
            if (board[0, 0] != 0 && board[1, 1] == board[0, 0] && board[2, 2] == board[0, 0]) return true;
            if (board[0, 2] != 0 && board[1, 1] == board[0, 2] && board[2, 0] == board[0, 2]) return true;

            return false;
        }

        // Check if there is a draw
        private bool CheckDraw()
        {
            foreach(int e in board)
            {
                if (e == 0) return false;
            }
            return true;
        }

        // Print the board to the console
        private void RenderBoard()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 13));
            for(int r = 0; r < board.GetLength(0); r++)
            {
                Console.Write("| ");
                for(int c = 0; c < board.GetLength(1); c++)
                {
                    Console.Write("{0} | ", board[r, c]);
                }
                Console.WriteLine("\n" + new string('-', 13));
            }
        }
    }
}
