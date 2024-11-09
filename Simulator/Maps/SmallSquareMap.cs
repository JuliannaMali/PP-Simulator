namespace Simulator.Maps;

internal class SmallSquareMap : Map
{
    public readonly int Size;

    public SmallSquareMap(int size)
    {

        if (4 < size && size < 21)
        {
            Size = size;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Podany wymiar mapy jest nieprawidłowy");
        }

    }

    public override bool Exist(Point p)
    {

        Rectangle map = new Rectangle(0, 0, (Size - 1), (Size - 1));
        return map.Contains(p);

    }

    public override Point Next(Point p, Direction d)
    {
        Rectangle map = new Rectangle(0, 0, (Size - 1), (Size - 1));

        if (map.Contains(p.Next(d)))
        {
            return p.Next(d);
        }
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Rectangle map = new Rectangle(0, 0, (Size - 1), (Size - 1));

        if (map.Contains(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        return p;
    }
}
