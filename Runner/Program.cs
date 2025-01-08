using Simulator.Maps;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        //List<Creature> creatures = [new Orc("Gorbag", 6, 3), new Elf("Elandor", 4, 6), new Orc("Orc2", 3, 4)];

        //Func<Creature, Creature, int> PowerComp = (Creature creature1, Creature creature2) => creature1.Power.CompareTo(creature2.Power);



        //creatures.Sort(PowerComp.Invoke);

        //foreach(Creature creature in creatures)
        //{
        //    Console.WriteLine($"{creature} - {creature.Power}");
        //}


        //var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        //Orc o1 = new("Gorbag", 3, 5);
        //string json = JsonSerializer.Serialize(o1, jsonOptions);
        //Console.WriteLine(json);

        //Orc? o2 = JsonSerializer.Deserialize<Orc>(json);
        //Console.WriteLine(o2);


        //Point p1 = new(2, 4);
        //string json1 = JsonSerializer.Serialize(p1);
        //Console.WriteLine(json1); // {}

        //Point p2 = JsonSerializer.Deserialize<Point>(json1);
        //Console.WriteLine(p2);

        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mapables = [
            new Orc("Gorbag", 3, 5),
            new Elf("Elandor", 2, 7),
            new Animals { Description = "Rasbbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 15 },
            new Birds { Description = "Emu", Size = 8, CanFly = false }
        ];

        string json = JsonSerializer.Serialize(mapables, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        List<IMappable> deserialized =
            JsonSerializer.Deserialize<List<IMappable>>(json, options)!;
    }
 
}