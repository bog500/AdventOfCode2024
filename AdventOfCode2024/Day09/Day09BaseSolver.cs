
using AdventOfCode2024.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AdventOfCode2024.Day09
{
    public abstract class Day09BaseSolver : IPartSolver
    {
        private const int EMPTY = -1;

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
                        ids[sb.Length] = id;
                        sb.Append(id % 10);
                    }
                    else
                    {
                        ids[sb.Length] = EMPTY;
                        sb.Append('.');
                    }
                        
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


        Dictionary<int, int> ids = []; // index -> id
        HashSet<int> movedIds = []; // already moved ids

        public long CheckSum(string str)
        {
            int index = 0;
            long sum = 0;
            foreach (char c in str)
            {
                int id = ids[index];

                if(id > 0)
                    sum += index * id;

                index++;

            }

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

                        int id = ids[index];

                        ids[index] = EMPTY;
                        ids[j] = id;

                        ch[j] = c;
                        minJ = j - 1;
                        j = int.MaxValue - 1; // exit for loop
                    }
                }
            }

            string str2 = new string(ch);
            return str2;
        }

        public bool IsEmpty(int index)
        {
            return ids[index] == EMPTY;
        }

        public bool IsEmpty(int index, int length)
        {
            for(int i = 0; i < length; i++)
            {
                if (!IsEmpty(index + i))
                    return false;
            }
            return true;
        }

        public int Findspot(int maxIndex, int length)
        {
            // find spot
            for (int spotStart = 0; spotStart < maxIndex; spotStart++)
            {
                if (IsEmpty(spotStart, length))
                {
                    return spotStart;
                }
            }
            return EMPTY;
        }

        public string CompactFullBlocks(string str)
        {
            char[] ch = str.ToCharArray();

            for (int indexEnd = str.Length - 1; indexEnd > 0; indexEnd--)
            {
                int id = ids[indexEnd];

                if (id == EMPTY)
                    continue;

                if (movedIds.Contains(id))
                    continue;

                // find start of block
                var blocks = ids.Where(o => o.Value == id);
                int blockLength = blocks.Count();
                int indexStart = blocks.Select(o => o.Key).Min();

                int spotStart = Findspot(indexStart, blockLength);

                if (spotStart == EMPTY)
                {
                    indexEnd = indexEnd - blockLength + 1;
                    continue; // no spot
                }

                movedIds.Add(id);
                
                for (int i = 0; i < blockLength; i++)
                {
                    // remove original block
                    ids[indexStart + i] = EMPTY;

                    // move new id
                    ids[spotStart + i] = id;
                }

                indexEnd = indexEnd - blockLength + 1;
            }

            string str2 = new string(ch);
            return str2;
        }

    }
}
