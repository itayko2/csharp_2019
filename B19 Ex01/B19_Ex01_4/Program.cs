using System;
namespace B19_Ex01_4
{
    public class Program
    {
        public static int m_ValidInputLength = 12;

        public static void Main()
        {
            StringAnalysis();
        }

        public static void StringAnalysis()
        {
            Console.WriteLine(string.Format("please enter an {{0}} characters string"), m_ValidInputLength);
            string inputtedString = Console.ReadLine();
            while (!IsValidNumber(inputtedString) && !IsValidString(inputtedString))
            {
                Console.WriteLine(string.Format("please enter a valid {{0}} characters string"), m_ValidInputLength);
                inputtedString = Console.ReadLine();
            }

            Console.WriteLine(IsPalindrome(inputtedString, true));

            if (IsValidNumber(inputtedString))
            {
                Console.WriteLine(IsDivisibleByThree(inputtedString));
            }
            else
            {
                Console.WriteLine("The number of lowercase letters is: " + NumberOfLowercase(inputtedString));
            }

            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }

        public static bool IsValidNumber(string inputToCheck)
        {
            bool validNumber = true;
            if (inputToCheck.Length == m_ValidInputLength)
            {
                for (int i = 0; i < m_ValidInputLength; i++)
                {
                    if (!char.IsDigit(inputToCheck[i]))
                    {
                        validNumber = false;
                    }
                }
            }
            else
            {
                validNumber = false;
            }

            return validNumber;
        }

        public static bool IsValidString(string inputToCheck)
        {
            bool validString = true;
            if (inputToCheck.Length == m_ValidInputLength)
            {
                for (int i = 0; i < m_ValidInputLength; i++)
                {
                    if (!char.IsLetter(inputToCheck[i]))
                    {
                        validString = false;
                    }
                }
            }
            else
            {
                validString = false;
            }

            return validString;
        }

        public static Boolean IsPalindrome(string i_InputToCheck, Boolean i_IsPalindrome)
        {
            if (i_InputToCheck.Length <= 1)
            {
                i_IsPalindrome = true;
            }
            else
            {
                if (i_InputToCheck[0] != i_InputToCheck[i_InputToCheck.Length - 1])
                {
                    i_IsPalindrome = false;
                }
                else
                {
                    i_IsPalindrome = IsPalindrome(i_InputToCheck.Substring(1, i_InputToCheck.Length - 2), i_IsPalindrome);
                }
            }

            return i_IsPalindrome;
        }

        public static string IsDivisibleByThree(string numberToCheck)
        {
            string divisibleOrNot = "Number is divisible by 3";
            int sumOfDigits = 0;

            for (int i = 0; i < m_ValidInputLength; i++)
            {
                sumOfDigits += (int)char.GetNumericValue(numberToCheck[i]);
            }

            if (sumOfDigits % 3 != 0)
            {
                divisibleOrNot = "number isn't divisible by 3";
            }

            return divisibleOrNot;
        }

        public static int NumberOfLowercase(string inputToCheck)
        {
            int lowercaseCount = 0;
            for (int i = 0; i < m_ValidInputLength; i++)
            {
                if (char.IsLower(inputToCheck[i]))
                {
                    lowercaseCount++;
                }
            }

            return lowercaseCount;
        }
    }
}