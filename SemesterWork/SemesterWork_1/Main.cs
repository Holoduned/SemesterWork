/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;  

namespace SemesterWork
{
    class Programm
    {
        static void Main(string[] args)
        {
            //FileManager.DataGeneration();
            var file = FileManager.FileReading(@"C:\Users\79625\Desktop\файлики семестровка\Data.txt");
            StreamWriter fileWrite = new StreamWriter(@"C:\Users\79625\Desktop\файлики семестровка\results.txt", true);
            foreach (var line in file)
            {
                var timer = new Stopwatch();
                timer.Start();
                var result = AlgorithmByPrim.algorithmByPrim(line);
                timer.Stop();
                fileWrite.WriteLine($"{timer.Elapsed.TotalSeconds}.{result[1]}.{line.Count} ");
            }
            fileWrite.Close();



        }
    }
}*/
