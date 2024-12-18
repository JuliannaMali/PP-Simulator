using Simulator.Maps;
using System.Reflection.Metadata.Ecma335;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        List<Creature> creatures = [new Orc("Gorbag", 6, 3), new Elf("Elandor", 4, 6), new Orc("Orc2", 3, 4)];

        Func<Creature, Creature, int> PowerComp = (Creature creature1, Creature creature2) => creature1.Power.CompareTo(creature2.Power);

        

        creatures.Sort(PowerComp.Invoke);

        foreach(Creature creature in creatures)
        {
            Console.WriteLine($"{creature} - {creature.Power}");
        }
    }
 
}