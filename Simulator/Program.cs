namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5a();
        Lab5b();
         
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

    static void Lab5b()
    {
        Console.Write("Czy mapa ma dobre rozmiary? \nm1(3); m2(6); m3(18); m4(22); m5(20) \nOczekiwany wynik: Błąd, 6, 18, Błąd, 20\nWynik:\n");
        int[] mapyrozmiar = [3, 6, 18, 22, 20];
        foreach(int i in mapyrozmiar)
        {
            try
            {
                Maps.SmallSquareMap m = new(i);
                Console.WriteLine(m.Size);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.Write("\nTest dla Exist. \nMapa(6). p1(1,3); p2(0, 4); p3(7,2); p4(5,18), p5(-1,3)\nOczekiwany wynik: true, true, false, false, false\nWynik:\n");
        Maps.SmallSquareMap mapatest = new(6);
        Point[] punktyexisttest = [new(1, 3), new(0, 4), new(7, 2), new(5, 18), new(-1,3)];
        foreach(Point p in punktyexisttest)
        {
            Console.WriteLine($"\n{mapatest.Exist(p)}");
        }

        Console.Write("\nNext Test\nMapa(6). p1(1,3)-left; p2(0, 5)-up; p3(5, 3)-right; p4(4,4)-down\nOczekiwany wynik (0,3); (0,5); (5,3); (4,3)\nWyniki:");

        Point p1 = new(1, 3);
        Point p2 = new(0, 5);
        Point p3 = new(5, 3);
        Point p4 = new(4, 4);
        Console.WriteLine($"\n{mapatest.Next(p1, Direction.Left)}");
        Console.WriteLine($"\n{mapatest.Next(p2, Direction.Up)}");
        Console.WriteLine($"\n{mapatest.Next(p3, Direction.Right)}");
        Console.WriteLine($"\n{mapatest.Next(p4, Direction.Down)}");

        Console.Write("\nNextDiagonal Test\nPkt jak wyżej.\nOczekiwany wynik: (0,4); (0,5); (5,3); (3,3)\nWyniki:");
        Console.WriteLine($"\n{mapatest.NextDiagonal(p1, Direction.Left)}");
        Console.WriteLine($"\n{mapatest.NextDiagonal(p2, Direction.Up)}");
        Console.WriteLine($"\n{mapatest.NextDiagonal(p3, Direction.Right)}");
        Console.WriteLine($"\n{mapatest.NextDiagonal(p4, Direction.Down)}");
    }


}
