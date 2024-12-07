namespace Simulator.Maps;

public abstract class BigMap : Map
{

    Dictionary<Point, List<IMappable>> _fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX>1000)
        {
            throw new ArgumentException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 1000)
        {
            throw new ArgumentException(nameof(sizeY), "Too high");
        }

        _fields = new Dictionary<Point, List<IMappable>> ();

    }

    public override void Add(IMappable mappable, Point p)
    {
        if (!_fields.ContainsKey(p))
        {
            _fields[p] = new List<IMappable>();
            
        }
        
        _fields[p].Add(mappable);

        mappable.InitMapAndPosition(this, p);
    }

    public override void Remove(IMappable mappable, Point p)
    {
        _fields[p].Remove(mappable);
    }

    public override List<IMappable>? At(int x, int y)
    {
        var p = new Point(x, y);
        if (_fields.ContainsKey(p))
        {
            return _fields[p];
        }
        return new List<IMappable>();
    }

    public override List<IMappable>? At(Point p)
    {
        if (_fields.ContainsKey(p))
        {
            return _fields[p];
        }
        return new List<IMappable>();
    }

    public override void Move(IMappable mappable, Point p, Point p2)
    {
        Remove(mappable, p);
        Add(mappable, p2);
    }
}
