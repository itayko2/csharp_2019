using System;
namespace B19_Ex01_1
{
    public class Program
    {
        public static int m_ValidNumberLength = 8;

        public static void Main()
        {
            BinarySeries();
        }

        public static void BinarySeries()
        {
            Console.WriteLine("Hello,{0}Please enter four 8 digits binary numbers.{0}Type your first number and press enter", Environment.NewLine);
            string firstBinaryNumber = Console.ReadLine();
            while (!IsValidInput(firstBinaryNumber))
            {
                Console.WriteLine("Please type a valid 8 digits binary number and press enter ");
                firstBinaryNumber = Console.ReadLine();
            }

            Console.WriteLine("Please type your second 8 digits binary number and press enter ");
            string secondBinaryNumber = Console.ReadLine();
            while (!IsValidInput(secondBinaryNumber))
            {
                Console.WriteLine("Please type a valid 8 digits binary number and press enter ");
                secondBinaryNumber = Console.ReadLine();
            }

            Console.WriteLine("Please type your third 8 digits binary number and press enter ");
            string thirdBinaryNumber = Console.ReadLine();
            while (!IsValidInput(thirdBinaryNumber))
            {
                Console.WriteLine("Please type a valid 8 digits binary number and press enter ");
                thirdBinaryNumber = Console.ReadLine();
            }

            Console.WriteLine("Please type your fourth 8 digits binary number and press enter ");
            string fourthBinaryNumber = Console.ReadLine();
            while (!IsValidInput(fourthBinaryNumber))
            {
                Console.WriteLine("Please type a valid 8 digits binary number and press enter ");
                fourthBinaryNumber = Console.ReadLine();
            }

            Console.WriteLine(firstBinaryNumber + "," + secondBinaryNumber + "," + thirdBinaryNumber + "," + fourthBinaryNumber);

            int firstBinaryNumToDec = BinaryConvertToDecimal(firstBinaryNumber);
            int secondBinaryNumToDec = BinaryConvertToDecimal(secondBinaryNumber);
            int thirdBinaryNumToDec = BinaryConvertToDecimal(thirdBinaryNumber);
            int fourthBinaryNumToDec = BinaryConvertToDecimal(fourthBinaryNumber);
            int amountOfPowerOfTwoNumbers = PowerOfTwoCounter(firstBinaryNumToDec, secondBinaryNumToDec, thirdBinaryNumToDec, fourthBinaryNumToDec);
            Console.WriteLine("The decimal values of the binary numbers are: " + firstBinaryNumToDec + "," + secondBinaryNumToDec + "," + thirdBinaryNumToDec + "," + fourthBinaryNumToDec);
            Console.WriteLine("There are " + amountOfPowerOfTwoNumbers + " numbers which are power of two");
            Console.WriteLine("The average of the numbers is: " + AverageOfFour(firstBinaryNumToDec, secondBinaryNumToDec, thirdBinaryNumToDec, fourthBinaryNumToDec));
            Console.WriteLine("The average number of zeros is: " + AverageZerosNumber(firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber, fourthBinaryNumber));
            Console.WriteLine("The average number of ones is: " + AverageOnesNumber(firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber, fourthBinaryNumber));
            Console.WriteLine(AreIncreasingSeries(firstBinaryNumToDec, secondBinaryNumToDec, thirdBinaryNumToDec, fourthBinaryNumToDec));
            Console.WriteLine("Press enter to continue.. ");
            Console.ReadLine();
        }

