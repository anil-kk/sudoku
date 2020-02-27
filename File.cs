using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sudoku
{
    class File
    {
        static public void ReadFile()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);
            var fileName = UI.GetFilenameFromUser();

            List<string[]> values = new List<string[]>();
            using (StreamReader reader = new StreamReader(directory + @"\" + fileName))
            {
                while (!reader.EndOfStream)
                {
                    values.Add(reader.ReadLine().Split(','));
                }
            }
        }
    }
}
