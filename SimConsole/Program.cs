﻿using SimConsole;
using Simulator.Maps;
using System.Text;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Console.WriteLine("Starting positions");


        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);



        var turn = 1;
        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.ReadKey();
            
            Console.WriteLine($"Tura {turn}");
            Console.Write($"{simulation.CurrentCreature.Info} {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}\n");


            Console.WriteLine();
            simulation.Turn();
            mapVisualizer.Draw();
            turn++;
        }
    }
}