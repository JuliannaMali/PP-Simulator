using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unidentified";
    public required string Description
    {
        get => description;
        init
        {
            description = Validator.ShortnerCA(value, 3, 15, '#');
        }
    }
    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";


    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public virtual char Symbol { get; } = 'A';


    public void InitMapAndPosition(Map map, Point p)
    {
        Map = map;
        Position = p;
    }
    public virtual void Go(Direction direction)
    {
        Map?.Move(this, Position, Map.Next(Position, direction));
    }

    

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
