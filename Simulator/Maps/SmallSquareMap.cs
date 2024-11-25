namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public readonly int Size;
    public SmallSquareMap(int size) : base(size, size) { }

    public override Point Next(Point p, Direction d)
    {
        Rectangle map = new Rectangle(0, 0, (SizeX - 1), (SizeY - 1));

        if (map.Contains(p.Next(d)))
        {
            return p.Next(d);
        }
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Rectangle map = new Rectangle(0, 0, (SizeX - 1), (SizeY - 1));

        if (map.Contains(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        return p;
    }
}
