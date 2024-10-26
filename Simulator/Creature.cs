namespace Simulator;

internal class Creature
{
    private string name;
    private int level;

    public string? Name { get; }

    public int Level { get; set; } = 1;


    public Creature(string name, int level = 1)
    {
        this.name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi() => Console.WriteLine($"Hi, my name is {Name} and my level is {Level}");

    public string Info => $"{Name} - {Level}";

}
