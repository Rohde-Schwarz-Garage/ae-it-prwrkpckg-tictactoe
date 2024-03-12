using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    // Interface for Players and Computers that forces certain methods to be implemented
    internal abstract class Player
    {
        private char symbol;
        private int number;
        public Player(char symbol, int number)
        {
            this.symbol = symbol;
            this.number = number;
        }

        // Get the player's symbol
        public char GetSymbol() { return symbol; }

        // Get the player's number
        public int GetNumber() { return number; }

        // Get the next move from the player
        public abstract int[] Move(int[,] board);
    }
}
