using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    // Interface for Players and Computers that forces certain methods to be implemented
    internal interface IPlayer
    {
        public void SetSymbol(char symbol);
        public char GetSymbol();
        public void SetNumber(int number);
        public int GetNumber();
        public int[] Move(int[,] board);
    }
}
