namespace AdventOfCode2024.Common;

public static class CharExtensions
{
    public static bool IsNumber(this char c) => c >= '0' && c <= '9';

    public static bool IsLowerLetter(this char c) => c >= 'a' && c <= 'z';

    public static bool IsCapitalLetter(this char c) => c >= 'A' && c <= 'Z';

    public static bool IsLetter(this char c) => c.IsLowerLetter() || c.IsCapitalLetter();
}

