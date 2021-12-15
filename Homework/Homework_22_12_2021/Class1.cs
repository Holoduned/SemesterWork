using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Study.Homework.Homework_22_12_2021
{
    #region Пространство
    public class Vector3D
    {
        public int X, Y, Z;
        public Vector3D(int x, int y, int z)
        {
            X = x; Y = y; Z = z;
        }

        public override int GetHashCode()
        {
            return (X * Y * Z) % 10;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        public override bool Equals(object obj)
        {
            var compare = obj as Vector3D;
            if (compare.X == X && compare.Y == Y && compare.Z == Z)
            {
                return true;
            }
            return false;
        }
    }
    #endregion

    #region Аэропорт
    public struct AEROFLOT
    {
        public string destination, plane_type;
        public int flight_number;

        public AEROFLOT(string dest, int num, string type)
        {
            destination = dest; plane_type = type; flight_number = num;
        }

        public AEROFLOT[] PlaneInput()
        {
            AEROFLOT[] flights = new AEROFLOT[7];
            for (int i = 0; i < 7; i++)
            {
                flights[i] = new AEROFLOT(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
            }
            return flights;
        }

        public static void CheckDestination(AEROFLOT[] mas, string s)
        {
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].destination == s)
                {
                    Console.WriteLine($"Номер самолета - {mas[i].flight_number}, тип самолета - {mas[i].plane_type}");
                    count++;
                }
            }
            if (count  == 0) { Console.WriteLine("Рейсов не найдено"); }
        }

        public static AEROFLOT[] Sort(AEROFLOT[] mas)
        {
            AEROFLOT temp;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i].flight_number > mas[j].flight_number)
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }
    #endregion

    #region Поезда
    public struct Train
    {
        public string destination, dep_time;
        public int train_number;

        public Train(string dest, int num, string time)
        {
            destination = dest; dep_time = time; train_number = num;
        }

        public Train[] TrainInput()
        {
            Train[] trains = new Train[8];
            for (int i = 0; i < 8; i++)
            {
                trains[i] = new Train(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
            }
            return trains;
        }

        public static void CheckDestination(Train[] mas, int n)
        {
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].train_number == n)
                {
                    Console.WriteLine($"Пункт назначение - {mas[i].destination}, номер поезда - {mas[i].train_number}, время отправления - {mas[i].dep_time}");
                    count++;
                }
            }
            if (count == 0) { Console.WriteLine("Рейсов не найдено"); }
        }

        public static Train[] Sort(Train[] mas)
        {
            Train temp;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i].train_number > mas[j].train_number)
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }
    #endregion

    #region Файл и дата
    public class Files
    {
        public static void FileCreate()
        {
            File.WriteAllText(@"C:\Users\79625\Desktop\filestask\task4(1)", DateTime.Now.ToString());
            File.WriteAllText(@"C:\Users\79625\Desktop\filestask\task4(2)", DateTime.Now.ToString());
            File.WriteAllText(@"C:\Users\79625\Desktop\filestask\task4(3)", DateTime.Now.ToString());
        }

        public static void FilePrint()
        {
            string[] mas_files = Directory.GetFiles(@"C:\Users\79625\Desktop\filestask");
            string newest = mas_files[0];
            foreach (string s in mas_files)
            {
                if (File.GetLastWriteTime(s) > File.GetLastWriteTime(newest))
                {
                    newest = s;
                }
            }
            Console.WriteLine(File.GetLastWriteTime(newest));
        }
    }
    #endregion
}
