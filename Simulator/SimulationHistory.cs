using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0
        
    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? 
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        //pozycje startowe
        Dictionary<Point, char> sym = new();

        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                var creatures = _simulation.Map.At(i, j);
                
                if(creatures != null && creatures.Count != 0)
                {
                    switch (creatures.Count)
                    {
                        case 1:
                            sym[new Point(i, j)] = creatures[0].Symbol;
                            break;
                        case > 1:
                            sym[new Point(i, j)] = 'X';
                            break;
                    }
                }
                else
                {
                    sym[new Point(i, j)] = ' ';
                }
            }
        }
        var tura0 = new SimulationTurnLog
        {
            Mappable = _simulation.CurrentMappable.ToString(),
            Move = _simulation.CurrentMoveName,
            Symbols = sym,
        };

        TurnLogs.Add(tura0);

        int counter = 1;


        //pętla dla wszystkich innych
        while (!_simulation.Finished)
        {
            _simulation.Turn();
            
            Dictionary<Point, char> sym1 = new();

            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    var creatures = _simulation.Map.At(i, j);

                    if (creatures != null && creatures.Count != 0)
                    {
                        switch (creatures.Count)
                        {
                            case 1:
                                sym1[new Point(i, j)] = creatures[0].Symbol;
                                break;
                            case > 1:
                                sym1[new Point(i, j)] = 'X';
                                break;
                        }
                    }
                    else
                    {
                        sym1[new Point(i, j)] = ' ';
                    }
                }
            }


            if(counter < _simulation.Moves.Length)
            {
                var tura = new SimulationTurnLog
                {
                    Mappable = _simulation.CurrentMappable.ToString(),
                    Move = _simulation.CurrentMoveName,
                    Symbols = sym1,
                };
                TurnLogs.Add(tura);
            }
            else if (counter == _simulation.Moves.Length)
            {
                var tura = new SimulationTurnLog
                {
                    Mappable = _simulation.CurrentMappable.ToString(),
                    Move = "",
                    Symbols = sym1,
                };
                TurnLogs.Add(tura);
            }

            counter++;

        }
    }

}
