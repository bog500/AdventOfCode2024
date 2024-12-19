
using AdventOfCode2024.Common;
using System.Collections.Generic;

namespace AdventOfCode2024.Day19
{
    public abstract class Day19BaseSolver : IPartSolver
    {
        public HashSet<string> Patterns = [];
        public HashSet<string> Designs = [];

        public abstract string Solve(List<string> lines);

        public void Init(List<string> lines)
        {
            string[] pp = lines[0].Replace(" ", "").Split(',');

            Patterns = new(pp);
            Designs = new(lines.Skip(2));
        }

        public int CountPossibles()
        {
            int sum = 0;
            foreach(var d in Designs)
            {
                if (IsPossible(d))
                    sum++;
            }
            return sum;
        }

        public int CountPossibles2()
        {
            int sum = 0;
            return sum;
        }

        public bool IsPossible(string design)
        {
            return AddPattern(design, "");
        }

        public bool AddPattern(string design, string s)
        {
            foreach (string p in Patterns)
            {
                string s2 = s + p;

                if (s2 == design)
                {
                    return true;
                }


                if(design.StartsWith(s2))
                {
                    var sub = AddPattern(design, s2);
                    if (sub)
                        return true;
                }
                    
            }
            return false;
        }
    }
}
