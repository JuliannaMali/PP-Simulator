namespace Simulator;

internal class Elf : Creature
{
    private int agility;
    public int Agility
    {
        get => agility;

        init
        {
            if (value < 0)
            {
                agility = 0;
            }
            else if (value > 10)
            {
                agility = 10;
            }
            else
            {
                agility = value;
            }
        }
    }

    private int counter = 0;
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing");
        counter++;
        if (counter == 3)
        {
            if (agility == 10)
            {
                agility = 10;
                counter = 0;
            }
            else
            {
                agility++;
                counter = 0;
            }
        }
    }



    public Elf() : base() {}

    public Elf(string name, int level = 1, int agility = 1) : base(name,level)
    {
            Agility = agility;
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );

    public override int Power
    {
        get { return (Level * 8 + 2 * Agility); }
    }

}
