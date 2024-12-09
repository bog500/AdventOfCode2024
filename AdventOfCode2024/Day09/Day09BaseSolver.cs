
using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2024.Day09
{
    public abstract class Day09BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        public string Expand(string str)
        {
            StringBuilder sb = new(); 

            int id = 0;
            bool isData = true;
            int index = 0;
            foreach(char c in str)
            {
                int num = Parser.CharToInt(c);
                for(int i = 0; i < num; i++)
                {
                    if (isData)
                    {
                        idOriginal[sb.Length] = id;
                        sb.Append(id % 10);
                    }
                    else
                        sb.Append('.');
                }
                if(isData)
                {
                    id++;
                }

                index++;
                isData = !isData;
            }

            string result = sb.ToString();
            return result;
        }


        Dictionary<int, int> idOriginal = [];
        Dictionary<int, int> idMoved = [];

        public string Compact(string str)
        {
            char[] ch = str.ToCharArray();

            int minJ = 0;

            for (int index = str.Length - 1; index > 0; index--)
            {
                char c = ch[index];
                if (c == '.')
                    continue;

                
                ch[index] = '.';

                for(int j = minJ; j < str.Length; j++)
                {
                    if (ch[j] == '.')
                    {

                        if(!idMoved.TryGetValue(index, out int id))
                        {
                            idOriginal.TryGetValue(index, out id);
                        }

                        idMoved[j] = id;

                        ch[j] = c;
                        minJ = j-1;
                        j = int.MaxValue-1; // exit for loop
                    }
                }
            }

            string str2 = new string(ch);
            return str2;
        }


        public long CheckSum2(string str)
        {
            int index = 0;
            long sum = 0;
            foreach (char c in str)
            {
                if (c == '.')
                    break;

                if(!idMoved.TryGetValue(index, out int id))
                {
                    id = idOriginal[index];
                }

                sum += index * id;

                index++;
            }
            return sum;
        }

        public long CheckSum(string str)
        {
            long index = 0;
            long sum = 0;
            foreach(char c in str)
            {
                if (c == '.')
                    break;

                int num = Parser.CharToInt(c);
                long partial = index * num;
                sum += partial;

                index++;
            }
            return sum;
        }
    }
}
