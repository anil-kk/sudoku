using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Sudoku
{
    class FileHandler
    {
        static public char[,] GetSudokuGrid()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);
            var fileName = UI.GetFilenameFromUser("Enter file name to load: (ex: sudoku.txt)");

            List<string> sudokuRows = new List<string>();

            try { 
                using (StreamReader reader = new StreamReader(directory + @"\" + fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        sudokuRows.Add(reader.ReadLine());
                    }
                }

                var result = sudokuRows.Select(item => item.ToCharArray()).ToArray();

                if(result.GetLength(0) == 9 && result[0].Length == 9)
                {
                    return JaggedArrayTo2D(result);
                }
                return new char[,] { };
            }

            catch
            {
                return new char[,] { };
            }
        }

        static public bool PersistSudokuGrid(char[,] grid)
        {
            if (!UI.UserPromt())
            {
                return false;
            }
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);
            var fileName = UI.GetFilenameFromUser("Enter file name to save: (ex: sudoku.txt)");

            try
            {
                using (var writer = new StreamWriter(directory + @"\" + fileName))
                {
                    for (int row = 0; row < grid.GetLength(0); row++)
                    {
                        for (int col = 0; col < grid.GetLength(1); col++)
                        {                        
                            writer.Write(grid[row, col]);
                            if (col == 8)
                            {
                                writer.WriteLine("");
                            }                                
                        }
                    }
                }
                return true;
            }

            catch
            {
                return false;
            }
        }

        static char[,] JaggedArrayTo2D(char[][] jaggedArray)
        {
            char[,] result = new char[jaggedArray.Length, jaggedArray[0].Length];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int k = 0; k < jaggedArray[0].Length; k++)
                {
                    result[i, k] = jaggedArray[i][k];
                }
            }

            return result;
        }
    }
}
