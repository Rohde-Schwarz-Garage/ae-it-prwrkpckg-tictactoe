﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal interface IPlayer
    {
        public IPlayer SetSymbol(char symbol);
        public char GetSymbol();
        public IPlayer SetNumber(int number);
        public int GetNumber();
        public int[] Move(int[,] board);
    }
}