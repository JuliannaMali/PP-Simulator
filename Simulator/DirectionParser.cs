namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string arg)
    {
        List<Direction> dir = new();

        foreach(char element in arg)
        {
            string element1 = element.ToString().ToLower();
            
            switch (element1)
            {
                case "u":
                    {
                        dir.Add((Direction)0);
                        break;
                    }
                case "r":
                    {
                        dir.Add((Direction)1);
                        break;
                    }
                case "d":
                    {
                        dir.Add((Direction)2);
                        break;
                    }
                case "l":
                    {
                        dir.Add((Direction)3);
                        break;
                    }
            }
        }
        return dir;
    }

}
