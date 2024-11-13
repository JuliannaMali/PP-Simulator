namespace Simulator;

public class Elf : Creature
{
    private int agility;
    public int Agility
    {
        get => agility;

        init
        {
            agility = Validator.LimiterEO(value, 0, 10);
        }
    }

    private int counter = 0;
    public void Sing()
    {
       
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

    public override string Greeting() => 
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public override int Power
    {
        get { return (Level * 8 + 2 * Agility); }
    }

    public override string Info
    {
        get { return $"{Name} [{Level}] [{Agility}]"; }
    }

}
