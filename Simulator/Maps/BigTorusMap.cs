using System.Drawing;

namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public readonly int Size;
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        FNext = MoveRules.TorusNext;
        FNextDiagonal = MoveRules.TorusNextDiagonal;
    }
}

