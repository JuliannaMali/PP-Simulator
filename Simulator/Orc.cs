﻿using Simulator.Maps;

namespace Simulator;

public class Orc : Creature
{
    private int rage;
    public int Rage
    {
        get => rage;

        init
        {
            rage = Validator.LimiterEO(value, 0, 10);

        }
    }

    public override char Symbol { get; } = 'O';


    private int counter = 0;
    public void Hunt()
    {
        
        counter++;
        if (counter == 2)
        {
            if (rage == 10)
            {
                rage = 10;
                counter = 0;
            }
            else
            {
                rage++;
                counter = 0;
            }
        }
    }

    public Orc() : base () { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override string Greeting() => 
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

    public override int Power
    {
        get { return (Level * 7 + 3 * Rage); }
    }

    public override string Info
    {
        get { return $"{Name} [{Level}] [{Rage}]"; }
    }
} 
