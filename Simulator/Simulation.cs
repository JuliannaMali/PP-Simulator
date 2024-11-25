using Simulator;
using Simulator.Maps;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    private int counter = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    {
        get
        {
            return Creatures[counter%Creatures.Count];
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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        Map = map;
        if(creatures.Count == 0)
        {
            throw new ArgumentException("Lista stworów jest pusta");
        }
        else
        {
            Creatures = creatures;
        }

        if (creatures.Count != positions.Count)
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


        for (int i = 0; i<creatures.Count; i++)
        {
            Map.Add(creatures[i], positions[i]);
        }

    }

    /// <summary>
    /// Makes one move of current creature in current direction.
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

            Map.Move(CurrentCreature, CurrentCreature.Position, Map.Next(CurrentCreature.Position, move));

            counter++;
            if (counter >= Moves.Length)
            {
                Finished = true;
            }
        }
       
    }
}
