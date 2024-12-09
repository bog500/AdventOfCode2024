
using AdventOfCode2024.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
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


        Dictionary<int, int> idOriginal = []; // index -> id
        Dictionary<int, int> idMoved = []; // index -> id
        HashSet<int> movedIds = []; // already moved ids

        public int GetId(int index)
        {
            if (!idMoved.TryGetValue(index, out int id))
            {
                id = idOriginal[index];
            }
            return id;
        }

        public long CheckSum(string str)
        {
            int index = -1;
            long sum = 0;
            foreach (char c in str)
            {
                index++;

                if (c == '.')
                    continue;

                int id = GetId(index);

                sum += index * id;

            }

            // bad:
            // 7023831612552 (too big)
            // 7022283591665 (too big)

            return sum;
        }

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

                for (int j = minJ; j < str.Length; j++)
                {
                    if (ch[j] == '.')
                    {

                        if (!idMoved.TryGetValue(index, out int id))
                        {
                            idOriginal.TryGetValue(index, out id);
                        }

                        idMoved[j] = id;

                        ch[j] = c;
                        minJ = j - 1;
                        j = int.MaxValue - 1; // exit for loop
                    }
                }
            }

            string str2 = new string(ch);
            return str2;
        }


        public string CompactFullBlocks(string str)
        {
            char[] ch = str.ToCharArray();

            for (int indexEnd = str.Length - 1; indexEnd > 0; indexEnd--)
            {
                char c = ch[indexEnd];
                if (c == '.')
                    continue;

                int id = GetId(indexEnd);

                if (movedIds.Contains(id))
                    continue;

                // find start of block
                int indexStart = indexEnd;
                while (indexStart >= 0 && ch[indexStart] == c)
                {
                    char c2 = ch[indexStart];
                    indexStart--;
                }
                indexStart++; // cancel last indexStart--

                if (indexStart < 0)
                    continue;

                int blockLength = indexEnd - indexStart + 1;

                // find spot
                int spotStart = -1;
                for(int i = 0; i < indexStart; i++)
                {
                    if(ch[i..(i + blockLength)].All(o => o == '.'))
                    {
                        // spot found
                        spotStart = i;
                        break;
                    }
                    i += 1;
                }

                if (spotStart < 0)
                {
                    indexEnd = indexEnd - blockLength + 1;
                    continue; // no spot
                }

                movedIds.Add(id);

                //Console.WriteLine(new string(ch));


                // remove original block
                for (int i = indexStart; i <= indexEnd; i++)
                {
                    ch[i] = '.';
                    idOriginal[i] = 0;
                }

                //Console.WriteLine(new string(ch));

                for (int j = spotStart; j < spotStart + blockLength; j++)
                {
                    idMoved[j] = id;
                    ch[j] = c;
                }

                //Console.WriteLine(new string(ch));


                indexEnd = indexEnd - blockLength + 1;
            }

            string str2 = new string(ch);
            return str2;
        }

    }
}
