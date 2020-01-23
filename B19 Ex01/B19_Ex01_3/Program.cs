using System;
using System.Text;

namespace B19_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            HourGlassForExperts();
        }

        public static void HourGlassForExperts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("Type a number of hour glass rows to print");
            int hourGlassRows = 0;
            bool validInput = int.TryParse(Console.ReadLine(), out hourGlassRows);
            while (!validInput)
            {
                Console.WriteLine("Please enter a valid input");
                validInput = int.TryParse(Console.ReadLine(), out hourGlassRows);
            }

            Console.WriteLine(B19_Ex01_2.Program.HourGlassBuilder(stringBuilder, 0, hourGlassRows));
            Console.WriteLine("Press enter to continue.. ");
            Console.ReadLine();
        }
    }
}
