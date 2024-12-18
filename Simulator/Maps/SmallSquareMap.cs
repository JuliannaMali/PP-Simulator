namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public readonly int Size;
    public SmallSquareMap(int size) : base(size, size)
    {
        FNext = MoveRules.WallNext;
        FNextDiagonal = MoveRules.WallNextDiagonal;
    }
}
