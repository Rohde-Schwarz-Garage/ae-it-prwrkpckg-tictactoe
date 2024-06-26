﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    // Class which represents a player
    internal class Player
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
        public int[] Move()
        {
            Console.WriteLine("Player {0}'s turn: Choose wisely!", this.symbol);

            // Ask the player for a column until he enters a valid one
            int column;
            do
            {
                Console.Write("In which column do you want to place your mark? [1-3] ");
                try
                {
                    column = Convert.ToInt32(Console.ReadLine());
                } catch
                {
                    column = 0;
                }
            }
            while (column <= 0 || column > 3);

            // Ask the player for a row until he enters a valid one
            int row;
            do
            {
                Console.Write("In which row do you want to place your mark? [1-3] ");
                try
                {
                    row = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    row = 0;
                }
            }
            while (row <= 0 || row > 3);

            // Substract one, because array indices start at 0
            return [row - 1, column - 1];
        }
    }
}
