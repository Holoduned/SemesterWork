using System;
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
            var path = @"C:\Users\79625\Desktop\файлики семестровка\Data.txt";
            var alphabet = "!+=123456789ABCDEFGHIGKLMNOPQRSTUVWXYZ";
            Filework.GenerateFile(path, alphabet);
            
            var file = Filework.ReadFile(path);
            StreamWriter fileWrite = new StreamWriter(@"C:\Users\79625\Desktop\файлики семестровка\results.txt", true);
            for (int i = 0; i < file.Length; i++)
            {
                Stopwatch localTimer = new();
                
                var dictionary = new DataManager();
                dictionary.CreateDictionary(file[i]);
                var DataList = DataManager.DataList(dictionary.dictionary);
                var WeightList = DataManager.WeightList(dictionary.dictionary);
                
                localTimer.Start();
                var resultCode = Huffman_s_algorithm.HuffmanAlgorithm(DataList, WeightList, file[i]);
                localTimer.Stop();
                
                Console.WriteLine($"Закодированное слово - {resultCode}, его длина - {resultCode.Length}");
                fileWrite.WriteLine($"{resultCode.Length}.{localTimer.Elapsed.TotalSeconds}.{file[i].Length}");
            }
            fileWrite.Close();
            
            
            //abracadabra
            //beep5boop5beer!
            //ааааааааааааааабббббббввввввггггггддддд
        }
    }
}