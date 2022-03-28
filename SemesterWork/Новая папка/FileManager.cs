using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterWork
{
    public class FileManager
    {
        public static void DataGeneration()
        {
            var random = new Random();
            int DataCount = new Random().Next(50, 100);
            string[] Data = new string[DataCount];

            for (int data = 0; data < DataCount; data++)
            {
                int VertexCount = new Random().Next(2, 142);
                int EdgeCount = new Random().Next(1, VertexCount * (VertexCount - 1) / 2);
                var sb = new StringBuilder();
                sb.Append(new Random().Next(1, VertexCount) + " " + new Random().Next(1, VertexCount) + " " + new Random().Next(1, 100));

                for (int i = 0; i < EdgeCount; i++)
                {
                    sb.Append("," + new Random().Next(1, VertexCount) + " " + new Random().Next(1, VertexCount) + " " + new Random().Next(1, 100));
                }
                Data[data] = sb.ToString();

            }

            File.WriteAllLines(@"C:\Users\79625\Desktop\файлики семестровка\Data.txt", Data);

        }

        public static List<List<Edge>> FileReading(string path)
        {
            while (!File.Exists(path) || !Directory.Exists(Path.GetDirectoryName(path)) || path == null)
            {
                Console.WriteLine("Директории или файла не существует или не был введен путь к файлу.");
                path = Console.ReadLine();
            }

            var file = File.ReadAllLines(path).ToList();
            var AllData = new List<List<Edge>>();

            for (int i = 0; i < file.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(file[i]))
                    continue;
                AllData.Add(WorkWithData.CreateGraph(file[i].Split(",")).ToList());
            }

            return AllData;
        }
    }

    public class WorkWithData
    {
        public static Edge[] CreateGraph(string[] data)
        {
            var graph = new Edge[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                var vectorData = Array.ConvertAll(data[i].Split(' '), int.Parse);
                graph[i] = new Edge(vectorData[0], vectorData[1], Convert.ToInt32(vectorData[2]));
            }
            return graph;
        }
    }
}
