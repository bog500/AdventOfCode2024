using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day07
{

    public class Day07Part1Solver : Day07BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            long sum = 0;
            List<Equation> eqs = Parse(lines);

            foreach(var eq in eqs)
            {
                if (IsPossible(eq, [new(eq.Numbers[0], '=')]))
                {
                    eq.IsPossible = true;
                    sum += eq.Total;
                }
                    
            }

            return sum + "";
        }

        private bool IsPossible(Equation eq, List<NumberOperator> operations)
        {
            if(eq.Numbers.Count == operations.Count)
            {
                return DoMath(operations) == eq.Total;
            }

           if (DoMath(operations) > eq.Total)
                return false;

            foreach (char op in DefaultOperators)
            {
                List<NumberOperator> newOperations = new(operations);
                newOperations.Add(new(eq.Numbers[operations.Count], op));
                bool possible = IsPossible(eq, newOperations);
                if (possible)
                    return true;
            }
            return false;
        }

        List<char> DefaultOperators = new(['|','*', '+']);

        // 3267: 81 40 27

        public long DoMath(List<NumberOperator> operations)
        {
            long total = operations[0].Number;
            foreach(var o in operations[1..])
            {
                total = DoMath(total, o.Op, o.Number);
            }
            return total;
        }

        public long DoMath(long currentTotal, char op, long number)
        {
            if (op == '*')
                return currentTotal * number;

            if (op == '+')
                return currentTotal + number;

            if (op == '|')
                return long.Parse(currentTotal + "" + number);

            if (op == '=')
                return number;

            throw new NotImplementedException();

        }

        protected List<Equation> Parse(List<string> lines)
        {
            List<Equation> list = [];
            foreach(string line in lines)
            {
                Equation eq = new();
                eq.Total = long.Parse(line.Split(':')[0]);

                eq.Numbers = Parser.ParseLong(line.Split(':')[1]);
                list.Add(eq);
            }

            return list;
        }

    }



    public record NumberOperator(long Number, char Op);

    public class Equation
    {
        public long Total { get; set; }

        public List<long> Numbers { get; set; } = new();

        public bool IsPossible { get; set; } = false;
    }
}
