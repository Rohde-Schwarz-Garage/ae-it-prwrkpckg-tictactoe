using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    // Class which represents a computer-player
    internal class Computer : IPlayer
    {
        private char symbol;
        private int number;

        // Set the player's symbol
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }

        // Get the player's symbol
        public char GetSymbol() { return symbol; }

        // Set the player's number
        public void SetNumber(int number)
        {
            this.number = number;
        }

        // Get the player's number
        public int GetNumber() { return number; }

        // Get the computer's next move
        public int[] Move(int[,] board)
        {
            int bestScore = -Int32.MaxValue;
            int[] move = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Is the spot available?
                    // If yes, simulate taking the spot and check which score could be achieved
                    if (board[i, j] == 0)
                    {
                        board[i, j] = this.number;
                        int? score = minimax(board, 0, false);
                        board[i, j] = 0;

                        // Save the achieved score to bestScore if it was better than the previous one
                        // Save the move
                        if (score > bestScore)
                        {
                            bestScore = (int) score;
                            move = [ i, j ];
                        }
                    }
                }
            }
            return move;
        }

        // Implementation of the minimax algorithm
        public int? minimax(int[,] board, int depth, bool isMaximizing)
        {
            // Returns 0 for a tie, 1 for a win and -1 if the enemy won
            int? result = CheckWinner(board);
            if (result != null)
            {
                return result;
            }

            // Simulate the computer's turn
            if (isMaximizing)
            {
                int bestScore = -Int32.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = this.number;
                            int? score = minimax(board, depth + 1, false);
                            board[i, j] = 0;
                            bestScore = Math.Max((int) score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            // Simulate the other player's turn
            else
            {
                int bestScore = Int32.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = -number;
                            int? score = minimax(board, depth + 1, true);
                            board[i, j] = 0;
                            bestScore = Math.Min((int) score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }

        // Determines if the game is over and the winner
        // 1: AI won the game
        // -1: Opponent won the game
        // null: game is not over
        // 0: tie
        public int? CheckWinner(int[,] board)
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
                if (lines[i] == 3 * this.number)
                {
                    return 1; // AI wins
                }
                else if (lines[i] == 3 * -number)
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
    }
}
