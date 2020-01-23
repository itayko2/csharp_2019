using System;
namespace B19_Ex01_5
{
    public class Program
    {
        public static int m_ValidInputLength = 8;
        public static int m_NumberValue;

        public static void Main()
        {
            NumberStatitics();
        }

        public static void NumberStatitics()
        {
            Console.WriteLine("Please enter a 8 digit integer:");
            string inputtedNumber = Console.ReadLine();
            while (!IsValidInput(inputtedNumber))
            {
                Console.WriteLine("Please enter a valid 8 digit integer:");
                inputtedNumber = Console.ReadLine();
            }

            Console.WriteLine("Largest digit in the number is: " + LargestDigit(inputtedNumber));
            Console.WriteLine("Smallest digit in the number is: " + SmallestDigit(inputtedNumber));
            Console.WriteLine("Number of divisible by 3 digits: " + HowManyDivisibleByThreeNumbers(inputtedNumber));
            Console.WriteLine("Number of digits bigger than the ones digit: " + HowManyBiggerThanOnes(inputtedNumber));
            Console.WriteLine("Please press enter to continue..");
            Console.ReadLine();
        }

        public static bool IsValidInput(string i_NumberToCheck)
        {
            return ((i_NumberToCheck.Length == m_ValidInputLength) && (int.TryParse(i_NumberToCheck, out m_NumberValue)));
        }

        public static int LargestDigit(string i_NumberToCheck)
        {
            int largest = 0;
            int currentDigit = 0;
            for (int i = 0; i < m_ValidInputLength; i++)
            {
                currentDigit = (int)char.GetNumericValue(i_NumberToCheck[i]);
                if (currentDigit > largest)
                {
                    largest = currentDigit;
                }
            }

            return largest;
        }

        public static int SmallestDigit(string i_NumberToCheck)
        {
            int smallest = 9;
            int currentDigit = 0;
            for (int i = 0; i < m_ValidInputLength; i++)
            {
                currentDigit = (int)char.GetNumericValue(i_NumberToCheck[i]);
                if (currentDigit < smallest)
                {
                    smallest = currentDigit;
                }
            }

            return smallest;
        }

        public static int HowManyDivisibleByThreeNumbers(string i_NumberToCheck)
        {
            int dividedByThreeCount = 0;
            int currentDigit = 0;
            for (int i = 0; i < m_ValidInputLength; i++)
            {
                currentDigit = (int)char.GetNumericValue(i_NumberToCheck[i]);
                if (currentDigit % 3 == 0)
                {
                    dividedByThreeCount++;
                }
            }

            return dividedByThreeCount;
        }

        public static int HowManyBiggerThanOnes(string i_NumberToCheck)
        {
            int onesDigit = (int)char.GetNumericValue(i_NumberToCheck[m_ValidInputLength - 1]);
            int currentDigit = 0;
            int biggerThanOnes = 0;
            for (int i = 0; i < m_ValidInputLength - 1; i++)
            {
                currentDigit = (int)char.GetNumericValue(i_NumberToCheck[i]);
                if (currentDigit > onesDigit)
                {
                    biggerThanOnes++;
                }
            }

            return biggerThanOnes;
        }
    }
}

