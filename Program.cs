namespace randomizer;

class Program
{
    static void Main(string[] args)
    {

        string name;
        List<string> names = [];
        Console.WriteLine("Ingresa los nombres de los jugadores separados por una coma, para cerrar ingresa 0");

        name = new(Console.ReadLine());

        if (String.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("lista no puede estar vacia");
        }
        if (name == "0")
        {
            return;
        }

        string[] namesArray = name.Split(',');
        HashSet<string> validateUniqueNames = new(namesArray);
        if (validateUniqueNames.Count != namesArray.Length)
        {
            Console.WriteLine("no puedes repetir nombres");
            return;
        }
        if (namesArray.Length != 10)
        {
            Console.WriteLine("lista de nombres invalida");
            return;
        }
        foreach (string nam in namesArray)
        {
            if (String.IsNullOrWhiteSpace(nam))
            {
                Console.WriteLine("lista de nombres invalida");
                return;
            }

            names.Add(nam.Trim());
        }

        Random random = new();
        Console.WriteLine("=====================================");

        Console.WriteLine("pickeando equipos");

        // string[] names = new string[] { "Diego", "Ricardo", "Nacho", "Byron", "Nelson", "Nupri", "Tony", "Punpun", "Sewit", "Carlos" };

        List<string> team1 = [];
        List<string> team2 = [];
        List<string> selecteds = [];

        for (int i = 0; i < 5; i++)
        {
            int index = random.Next(0, names.Count);
            string selectedName = names[index];

            while (selecteds.Contains(selectedName))
            {
                index = random.Next(0, names.Count);
                selectedName = names[index];
            }

            selecteds.Add(selectedName);
            team1.Add(selectedName);
        }

        foreach (string selectedName in names)
        {
            if (!selecteds.Contains(selectedName))
            {
                team2.Add(selectedName);
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
