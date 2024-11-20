namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string arg)
    {
        List<Direction> dir = new();

        foreach(char element in arg)
        {
            string element1 = element.ToString().ToLower();
            
            if (element1 == "u")
            {
                dir.Add((Direction)0);
            }
            else if (element1 == "r")
            {
                dir.Add((Direction)1);
            }
            else if (element1 == "d")
            {
                dir.Add((Direction)2);
            }
            else if (element1 == "l")
            {;
                dir.Add((Direction)3);
            }
        }

        return dir;
    }

}
