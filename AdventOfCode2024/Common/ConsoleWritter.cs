using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Common
{
    public static class ConsoleWritter
    {
        public static bool Disabled = false;
        public static void Answer(DemoEnum realdemo, object answer)
        {
            if(!Disabled)
            {
                ConsoleWritter.Write(realdemo.ToString() + ":   ", ConsoleColor.Cyan);
                ConsoleWritter.Write(answer, ConsoleColor.Green);
            }
        }

        public static void WriteLine(object msg, ConsoleColor color = ConsoleColor.Gray)
        {
            if (!Disabled)
            {
                Write(msg, color);
                Console.WriteLine("");
            }
        }

        public static void Write(object msg, ConsoleColor color = ConsoleColor.Gray)
        {
            if (!Disabled)
            { 
                ConsoleColor oldColor = Console.ForegroundColor;

                Console.ForegroundColor = color;
                Console.Write(msg);

                Console.ForegroundColor = oldColor;
            }
        }
    }
}
