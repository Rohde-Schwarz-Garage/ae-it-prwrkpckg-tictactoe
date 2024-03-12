using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    // Class which represents a computer-player
    internal class Computer : Player
    {
        public Computer(char symbol, FieldState number) : base(symbol, number) { }

        // Get the computer's next move
        public override int[] Move(FieldState[,] board)
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
                        board[i, j] = Number;
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
        public int? minimax(FieldState[,] board, int depth, bool isMaximizing)
        {
            // Returns 0 for a tie, 1 for a win and -1 if the enemy won
            int? result = Game.CheckWinner(board, Number);
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
                            board[i, j] = Number;
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
                            board[i, j] = (FieldState) (- (int) Number);
                            int? score = minimax(board, depth + 1, true);
                            board[i, j] = 0;
                            bestScore = Math.Min((int) score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }
    }
}
