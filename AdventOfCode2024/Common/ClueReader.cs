using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Common
{
    public class ClueReader(DayEnum day)
    {
        public List<string> Read(FileEnum file)
        {
            List<string> lines = new List<string>();

            string filepath = Path.Combine(day.ToString(), "Files", Filename(file));

            using (StreamReader sr = new StreamReader(filepath))
            {
                //Read the first line of text
                string? line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    lines.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            return lines;
        }

        private string Filename(FileEnum file) => file.ToString() + ".txt";
    }
}
