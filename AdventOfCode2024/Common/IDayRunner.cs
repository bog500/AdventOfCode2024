using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Common
{
    public interface IDayRunner
    {
        public string Run();
        public IPartSolver GetSolver();
    }
}
