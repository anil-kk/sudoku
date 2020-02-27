using System.Linq;

namespace Sudoku
{
    class Program
    {

        private static char[,] _sudoku_9x9_mainGrid = new char[,] {
            {'5','1','.','.','.','.','.','8','3' },
            {'8','.','.','4','1','6','.','.','5' },
            {'.','.','.','.','.','.','.','.','.' },
            {'.','9','8','5','.','4','6','1','.' },
            {'.','.','.','9','.','1','.','.','.' },
            {'.','6','4','2','.','3','5','7','.' },
            {'.','.','.','.','.','.','.','.','.' },
            {'6','.','.','1','5','7','.','.','4' },
            {'7','8','.','.','.','.','.','9','6' }
        };
        static void Main(string[] args)
        {
            int userInput;
            do
            {
                userInput = UI.ShowMainMenu();

                if (userInput == 1)
                {
                    File.ReadFile();
                }
                if (userInput == 2)
                {
                    Game.puzzleSolver(_sudoku_9x9_mainGrid);
                }

            } while (userInput != 4);
        }
    }
}
