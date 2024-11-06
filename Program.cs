using System;
using System.Collections.Generic;

namespace randomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new();
            Console.WriteLine("Ingresa los nombres de los jugadores separados por una coma, para cerrar ingresa 0");

            string input = new(Console.ReadLine());

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("La lista no puede estar vacía");
                return;
            }
            if (input == "0")
            {
                return;
            }

            string[] namesArray = input.Split(',');
            HashSet<string> validateUniqueNames = new(namesArray);
            if (validateUniqueNames.Count != namesArray.Length)
            {
                Console.WriteLine("No puedes repetir nombres");
                return;
            }
            if (namesArray.Length != 10)
            {
                Console.WriteLine("Lista de nombres inválida");
                return;
            }
            foreach (string name in namesArray)
            {
                if (String.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Lista de nombres inválida");
                    return;
                }

                names.Add(name.Trim());
            }

            Random random = new();
            Console.WriteLine("=====================================");
            Console.WriteLine("Pickeando equipos");

            List<string> team1 = new();
            List<string> team2 = new();
            HashSet<string> selecteds = new();

            while (team1.Count < 5)
            {
                int index = random.Next(names.Count);
                string selectedName = names[index];

                if (!selecteds.Contains(selectedName))
                {
                    selecteds.Add(selectedName);
                    team1.Add(selectedName);
                }
            }

            foreach (string name in names)
            {
                if (!selecteds.Contains(name))
                {
                    team2.Add(name);
                }
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("Team 1");
            Console.WriteLine("=====================================");
            foreach (string member in team1)
            {
                Console.WriteLine(member);
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("Team 2");
            Console.WriteLine("=====================================");
            foreach (string member in team2)
            {
                Console.WriteLine(member);
            }

            Console.WriteLine("=====================================");
            Console.ReadKey();
        }
    }
}
