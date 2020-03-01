using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    class UI
    {
        static public void ShowMsg(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.WriteLine("");
        }
        static public int ShowMainMenu()
        {
            Console.WriteLine("==================SUDOKU=====================");
            Console.WriteLine("Select from main options below:");
            Console.WriteLine();
            Console.WriteLine("1. Read sudoku from a text file and solve");
            Console.WriteLine("2. Solve Sudoku");
            Console.WriteLine("3. Create sudoku based on difficulty");
            Console.WriteLine("4. Exit");
            Console.WriteLine("=============================================");
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
                Console.WriteLine("Enter file name: (ex: sudoku.txt)");
                result = Console.ReadLine();

            } while (!(result.Length >= 5 && result.EndsWith(".txt")));
            return result;
        }

        internal static void ShowValidSudokuFormat()
        {
            Console.WriteLine("");
            Console.WriteLine("51.....83");
            Console.WriteLine("8..416..5");
            Console.WriteLine(".........");
            Console.WriteLine(".985.461.");
            Console.WriteLine("...9.1...");
            Console.WriteLine(".642.357.");
            Console.WriteLine(".........");
            Console.WriteLine("6..157..4");
            Console.WriteLine("78.....96");
            Console.WriteLine("");
        }
    }
}
