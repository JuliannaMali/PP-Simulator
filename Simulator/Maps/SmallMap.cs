namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;  
    
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX>20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }

        if (sizeY>20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }

        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point p)
    {
        _fields[p.X, p.Y].Add(creature);
    }
    public override void Remove(Creature creature, Point p)
    {
        _fields[p.X, p.Y].Remove(creature);
    }
    public override List<Creature>? At(int x, int y)
    {
        return _fields[x, y];
    }
    public override List<Creature>? At(Point p)
    {
        return _fields[p.X, p.Y];
    }


}
