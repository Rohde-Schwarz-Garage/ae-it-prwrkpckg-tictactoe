using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tic_Tac_Toe
{
    internal class Game
    {
        private FieldState[,] board;
        private Player player1;
        private Player player2;

        // Base constructor
        public Game(Player player1, Player player2)
        {
            // Initialize the board
            board = new FieldState[3, 3];

            this.player1 = player1;
            this.player2 = player2;
        }

        // Constructor for singleplayer
        public static Game CreateSingleplayer()
        {
            return new Game(new PhysPlayer('X', FieldState.Player1), new Computer('O', FieldState.Player2));
        }

        // Constructor for multiplayer
        public static Game CreateMultiplayer()
        {
            return new Game(new PhysPlayer('X', FieldState.Player1), new PhysPlayer('O', FieldState.Player2));
        }

        // Start the game
        public void Start()
        {
            Player curPlayer = player1;
            PrintBoard();

            // Game loop: runs until the game is finished
            while (true)
            {
                // Get the current Player's next move and check if he has won
                if (this.PerformTurn(curPlayer))
                {
                    PrintBoard();
                    Console.WriteLine("\n Player {0} won!", curPlayer.Symbol);
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
                if (IsBoardFull(board))
                {
                    PrintBoard();
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
            board[move[0], move[1]] = player.Number;
            PrintBoard();

            // Check if the player has won
            if (CheckWinner(board, player.Number) == 1)
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
            return board[move[0], move[1]] == FieldState.Empty;
        }

        // Determines if the game is over and the winner
        // 1: The player with playerNumber wins
        // -1: The opponent wins
        // null: game is not over
        // 0: tie
        public static int? CheckWinner(FieldState[,] board, FieldState playerNumber)
        {
            int[] lines = new int[]
            {
                (int) board[0, 0] + (int) board[0, 1] + (int) board[0, 2],
                (int) board[1, 0] + (int) board[1, 1] + (int) board[1, 2],
                (int) board[2, 0] + (int) board[2, 1] + (int) board[2, 2],
                (int) board[0, 0] + (int) board[1, 0] + (int) board[2, 0],
                (int) board[0, 1] + (int) board[1, 1] + (int) board[2, 1],
                (int) board[0, 2] + (int) board[1, 2] + (int) board[2, 2],
                (int) board[0, 0] + (int) board[1, 1] + (int) board[2, 2],
                (int) board[2, 0] + (int) board[1, 1] + (int) board[0, 2]
            };

            // Check if a player has filled a line and therefore won the game
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == 3 * (int) playerNumber)
                {
                    return 1; // Player wins
                }
                else if (lines[i] == 3 * - (int) playerNumber)
                {
                    return -1; // Opponent wins
                }
            }

            // Return null if the game is not over yet
            if (!IsBoardFull(board))
            {
                return null;
            }

            return 0; // Game is a tie
        }

        // Check if the board is full
        public static bool IsBoardFull(FieldState[,] board)
        {
            // The match is tied if all spots are taken
            foreach(FieldState e in board)
            {
                if (e == FieldState.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Print the board to the console
        private void PrintBoard()
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
                    if (board[r, c] == player1.Number)
                    {
                        cellContent = player1.Symbol;
                    }
                    if (board[r, c] == player2.Number)
                    {
                        cellContent = player2.Symbol;
                    }

                    Console.Write("{0} | ", cellContent);
                }
                Console.WriteLine("\n" + new string('-', 13));
            }
        }
    }
}
