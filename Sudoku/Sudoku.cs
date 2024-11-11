using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Sudoku
    {
        private Board board;
        private int[,] table;
        private int[,] newTable;
        // ------------------ Constructor ---------------------
        public Sudoku()
        {
            board = new Board();
            table = NewBoard(board);
            PutNewValueInBoard(table);
        }
        // ------------ End of Constructor ---------------------


        // ------------------------------------------------ Method PutNewValueInBoard -----------------------------------------------------
        private void PutNewValueInBoard(int[,] tableParam)
        {
            DisplayTable(tableParam);

            bool flag = true;
            
            while(flag)
            {
                try
                {
                    Console.WriteLine("What number do you want to put: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("In what array : ");
                    int arr = int.Parse(Console.ReadLine());
                    Console.WriteLine("What Field: ");
                    int field = int.Parse(Console.ReadLine());

                    newTable = NewValuesInTable(number, arr, field, tableParam);
                    DisplayTable(newTable);
                }catch(Exception e)
                {
                    Console.WriteLine("You type something wrong, Try just with numbers between 1 and 9 :D");
                    Console.WriteLine("And read inputs :)");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.InnerException);
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine("Just keep going, you are doing well :) :D");
                }
                

            }
            
        }

        // ------------------------------------------------ End Method PutNewValueInBoard -----------------------------------------------------


        // ------------------------------------------------ Method NewValuesInTable -----------------------------------------------------
        private int[,] NewValuesInTable(int number, int arr, int field, int[,] tableParam)
        {
            table = tableParam;

            // Proveravam jel broj veci od 9 ili manji od 0 ako jeste pojavljuje se poruka da takav broj nije dozvoljen.

            // Checking if the number is greater than 9 or less than 0. If it is, 
            // a message is displayed saying that such a number is not allowed.


            if ((field < 1 || field > 9) || (number < 1 || number > 9) || (arr < 1 || arr > 9))
            {
                Console.WriteLine("Arrays, Field and Numbers must be between 1 and 9 !!");
                return table;
            }

            // Ova petlja mi sluza da proverim da li ima istog broja u koloni, ako ima prikazuje se poruka da nije dozvoljeno staviti isti broj u istoj koloni.

            // This loop is used to check if the same number exists in the column. If it does, 
            // a message is displayed saying that placing the same number in the same column is not allowed.


            for (int i = 0; i < 9; i++)
            {
                if (table[i, field - 1] == number && i != arr - 1)
                {
                    Console.WriteLine("You cannot place the same number in the same column on a different field!");
                    return table;
                }
            }

            // Ova petlja mi sluza da proverim da li ima istog broja u redu, ako ima prikazuje se poruka da nije dozvoljeno staviti isti broj u istom redu.

            // This loop is used to check if the same number exists in the row. If it does, 
            // a message is displayed saying that placing the same number in the same row is not allowed.


            for (int j = 0; j < 9; j++)
            {
                if (table[arr - 1, j] == number && j != field - 1)
                {
                    Console.WriteLine("You cannot place the same number in the same row on a different field!");
                    return table;
                }
            }

            // Ovaj kod mi sluzi da proveri jel stavljen isti broj u istom kvadratu, ako jeste,
            // prikazuje se poruka da to nije dozvoljeno.

            // This code is used to check if the same number is placed in the same square. If it is, 
            // a message is displayed saying that this is not allowed.

            int startRow = (arr - 1) / 3 * 3; 
            int startCol = (field - 1) / 3 * 3; 

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (table[i, j] == number && !(i == arr - 1 && j == field - 1))
                    {
                        Console.WriteLine("You cannot place the same number in the same 3x3 box on a different field!");
                        return table;
                    }
                }
            }

            table[arr - 1, field - 1] = number;
            return table;
        }

        // ------------------------------------------------ END Method NewValuesInTable -----------------------------------------------------

        // --------------------------------------------- Method NewBoard --------------------------------------------------------

        // Ova metoda mi sluzi da implementira random brojeve u razlicitim kvadratima u ovom Array-u ili ti Nizu 
        // This method is used to implement random numbers in different squares in this array.
        private int[,] NewBoard(Board board)
        {
            board = new Board();
            
            table = board.InitializeBoard();
            
            Random randomJ = new Random();

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    int randomNumber = randomJ.Next(1, 10);
                    if (i == 0 && j == 1)
                    {
                        table[i, j] = randomNumber;

                    }else if(i == 1 && j == 5)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 2 && j == 7)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 3 && j == 0)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 4 && j == 4)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 5 && j == 6)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 6 && j == 2)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 7 && j == 3)
                    {
                        table[i, j] = randomNumber;
                    }
                    else if (i == 8 && j == 8)
                    {
                        table[i, j] = randomNumber;
                    }
                }
            }
            return table;
        }

        // -------------------- End Method NewBoard -------------------

        // --------------------Method DisplayTable --------------------


        public void DisplayTable(int[,] tableParam)
        {
            tableParam = table;
            if (tableParam == null)
            {
                Console.WriteLine("Board nije inicijalizovan.");
                return;
            }

            Console.WriteLine("-------Sudoku--------");

            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    Console.WriteLine("------+-------+------");
                }
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(tableParam[i, j] == 0 ? 0 : tableParam[i, j]);
                    if (j < 8) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        // -------------------- End Method DisplayTable -------------------

    }
}
