using System.Drawing;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public readonly int Size;
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        FNext = MoveRules.TorusNext;
        FNextDiagonal = MoveRules.TorusNextDiagonal;
    }
}
