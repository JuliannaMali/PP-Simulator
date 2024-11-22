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

    private bool turn = false;
    private bool reset = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    {
        get
        {
            for(int i =0; i<Creatures.Count;)
            {
                if (turn)
                {
                    i++;
                    turn = false;
                }

                if (reset)
                {
                    i = 0;
                    reset = false;
                }

                return Creatures[i];
            }

            return Creatures[0];
        } 
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {

        get
        {
            for(int i=0; i< Moves.Length; i++)
            {
                if (turn)
                {
                    i++;
                    turn = false;
                }

                string move = Moves[i].ToString().ToLower();

                switch (move)
                {
                    case "u":
                        return "up";
                    case "d":
                        return "down";
                    case "r":
                        return "right";
                    case "l":
                        return "left";
                }
            }
            return Moves;
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
            throw new ArgumentException("Nie każdy stwór ma pozycję startową");
        }
        else
        {
            Positions = positions;
        }

        Moves = string.Concat(DirectionParser.Parse(moves));

    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        int difference = Moves.Length - Creatures.Count();

        if(difference != 0 && CurrentCreature == Creatures[difference-1])
        {
            reset = true;
        }
        
        string temp = CurrentMoveName[0].ToString();
        var move = DirectionParser.Parse(temp);

        CurrentCreature.Go(move[0]);
        
        turn = true;
       
    }
}
