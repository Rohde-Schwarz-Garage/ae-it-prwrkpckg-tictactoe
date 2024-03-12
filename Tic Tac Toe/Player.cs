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

        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }
        public char GetSymbol()
        {
            return symbol;
        }
        public void SetNumber(int number)
        {
            this.number = number;
        }
        public int GetNumber()
        {
            return number;
        }
        public abstract int[] Move(int[,] board);
    }
}
