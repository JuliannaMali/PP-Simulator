namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public readonly int Size;
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        FNext = MoveRules.BounceNext;
        FNextDiagonal = MoveRules.BounceNextDiagonal;
    }
}
