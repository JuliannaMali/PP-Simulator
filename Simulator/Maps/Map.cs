namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public readonly int SizeX;
    public readonly int SizeY;

    private Rectangle mapa;

    protected Func<Map, Point, Direction, Point>? FNext { get; set; }
    protected Func<Map, Point, Direction, Point>? FNextDiagonal { get; set; }

    Dictionary<Point, List<IMappable>> _fields;

    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }

        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;

        mapa = new Rectangle(0, 0, SizeX - 1, SizeY - 1);

        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public void Add(IMappable mappable, Point p)
    {
        if (!_fields.ContainsKey(p))
        {
            _fields[p] = new List<IMappable>();

        }

        _fields[p].Add(mappable);

        mappable.InitMapAndPosition(this, p);
    }
    public void Remove(IMappable mappable, Point p)
    {
        _fields[p].Remove(mappable);
    }
    public void Move(IMappable mappable, Point p, Point p2)
    {
        Remove(mappable, p);
        Add(mappable, p2);
    }

    public List<IMappable>? At(int x, int y)
    {
        var p = new Point(x, y);
        if (_fields.ContainsKey(p))
        {
            return _fields[p];
        }
        return new List<IMappable>();
    }

    public List<IMappable>? At(Point p)
    {
        if (_fields.ContainsKey(p))
        {
            return _fields[p];
        }
        return new List<IMappable>();
    }


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => mapa.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;

}
