using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.задание_класс
{
    public interface IPlayer
    {
        void Play();
    }

    public class Player
    {
        public void Football(FootballPlayer input)
        {
            if (input.Age < 20)
            {
                input.Play();
            }
        }

        public void Musician(Musician input)
        {
            if (input.Instrument == "Скрипка")
            {
                input.Play();
            }
        }
    }

    public class PlayerManager
    {
        public static IPlayer[] PlayersInput(int n)
        {
            IPlayer[] players = new IPlayer[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Футболист или музыкант?");
                string s = Console.ReadLine();
                if (s == "Футболист")
                {
                    players[i] = new FootballPlayer(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                }
                else
                {
                    players[i] = new Musician(Console.ReadLine(), Console.ReadLine());
                }
            }
            return players;
        }

        public static void Manager(IPlayer[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] is FootballPlayer)
                {
                    var player = (FootballPlayer)mas[i];
                    if (player.Age< 20)
                    {
                        Console.WriteLine($"{player.Name}, {player.Age}");
                        player.Play();
                    }
                }

                else if (mas[i] is Musician)
                {
                    var player = (Musician)mas[i];
                    if (player.Instrument == "Скрипка")
                    {
                        Console.WriteLine($"{player.Name}, {player.Instrument}");
                        player.Play();
                    }
                }
            }
        }
    }

    public class FootballPlayer : IPlayer
    {
        public string Name; public int Age;

        public FootballPlayer(string name, int age)
        {
            Name = name; Age = age;
        }

        public void Play()
        {
            Console.WriteLine("Футболист играет");
        }
    }

    public class Musician : IPlayer
    {
        public string Name, Instrument;

        public Musician(string name, string inst)
        {
            Name = name; Instrument = inst;
        }

        public void Play()
        {
            Console.WriteLine("Музыкант играет");
        }
    }

}
