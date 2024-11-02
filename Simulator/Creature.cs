namespace Simulator;

abstract class Creature
{
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

    public abstract void SayHi();

    public abstract string Info { get;  }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }


    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}: ");
    }


    public void Go(Direction[] directions)
    {
        foreach(Direction element in directions)
        {
            Go(element);
        }
    }

    public void Go(string dir)
    {
        Go(DirectionParser.Parse(dir));
    }

    public abstract int Power { get; }
}

