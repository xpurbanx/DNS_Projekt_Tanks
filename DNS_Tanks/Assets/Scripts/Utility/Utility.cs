using System;

public class Utility
{
    public static int ParseToInt(string input)
    {
        int output = -1;

        try
        {
            output = Int32.Parse(input);
        }

        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{input}'");
        }

        return output;
    }
}
