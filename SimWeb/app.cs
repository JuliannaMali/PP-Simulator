using Simulator.Maps;
using Simulator;

namespace SimWeb;

public static class App
{
    public readonly static SimulationHistory _historia;
    
    static App()
    {
        BigTorusMap mapa = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits", Size = 7 }, new Birds() { Description = "Eagles", Size = 2 }, new Birds() { Description = "Ostriches", CanFly = false }];
        List<Point> points = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
        string moves = "dlrludluddlrulr";

        Simulation simulation = new(mapa, creatures, points, moves);

        _historia = new(simulation);
    }
}
