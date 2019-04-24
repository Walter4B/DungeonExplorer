using System;

public static class RandomNumberGenerator
{
    private static Random rnd = new Random();

    public static int GetRandom(int max)
    {
        return rnd.Next(max);
    }
}
