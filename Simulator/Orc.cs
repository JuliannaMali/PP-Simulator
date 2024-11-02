namespace Simulator;

internal class Orc : Creature
{
    private int rage;
    public int Rage
    {
        get => rage;

        init
        {
            if (value < 0)
            {
                rage = 0;
            }
            else if (value > 10)
            {
                rage = 10;
            }
            else
            {
                rage = value;
            }
        }
    }

    private int counter = 0;
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting");
        counter++;
        if (counter == 2)
        {
            if (rage == 10)
            {
                rage = 10;
                counter = 0;
            }
            else
            {
                rage++;
                counter = 0;
            }
        }
    }

    public Orc() : base () { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
    );

    public override int Power
    {
        get { return (Level * 7 + 3 * Rage); }
    }
} 
