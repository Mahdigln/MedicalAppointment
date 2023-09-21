namespace Core.Generator;

public static class NumberGenerator
{
    public static string RandomNumber()
    {
        var generator = new Random();

        var result = generator.Next(0, 100000).ToString("D5");

        return result;
    }

}