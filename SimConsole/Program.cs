using SimConsole;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");


        BigTorusMap map = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Króliki", Size = 7}, new Birds() { Description = "Orły", Size = 2}, new Birds() { Description = "Strusie", CanFly = false}];
        List<Point> points = [new(2, 2), new(3, 1), new(5, 2), new(6, 0), new(6, 3)];
        string moves = "dlrludlldrluuduldurr";

        Simulation simulation = new(map, creatures, points, moves);

        SimulationHistory historia = new(simulation);
        LogVisualizer logvisualizer = new(historia);

        
        logvisualizer.Draw(0);
        logvisualizer.Draw(5);
        logvisualizer.Draw(10);
        logvisualizer.Draw(15);
        logvisualizer.Draw(20);



        /*        MapVisualizer mapVisualizer = new(simulation.Map);



                var turn = 1;
                mapVisualizer.Draw();

                while (!simulation.Finished)
                {
                    Console.ReadKey();

                    Console.WriteLine($"Tura {turn}");
                    Console.Write($"{(object)simulation.CurrentMappable} goes {simulation.CurrentMoveName}\n");


                    Console.WriteLine();
                    simulation.Turn();
                    mapVisualizer.Draw();
                    turn++;
                }*/
    }
}