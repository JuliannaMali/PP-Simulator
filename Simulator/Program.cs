﻿namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5a();
    }

    static void Lab5a()
    {
        Console.Write("Dwa poprawne prostokąty, r1[(1,2), (3,4)], r2[(0,0), (6,6)] \nOczekiwany wynik: r1 (1,2) : (3,4); r2 (0,0), (6,6) \nWynik: \n");
        Rectangle r1 = new(1, 2, 3, 4);
        Console.WriteLine(r1);
        Rectangle r2 = new(0, 0, 6, 6);
        Console.WriteLine(r2);

        Console.Write("\nKonstruktor z pointem, r3[(1,1), (2,2) \nOczekiwany wynik: (1,1) : (2,2)] \nWynik: \n");
        Point p01 = new(1, 1);
        Point p02 = new(2, 2);
        Rectangle r3 = new(p01, p02);
        Console.WriteLine(r3);

        Console.Write("\nZamienione współrzędne, r4[(4,7), (0,3)] \nOczekiwany wynik: (0,3) : (4,7) \nWynik: \n");
        Rectangle r4 = new(4, 7, 0, 3);
        Console.WriteLine(r4);

        Console.Write("\nWspółliniowe współrzędne, r5[(1,3), (1,6)]\nOczekiwany wynik: Błąd\n");
        try
        {
            Rectangle r5 = new(1, 3, 1, 6);
            Console.WriteLine(r5);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.Write("\nZawieranie w r2, p1(1,2), p2(3,5), p3(7,2), p4(1,8), p5(4,4)\nOczekiwany wynik: True, True, False, False, True");
        Point[] punkty =
            [
            new (1,2), new(3,5), new(7,2), new(1,8), new(4,4)
            ];
        foreach (Point i in punkty)
        {
            Console.WriteLine($"\n{r2.Contains(i)}");
        }

    }
}
