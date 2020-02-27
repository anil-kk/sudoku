using System;
using System.Collections.Generic;
using System.IO;

namespace Sudoku
{
    class Game
    {

        static HashSet<string> lookup = new HashSet<string>();
        public static void puzzleSolver(char[,] mainGrid)
        {
            var isGridValid = checkGridValidity(mainGrid);

            if (!isGridValid)
            {
                Console.WriteLine($"");
                Console.WriteLine("Given SUDOKU grid is not valid!");
                Console.WriteLine($"");
                return;
            }
            Console.WriteLine($"");
            Console.WriteLine("Given SUDOKU grid seems to be a valid one, solving...");
            Console.WriteLine($"");

            solve(mainGrid);
        }

        public static bool solve(char[,] mainGrid, int row = 0, int col = 0)
        {
            var mainGridSize = mainGrid.GetLength(0);

            //if(mainGrid[row, col] == '.')
            //{

            //}

            Console.Write($"{mainGrid[row, col]} \t");

            col += 1;  
            var isColumnEnd = col > mainGridSize - 1;
            if (isColumnEnd)
            {
                Console.WriteLine($"");
                col = 0; //Jump to start of Column 
                row += 1; //Change Row             
            }

            var isRowEnd = row > mainGridSize - 1;
            if (isRowEnd)
            {
                return true; 
            }

            return solve(mainGrid, row, col);       
        }


        public static bool checkGridValidity(char[,] mainGrid, int row = 0, int col = 0)
        {
            var mainGridSize = mainGrid.GetLength(0);
            var subGridSize = 3;
            var subGridNumber = (col / subGridSize) + (subGridSize * (row / subGridSize));
            Console.Write($"{subGridNumber}-> {mainGrid[row, col]}\t ");

            if (mainGrid[row, col] != '.')
            {

                if(!lookup.Add($"subgrid{subGridNumber}->{mainGrid[row, col]}"))
                {
                    return false;
                }

                if (!lookup.Add($"row{row}->{mainGrid[row, col]}"))
                {
                    return false;
                }
               
                if(!lookup.Add($"col{col}->{mainGrid[row, col]}"))
                {
                    return false;
                }            
            }

            col += 1;
            var isColumnEnd = col > mainGridSize - 1;
            if (isColumnEnd)
            {
                Console.WriteLine($"");
                col = 0; //Jump to start of Column 
                row += 1; //Change Row             
            }

            var isRowEnd = row > mainGridSize - 1;
            if (isRowEnd)
            {
                return true;
            }

            return checkGridValidity(mainGrid, row, col);
        }

    }
}
