using System.Runtime.CompilerServices;

namespace Simulator;

internal class Creature
{
    private string name = "Unknown";
    private int level = 1;


    public string Name   
    { 
        get => name;
        init
        {
            name = value.Length > 0 ? value.ToUpper()[0] + value.Substring(1) : "Unknown";
            name = name.Length < 25 ? name : name.Substring(0, 24);
            name = name.Trim();
            name = name.Length>=3 ? name : name.PadRight(3, '#');
            name = (name.Trim().Length <= 3) ? name.Trim().PadRight(3, '#') : name.Trim();
            
        }
    }

    public int Level 
    {
        get => level; 
        init
        {
            if (value < 1 )
            {
                level = 1;
            }
            else if (value > 10)
            {
                level = 10;
            }
            else
            {
                level = value;
            }
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

    public void SayHi() => Console.WriteLine($"Hi, my name is {Name} and my level is {Level}");

    public string Info => $"{Name} - {Level}";



    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
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
}

