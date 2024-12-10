using SimConsole;
using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    //private Map mapa;
    private Dictionary<int, List<object>> historia = new();
    
    private int counter = 1;
    public SimulationHistory(Simulation sim) 
    {
        //mapa = sim.Map;
        historia = new();

        historia[counter-1] = new List<object>();
        historia[counter-1].Add(sim.Map);
        historia[counter-1].Add(sim.Mappables);

        while (!sim.Finished)
        {
            Map currentstate = sim.Map;

            
            historia[counter] = new List<object>();

            historia[counter].Add(currentstate);
            historia[counter].Add(sim.CurrentMappable);
            historia[counter].Add(sim.CurrentMoveName);
            historia[counter].Add(sim.Mappables);

        Console.WriteLine();
/*        for (int x = 0; x < ((Map)historia[counter][0]).SizeX; x++)
        {
            for (int y = 0; y < ((Map)historia[counter][0]).SizeY; y++)
            {
                if (((Map)historia[counter][0]).At(x, y)?.Count > 0)
                {
                    Console.WriteLine($"({x}, {y}) - {((Map)historia[1][0]).At(x, y)}");
                }
            }
        }
            MapVisualizer test = new((Map)historia[counter][0]);
            test.Draw();*/

            sim.Turn();

            counter++;
        }
    }

    public void Tura(int nr)
    {

        MapVisualizer mapbefore = new((Map)historia[nr - 1][0]);
        MapVisualizer mapa1 = new((Map)historia[nr][0]);

        Console.WriteLine();
        mapbefore.Draw();
        Console.WriteLine();
        mapa1.Draw();
        Console.WriteLine("---------");


/*        for (int x = 0; x < ((Map)historia[nr][0]).SizeX; x++)
        {
            for (int y = 0; y < ((Map)historia[nr][0]).SizeY; y++)
            {
                if (((Map)historia[nr][0]).At(x, y)?.Count > 0)
                {
                    Console.WriteLine($"({x}, {y}) - {((Map)historia[nr][0]).At(x, y)}");
                }
            }
        }*/
    }

}
