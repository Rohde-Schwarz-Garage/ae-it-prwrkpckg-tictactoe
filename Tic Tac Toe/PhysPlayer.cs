using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class PhysPlayer : IPlayer
    {
        private char symbol;
        private int number;

        // Set the player's symbol
        public IPlayer SetSymbol(char symbol)
        {
            this.symbol = symbol;
            return this;
        }

        public char GetSymbol() { return symbol; }

        // Set the player's number
        public IPlayer SetNumber(int number)
        {
            this.number = number;
            return this;
        }

        // Get the player's number
        public int GetNumber() { return number; }

        // Get the next move from the player
        public int[] Move(int[,] board)
        {
            int column;
            do
            {
                Console.Write("In welcher Spalte soll der nächste Zug stattfinden? [1-3] ");
                try
                {
                    column = Convert.ToInt32(Console.ReadLine());
                } catch
                {
                    column = 0;
                }
            } while (column <= 0 || column > 3);

            int row;
            do
            {
                Console.Write("In welcher Reihe soll der nächste Zug stattfinden? [1-3] ");
                try
                {
                    row = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    row = 0;
                }
            } while (row <= 0 || row > 3);

            return [row - 1, column - 1];
        }
    }
}
