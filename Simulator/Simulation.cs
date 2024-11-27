using Simulator;
using Simulator.Maps;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    private int counter = 0;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable 
    {
        get
        {
            return Mappables[counter%Mappables.Count];
        } 
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {

        get
        {  
            return DirectionParser.Parse(Moves)[counter].ToString().ToLower();

        }

    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        Map = map;
        if(mappables.Count == 0)
        {
            throw new ArgumentException("Lista stworów jest pusta");
        }
        else
        {
            Mappables = mappables;
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("Liczba stworów a liczba punktów są różne");
        }
        else
        {
            Positions = positions;
        }


        var tempmoves = (DirectionParser.Parse(moves));
        List<char> shorttempmoves = new List<char>();
        {
            for (int i = 0; i < tempmoves.Count; i++)
            {
                string anothertemp = tempmoves[i].ToString();
                shorttempmoves.Add(anothertemp[0]);
            }
        }
        Moves = string.Concat(shorttempmoves);


        for (int i = 0; i<mappables.Count; i++)
        {
            Map.Add(mappables[i], positions[i]);
        }

    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished)
        {
            throw new Exception("Symulacja zakończona");
        }
        else
        {
            var move = DirectionParser.Parse(Moves)[counter];

            CurrentMappable.Go(move);

            counter++;
            if (counter >= Moves.Length)
            {
                Finished = true;
            }
        }
       
    }
}
