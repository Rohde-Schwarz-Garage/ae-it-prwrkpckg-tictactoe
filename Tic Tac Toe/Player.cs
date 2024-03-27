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
        private FieldState number;

        // Define getters for the variables so they can be accessed
        public char Symbol { get => symbol; }
        public FieldState Number { get => number; }

        public Player(char symbol, FieldState number)
        {
            this.symbol = symbol;
            this.number = number;
        }

        // Get the next move from the player
        public abstract int[] Move(FieldState[,] board);
    }
}
