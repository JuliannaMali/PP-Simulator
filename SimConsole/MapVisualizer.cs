using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

public class MapVisualizer
{
    private Map Mapa;
    public MapVisualizer(Map mapa) 
    {
        Mapa = mapa;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int kolumny = Mapa.SizeX-1;
        int wiersze = Mapa.SizeY-1;

        //góra
        Console.Write($"{Box.TopLeft}{Box.Horizontal}");
        for (int i=0; i<kolumny; i++)
        {
            Console.Write($"{Box.TopMid}{Box.Horizontal}");
        }
        Console.Write($"{Box.TopRight}");

        //środek
        for(int i = wiersze; i>=0; i--)
        {
            Console.Write($"\n{Box.Vertical}");
            for(int j = 0; j<kolumny+1; j++)
            {
                var c = Mapa.At(j, i);

                if (c != null && c.Count != 0)
                {
                    switch (c.Count)
                    {
                        case 1:
                            Console.Write($"{c[0].Symbol}{Box.Vertical}");
                            break;
                        case > 1:
                            Console.Write($"X{Box.Vertical}");
                            break;
                    }
                }
                else
                {
                    Console.Write(' ');
                    Console.Write(Box.Vertical);
                }
            }

            if (i > 0)
            {
                Console.Write($"\n{Box.MidLeft}{Box.Horizontal}");
                var middle = $"{Box.Cross}{Box.Horizontal}";
                for (int x = 0; x < kolumny - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.Cross}{Box.Horizontal}{Box.MidRight}");
            }
            else
            {
                Console.Write($"\n{Box.BottomLeft}{Box.Horizontal}");
                var middle = $"{Box.BottomMid}{Box.Horizontal}";
                for (int x = 0; x < kolumny - 1; x++)
                {
                    Console.Write(middle);
                }
                Console.Write($"{Box.BottomMid}{Box.Horizontal}{Box.BottomRight}\n");
            }
        }
    }


}
