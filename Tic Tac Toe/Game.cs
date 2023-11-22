namespace Tic_Tac_Toe
{
    internal class Game
    {
        private int[,] board;
        private Player player1;
        private Player player2;

        // Constructor
        public Game()
        {
            // Initialize the board
            board = new int[3, 3];

            // Initialize player symbols and numbers
            this.player1 = new Player().SetSymbol('X').SetNumber(1);
            this.player2 = new Player().SetSymbol('O').SetNumber(-1);
        }

        // Start the game
        public void Start()
        {
            Player curPlayer = player1;
            RenderBoard();

            // Game loop: runs until the game is finished
            while (true)
            {
                // Get the current Player's next move and check if he has won
                if (this.Tick(curPlayer))
                {
                    RenderBoard();
                    Console.WriteLine("\n Player {0} won!", curPlayer.GetSymbol());
                    break;
                }

                // Set the other player for the next move
                if(curPlayer == player1)
                {
                    curPlayer = player2;
                } else
                {
                    curPlayer = player1;
                }

                // If you are cool, you use this instead:
                // curPlayer = curPlayer == player1 ? player2 : player1;

                // End the game if all spots on the board are taken
                if (CheckTie())
                {
                    RenderBoard();
                    Console.WriteLine("\n Tie!");
                    break;
                }
            }
        }

        // Game tick
        // The return value is true if the player has won and false if he hasn't
        private bool Tick(Player player)
        {
            // Get the player's next move until it is a valid one
            int[] move;
            do
            {
                move = player.Move(board);
            } while (!ValidateMove(move));

            // Add the move to the board
            board[move[0], move[1]] = player.GetNumber(); ;
            RenderBoard();

            // Check if the player has won
            if (CheckWin()) return true;
            return false;
        }

        // Check if a move is valid
        private bool ValidateMove(int[] move)
        {
            // A move is valid if the spot on the board is still empty e.g. 0
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

            // Else return false
            return false;
        }

        // Check if there is a tie
        private bool CheckTie()
        {
            // The match is tied if all spots are taken
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
                    // Check, which character to print in the current cell
                    // If the spot is not taken, the cell is left empty
                    char cellContent = ' ';
                    if (board[r, c] == player1.GetNumber()) cellContent = player1.GetSymbol();
                    if (board[r, c] == player2.GetNumber()) cellContent = player2.GetSymbol();

                    Console.Write("{0} | ", cellContent);
                }
                Console.WriteLine("\n" + new string('-', 13));
            }
        }
    }
}
