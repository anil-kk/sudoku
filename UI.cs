using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class UI
    {
        static public int ShowMainMenu()
        {
            Console.WriteLine("==================SUDOKU=====================");
            Console.WriteLine("Select from main options below:");
            Console.WriteLine();
            Console.WriteLine("1. Read sudoku from a text file");
            Console.WriteLine("2. Solve Sudoku and Classify difficulty");
            Console.WriteLine("3. Create sudoku based on difficulty");
            Console.WriteLine("4. Exit");
            var result = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(result) || result.Length != 1)
            {
                return 0;
            }

            try
            {
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }

        }

        static public string GetFilenameFromUser()
        {
            string result;
            do
            {
                Console.WriteLine("Enter file name:");
                result = Console.ReadLine();

            } while (!(result.Length >= 5 && result.EndsWith(".txt")));
            return result;
        }
    }
}
