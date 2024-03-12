using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tic_Tac_Toe
{
    internal class Game
    {
        private int[,] board;
        private Player player1;
        private Player player2;

        // Base constructor
        public Game(Player player1, Player player2)
        {
            // Initialize the board
            board = new int[3, 3];

            // Initialize player symbols and numbers
            this.player1 = player1;
            this.player1.SetSymbol('X');
            this.player1.SetNumber(1);

            this.player2 = player2;
            this.player2.SetSymbol('O');
            this.player2.SetNumber(-1);
        }

        // Constructor for singleplayer
        public static Game CreateSingleplayer()
        {
            return new Game(new PhysPlayer(), new Computer());
        }

        // Constructor for multiplayer
        public static Game CreateMultiplayer()
        {
            return new Game(new PhysPlayer(), new PhysPlayer());
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
                if (this.PerformTurn(curPlayer))
                {
                    RenderBoard();
                    Console.WriteLine("\n Player {0} won!", curPlayer.GetSymbol());
                    break;
                }

                // Set the other player for the next move
                if (curPlayer == player1)
                {
                    curPlayer = player2;
                } else
                {
                    curPlayer = player1;
                }

                // End the game if all spots on the board are taken
                if (IsBoardFull())
                {
                    RenderBoard();
                    Console.WriteLine("\n Tie!");
                    break;
                }
            }
        }

        // Allows a player to perform his turn
        // The return value is true if the player has won and false if he hasn't
        private bool PerformTurn(Player player)
        {
            // Get the player's next move until it is a valid one
            int[] move;
            do
            {
                move = player.Move(board);
            }
            while (!ValidateMove(move));

            // Add the move to the board
            board[move[0], move[1]] = player.GetNumber(); ;
            RenderBoard();

            // Check if the player has won
            if (CheckWinner(board, player.GetNumber()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check if a move is valid
        private bool ValidateMove(int[] move)
        {
            // A move is valid if the spot on the board is still empty e.g. 0
            return board[move[0], move[1]] == 0;
        }

        // Determines if the game is over and the winner
        // 1: The player with playerNumber wins
        // -1: The opponent wins
        // null: game is not over
        // 0: tie
        public static int? CheckWinner(int[,] board, int playerNumber)
        {
            int[] lines = new int[]
            {
                board[0, 0] + board[0, 1] + board[0, 2],
                board[1, 0] + board[1, 1] + board[1, 2],
                board[2, 0] + board[2, 1] + board[2, 2],
                board[0, 0] + board[1, 0] + board[2, 0],
                board[0, 1] + board[1, 1] + board[2, 1],
                board[0, 2] + board[1, 2] + board[2, 2],
                board[0, 0] + board[1, 1] + board[2, 2],
                board[2, 0] + board[1, 1] + board[0, 2]
            };

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == 3 * playerNumber)
                {
                    return 1; // Player wins
                }
                else if (lines[i] == 3 * -playerNumber)
                {
                    return -1; // Opponent wins
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        return null; // Game is not over
                    }
                }
            }

            return 0; // Game is a tie
        }

        // Check if the board is full
        private bool IsBoardFull()
        {
            // The match is tied if all spots are taken
            foreach(int e in board)
            {
                if (e == 0)
                {
                    return false;
                }
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
                    if (board[r, c] == player1.GetNumber())
                    {
                        cellContent = player1.GetSymbol();
                    }
                    if (board[r, c] == player2.GetNumber())
                    {
                        cellContent = player2.GetSymbol();
                    }

                    Console.Write("{0} | ", cellContent);
                }
                Console.WriteLine("\n" + new string('-', 13));
            }
        }
    }
}
