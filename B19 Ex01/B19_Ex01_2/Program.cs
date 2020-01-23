using System;
using System.Text;

namespace B19_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            HourGlassForBeginners();
        }

        public static void HourGlassForBeginners()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int height = 5;
            Console.WriteLine(HourGlassBuilder(stringBuilder, 0, height));
        }

        public static StringBuilder HourGlassBuilder(StringBuilder i_StringBuilder, int i_Row, int i_Height)
        {
            if (i_Height % 2 == 0)
            {
                i_Height++;
            }

            if (i_Row < i_Height / 2)
            {
                i_StringBuilder.AppendLine(new string(' ', i_Row) + new string('*', i_Height - (2 * i_Row)));
                HourGlassBuilder(i_StringBuilder, i_Row + 1, i_Height);
            }

            else if (i_Row != i_Height)
            {
                i_StringBuilder.AppendLine(new string(' ', i_Height - i_Row - 1) + new string('*', (2 * i_Row) - i_Height + 2));
                HourGlassBuilder(i_StringBuilder, i_Row + 1, i_Height);
            }

            return i_StringBuilder;

        }
    }
}
