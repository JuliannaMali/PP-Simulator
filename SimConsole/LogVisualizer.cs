using SimConsole;
using Simulator.Maps;
using System.Text;

namespace Simulator;

public class LogVisualizer
{
    SimulationHistory Log { get; }
    public LogVisualizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int id)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int cols = Log.SizeX - 1;
        int rows = Log.SizeY - 1;

        SimulationTurnLog current = Log.TurnLogs[id];

        Dictionary<Point, char> symbols = current.Symbols;
        
        if(id == 0)
        {
            Console.WriteLine("Starting positions\n");
        }
        else
        {
            Console.Write($"Turn {id}\n{Log.TurnLogs[id - 1].Mappable} goes {Log.TurnLogs[id - 1].Move}\n");
        }
        
        
        //top
        Console.Write($"{Box.TopLeft}{Box.Horizontal}");
        for (int i = 0; i < cols; i++)
        {
            Console.Write($"{Box.TopMid}{Box.Horizontal}");
        }
        Console.Write($"{Box.TopRight}");


        //mid
        for(int i = rows; i >= 0; i--)
        {
            Console.Write($"\n{Box.Vertical}");

            for(int j = 0; j <= cols; j++)
            {
                Point p = new Point(j, i);

                Console.Write($"{symbols[p]}{Box.Vertical}");

            }
                

            if (i > 0)
            {
                Console.Write($"\n{Box.MidLeft}{Box.Horizontal}");
                var middle = $"{Box.Cross}{Box.Horizontal}";
                for (int x = 0; x < cols - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.Cross}{Box.Horizontal}{Box.MidRight}");
            }
            else
            {
                Console.Write($"\n{Box.BottomLeft}{Box.Horizontal}");
                var middle = $"{Box.BottomMid}{Box.Horizontal}";
                for (int x = 0; x < cols - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.BottomMid}{Box.Horizontal}{Box.BottomRight}\n");
            }
        }

    }

}
