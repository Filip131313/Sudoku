﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Board
    {
        int[,] board;
        public int Size { get; set; }
        public Board()
        {
            
        }

        // ----------------------------------------- Method InitializeBoard ----------------------------------------------

        // Ova metoda mi sluzi da mi napravi Array ili Niz koji ima u sebi 9 nizova od 9 polja.
        // This method is used to create an array (or matrix) that contains 9 arrays, each with 9 fields.
        public int[,] InitializeBoard()
        {

            board = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0, cells = 0; j < 9; j++)
                {
                    board[i, j] = cells;
                }
            }
            return board;
        }

        
    }
}
