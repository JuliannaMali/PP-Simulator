using Simulator.Maps;
namespace Simulator;

public abstract class Creature
{
    
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point p) { }
    





    
    private string name = "Unknown";
    private int level = 1;


    public string Name   
    { 
        get => name;
        init
        {
            name = Validator.ShortnerCA(value, 3, 25, '#');
        }
    }

    public int Level 
    {
        get => level; 
        init
        {
            level = Validator.LimiterEO(value, 1, 10);
        }
    }

    public void Upgrade()
    {
        if (this.level < 10)
        {
            this.level += 1;
        }
    }

    
    public Creature(string name, int level = 1)
    {
        
        this.Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();

    public abstract string Info { get;  }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }


    public string Go(Direction direction)
    {
        //zgodnie z regulami Map
        
        return $"{direction.ToString().ToLower()}";

        //mapa musi przestawić stwora, wywołac move z mapy
    }


    //out
    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }


    //out
    public void Go(string dir)
    {
        Go(DirectionParser.Parse(dir));
    }

    public abstract int Power { get; }
}

