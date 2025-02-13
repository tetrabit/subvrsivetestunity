using System;

public class RandomUtil
{
    private static readonly Lazy<RandomUtil> lazyInstance =
        new Lazy<RandomUtil>(() => new RandomUtil());

    public static RandomUtil Instance => lazyInstance.Value;

    private readonly Random random;

    private RandomUtil()
    {
        random = new Random();
    }

    private RandomUtil(int seed)
    {
        random = new Random(seed);
    }

    public int Next()
    {
        return random.Next();
    }

    public int Next(int maxValue)
    {
        return random.Next(maxValue);
    }

    public int Next(int minValue, int maxValue)
    {
        return random.Next(minValue, maxValue);
    }
}