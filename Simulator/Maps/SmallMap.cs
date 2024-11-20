﻿namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX < 5 || sizeX>20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }

        if (sizeY < 5 || sizeY>20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall");
        }
    }
}