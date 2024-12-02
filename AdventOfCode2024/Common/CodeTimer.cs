using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Common
{
    internal class CodeTimer : IDisposable
    {
        Stopwatch sw = new();
        public CodeTimer()
        {
            sw.Start();
        }

        public void Dispose()
        {
            sw.Stop();

            ConsoleWritter.WriteLine("    " + sw.ElapsedMilliseconds + "ms", ConsoleColor.DarkBlue);
            
        }
    }
}
