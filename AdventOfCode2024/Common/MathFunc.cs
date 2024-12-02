namespace AdventOfCode2024.Common
{
    // Reference: https://stackoverflow.com/questions/13569810/least-common-multiple
    public static class MathFunc
    {
        public static long LeastCommonMultiple(IEnumerable<long> numbers)
        {
            long multiple = 1;
            foreach(long n in numbers)
            {
                multiple = LeastCommonMultiple(multiple, n);
            }
            return multiple;
        }

        private static long LeastCommonMultiple(long a, long b)
        {
            return (a / GreatestCommonFactor(a, b)) * b;
        }

       
        public static long GreatestCommonFactor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
