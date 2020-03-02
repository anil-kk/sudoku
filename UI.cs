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

        static public void ShowHorizontalDivider()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        static public void NewLineWithTab()
        {
            Console.WriteLine($"");
            Console.Write($"\t");
        }
        static public void NewLine()
        {
            Console.WriteLine($"");
        }
        static public int ShowMainMenu()
        {
            Console.WriteLine("==========================SUDOKU=================================");
            Console.WriteLine("Select from main options below:");
            Console.WriteLine();
            Console.WriteLine("1. Read unsolved sudoku from a file, Solve and Classify");
            Console.WriteLine("2. Solve Sudoku");
            Console.WriteLine("3. Create a new unsolved sudoku and save it to file");
            Console.WriteLine("4. Exit");
            Console.WriteLine("===============================================================");
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

        static public string GetFilenameFromUser(string msg)
        {
            string result;
            do
            {
                ShowMsg(msg);
                result = Console.ReadLine();

            } while (!(result.Length >= 5 && result.EndsWith(".txt")));
            return result;
        }


        static public bool UserPromt()
        {
            string result;
         
            do
            {
                ShowMsg("Do you want to save the result to a file? Yes or No");
                result = Console.ReadLine().ToLower();
            } while (result != "yes" && result!="no" && result != "y" && result != "n");

         
            if (result == "y" || result == "yes")
            {
                return true;
            }

            return false;
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