        public static bool IsValidInput(string i_NumberToCheck)
        {
            bool isValid = true;
            if (i_NumberToCheck.Length == m_ValidNumberLength)
            {
                for (int i = 0; i < m_ValidNumberLength; i++)
                {
                    if (i_NumberToCheck[i] != '0' && i_NumberToCheck[i] != '1')
                    {
                        isValid = false;
                    }
                }
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool IsPowerOfTwo(int i_NumberToCheck)
        {
            // Using bitwise operation ato find out and checking the number is not 0
            return (i_NumberToCheck != 0) && ((i_NumberToCheck & (i_NumberToCheck - 1)) == 0);
        }

        public static bool IsIncreasingSerieCheck(int i_NumberToCheck)
        {
            bool i_IncreasingSerie = true;
            string numberString = i_NumberToCheck.ToString();
            for (int i = 0; i < numberString.Length - 1; i++)
            {
                if (numberString[i] - '0' >= numberString[i + 1] - '0')
                {
                    i_IncreasingSerie = false;
                }
            }

            return i_IncreasingSerie;
        }

        public static string AreIncreasingSeries(int i_FirstDecimalNumber, int i_SecondDecimalNumber, int i_ThirdDecimalNumber, int i_FourthDecimalNumber)
        {
            int increasingSeriesCount = 0;
            string resultStringToOutput = string.Empty;
            System.Text.StringBuilder increasingSeriesNumbers = new System.Text.StringBuilder(string.Empty);
            if (IsIncreasingSerieCheck(i_FirstDecimalNumber))
            {
                increasingSeriesCount++;
                increasingSeriesNumbers.Append("(" + i_FirstDecimalNumber + ") ");
            }

            if (IsIncreasingSerieCheck(i_SecondDecimalNumber))
            {
                increasingSeriesCount++;
                increasingSeriesNumbers.Append("(" + i_SecondDecimalNumber + ") ");
            }

            if (IsIncreasingSerieCheck(i_ThirdDecimalNumber))
            {
                increasingSeriesCount++;
                increasingSeriesNumbers.Append("(" + i_ThirdDecimalNumber + ") ");
            }

            if (IsIncreasingSerieCheck(i_FourthDecimalNumber))
            {
                increasingSeriesCount++;
                increasingSeriesNumbers.Append("(" + i_FourthDecimalNumber + ") ");
            }

            if (increasingSeriesCount == 0)
            {
                resultStringToOutput = "None of the numbers represents a increasing serie";
            }

            if (increasingSeriesCount == 1)
            {
                resultStringToOutput = "only one number represents a increasing serie:" + increasingSeriesNumbers;
            }

            if (increasingSeriesCount > 1)
            {
                resultStringToOutput = "there are " + increasingSeriesCount + " numbers that represent a increasing series: " + increasingSeriesNumbers;
            }

            return resultStringToOutput;
        }

        public static double AverageOfFour(int i_FirstNum, int i_SecondNum, int i_ThirdNum, int i_FourthNum)
        {
            return (i_FirstNum + i_SecondNum + i_ThirdNum + i_FourthNum) / 4.0;
        }

        public static int PowerOfTwoCounter(int i_FirstNum, int i_SecondNum, int i_ThirdNum, int i_FourthNum)
        {
            int count = 0;
            if (IsPowerOfTwo(i_FirstNum))
            {
                count++;
            }

            if (IsPowerOfTwo(i_SecondNum))
            {
                count++;
            }

            if (IsPowerOfTwo(i_ThirdNum))
            {
                count++;
            }

            if (IsPowerOfTwo(i_FourthNum))
            {
                count++;
            }

            return count;
        }

        public static int BinaryConvertToDecimal(string i_BinaryNumber)
        {
            double decimalValueOfBinaryNumber = 0;
            for (int i = m_ValidNumberLength - 1; i >= 0; i--)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    decimalValueOfBinaryNumber += Math.Pow(2, m_ValidNumberLength - 1 - i);
                }
            }

            return (int)decimalValueOfBinaryNumber;
        }

        public static float AverageZerosNumber(string i_FirstBinaryNumber, string i_SecondBinaryNumber, string i_ThirdBinaryNumber, string i_FourthBinaryNumber)
        {
            float zerosInNumbers = 0;
            for (int i = m_ValidNumberLength - 1; i >= 0; i--)
            {
                if (i_FirstBinaryNumber[i] == '0')
                {
                    zerosInNumbers++;
                }

                if (i_SecondBinaryNumber[i] == '0')
                {
                    zerosInNumbers++;
                }

                if (i_ThirdBinaryNumber[i] == '0')
                {
                    zerosInNumbers++;
                }

                if (i_FourthBinaryNumber[i] == '0')
                {
                    zerosInNumbers++;
                }
            }

            return zerosInNumbers / 4;
        }

        public static float AverageOnesNumber(string i_FirstBinaryNumber, string i_SecondBinaryNumber, string i_ThirdBinaryNumber, string i_FourthBinaryNumber)
        {
            float onesInNumbers = 0;
            for (int i = m_ValidNumberLength - 1; i >= 0; i--)
            {
                if (i_FirstBinaryNumber[i] == '1')
                {
                    onesInNumbers++;
                }

                if (i_SecondBinaryNumber[i] == '1')
                {
                    onesInNumbers++;
                }

                if (i_ThirdBinaryNumber[i] == '1')
                {
                    onesInNumbers++;
                }

                if (i_FourthBinaryNumber[i] == '1')
                {
                    onesInNumbers++;
                }
            }

            return onesInNumbers / 4;
        }
    }
}
