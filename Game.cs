﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku
{
    class Game
    {
        static Random _random = new Random();
        static HashSet<string> lookup = new HashSet<string>();
        static char[] digits = new char[]
        {
            '1','2','3','4','5','6','7','8','9'
        };
        public static void puzzleSolver(char[,] mainGrid)
        {
            var isGridValid = CheckGridValidity(mainGrid);

            if (!isGridValid)
            {
                UI.ShowMsg("Given SUDOKU grid is not valid or It is already Solved!");
                return;
            }

            UI.ShowMsg("Given SUDOKU grid seems to be a valid one, solving...");

            Classify();

            SolveGrid(mainGrid);

            ShowSolvedGrid(mainGrid);

            UI.ShowMsg("Exiting!");
            lookup.Clear();
        }

        private static bool SolveGrid(char[,] mainGrid, int row = 0, int col = 0)
        {
            var mainGridSize = mainGrid.GetLength(0); 
            var subGridSize = 3;
            var subGridNumber = (col / subGridSize) + (subGridSize * (row / subGridSize));
            var isRowEnd = row > mainGridSize - 1;
            if (isRowEnd)
            {
                return true;
            }

            var isColumnEnd = col >= mainGridSize - 1;

            var isCurrentCellFilled = mainGrid[row, col] != '.';
            if (isCurrentCellFilled)
            {
                return SolveGrid(mainGrid, isColumnEnd ? row + 1 : row, isColumnEnd ? 0 : col + 1);
            }
            var validDigits = FetchValidNumbers(row, col);

            foreach (var digit in validDigits)
            {
                var subGridValue = $"subgrid{subGridNumber}->{digit}";
                var rowValue = $"row{row}->{digit}";
                var colValue = $"col{col}->{digit}";

                if (lookup.Add(subGridValue) && lookup.Add(rowValue) && lookup.Add(colValue))
                {
                    mainGrid[row, col] = digit;
                    var pathResult = SolveGrid(mainGrid, isColumnEnd ? row + 1 : row, isColumnEnd ? 0 : col + 1);
                    if (pathResult)
                    {
                        return true;
                    }

                    lookup.Remove(subGridValue);
                    lookup.Remove(rowValue);
                    lookup.Remove(colValue);
                    mainGrid[row, col] = '.';
                }
            }
            return false;
        }

        private static char[] FetchValidNumbers(int row, int col)
        {
            var setOfValidDigits = new HashSet<char>(digits);
            var subGridSize = 3;
            var subGridNumber = (col / subGridSize) + (subGridSize * (row / subGridSize));

            foreach (var digit in digits)
            {
                var subGridValue = $"subgrid{subGridNumber}->{digit}";
                var rowValue = $"row{row}->{digit}";
                var colValue = $"col{col}->{digit}";

                if(lookup.Contains(subGridValue) || lookup.Contains(rowValue) || lookup.Contains(colValue)){

                    setOfValidDigits.Remove(digit);
                }
            }                
            return setOfValidDigits.ToArray();
        }

        private static bool CheckGridValidity(char[,] mainGrid, int row = 0, int col = 0)
        {
            var mainGridSize = mainGrid.GetLength(0);
            var subGridSize = 3;
            var subGridNumber = (col / subGridSize) + (subGridSize * (row / subGridSize));

            if (mainGrid[row, col] != '.')
            {

                if (!lookup.Add($"subgrid{subGridNumber}->{mainGrid[row, col]}"))
                {
                    return false;
                }

                if (!lookup.Add($"row{row}->{mainGrid[row, col]}"))
                {
                    return false;
                }

                if (!lookup.Add($"col{col}->{mainGrid[row, col]}"))
                {
                    return false;
                }
            }

            col += 1;
            var isColumnEnd = col > mainGridSize - 1;
            if (isColumnEnd)
            {
                col = 0; 
                row += 1;              
            }

            var isRowEnd = row > mainGridSize - 1;
            if (isRowEnd)
            {
                return true;
            }

            return CheckGridValidity(mainGrid, row, col);
        }

        private static void Classify()
        {
         var totalSubGridDigits =lookup.Select(item => item).Where(item => item.StartsWith("subgrid")).Count();

            var totalGridStrength = 1;

            for(int s = 0; s < 9; s++)
            {
                var eachSubGridDigitsCount = lookup.Select(item => item).Where(item => item.StartsWith($"subgrid{s}")).Count();

                totalGridStrength *= eachSubGridDigitsCount;
            }

            if(totalGridStrength < 5000)
            {
                UI.ShowMsg($"Given SUDOKU grid is classified as SAMURAI:  Grid Strength: {totalGridStrength}");
                return;
            }

            if (totalGridStrength < 10000)
            {
                UI.ShowMsg($"Given SUDOKU grid is classified as HARD:  Grid Strength :{totalGridStrength}");
                return;
            }

            if (totalGridStrength < 30000)
            {
                UI.ShowMsg($"Given SUDOKU grid is classified as Medium:  Grid Strength :{totalGridStrength}");
                return;
            }

            UI.ShowMsg($"Given SUDOKU grid is classified as EASY:  Grid Strength :{totalGridStrength}");
        }

        private static bool ShowSolvedGrid(char[,] mainGrid, int row = 0, int col = 0)
        {
            var mainGridSize = mainGrid.GetLength(0);
            Console.Write($"{mainGrid[row, col]}\t ");

            col += 1;
            var isColumnEnd = col > mainGridSize - 1;
            if (isColumnEnd)
            {
                Console.WriteLine($"");
                col = 0;
                row += 1;
            }

            var isRowEnd = row > mainGridSize - 1;
            if (isRowEnd)
            {
                return true;
            }

            return ShowSolvedGrid(mainGrid, row, col);
        }

    }
}
