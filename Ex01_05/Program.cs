using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_05
{
    class Program
    {
        static void Main()
        {
            string inputNumAsStr = readNum();
            int minDigit = findMinDigit(inputNumAsStr);
            double avgOfDigits = findAvgOfDigits(inputNumAsStr);
            int amountOfDigitsDevideBy2 = findAmountOfDigitsDivideBy2(inputNumAsStr);
            int amountOfDigitsLowerThenOnesDigit = findAmountOfDigitsLowerThenOnesDigit(inputNumAsStr);

            printResults(minDigit, avgOfDigits, amountOfDigitsDevideBy2, amountOfDigitsLowerThenOnesDigit);
        }

        private static void printResults(
            int i_MinDigit,
            double i_AvgOfDigits,
            int i_AmountOfDigitsDevideBy2,
            int i_AmountOfDigitsLowerThenOnesDigits)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Minimum digit: ").Append(i_MinDigit).AppendLine();
            stringBuilder.Append("Average of digits: ").Append(i_AvgOfDigits).AppendLine();
            stringBuilder.Append("Amount of digits that devide by 2: ").Append(i_AmountOfDigitsDevideBy2).AppendLine();
            stringBuilder.Append("Amount of digits that lower then the ones digit: ").Append(i_AmountOfDigitsLowerThenOnesDigits).AppendLine();
            Console.WriteLine(stringBuilder);
        }

        private static int findAmountOfDigitsLowerThenOnesDigit(string i_InputNumAsStr)
        {
            int amountOfDigitsLowerThenOnesDigit = 0;

            for(int i = 0; i < 6; i++)
            {
                int currDigitAsInt = i_InputNumAsStr[i] - '0';

                if(currDigitAsInt < i_InputNumAsStr[6])
                {
                    amountOfDigitsLowerThenOnesDigit++;
                }
            }

            return amountOfDigitsLowerThenOnesDigit;
        }


        private static int findAmountOfDigitsDivideBy2(string i_InputNumAsStr)
        {
            int amountOfDigitsDevideBy2 = 0;

            for(int i = 0; i < 7; i++)
            {
                int currDigitAsInt = i_InputNumAsStr[0] - '0';

                if(currDigitAsInt % 2 == 0)
                {
                    amountOfDigitsDevideBy2++;
                }
            }

            return amountOfDigitsDevideBy2;
        }
        private static double findAvgOfDigits(string i_InputNumAsStr)
        {
            double sumOfDigits = 0;

            for(int i = 0; i < 7; i++)
            {
                sumOfDigits += i_InputNumAsStr[i] - '0';
            }

            sumOfDigits /= 7;

            return sumOfDigits;
        }
        private static int findMinDigit(string i_InputNumAsStr)
        {
            int currMinDigit = i_InputNumAsStr[0] - '0';

            for (int i = 1; i < 7; i++)
            {
                if(i_InputNumAsStr[i] - '0' < currMinDigit)
                {
                    currMinDigit = i_InputNumAsStr[i] - '0';
                }
            }

            return currMinDigit;
        }

        private static string readNum()
        {
            bool inputIsValid = false;
            string inputNumAsStr = string.Empty;

            Console.WriteLine("Please enter 7 digits number: ");
            while (!inputIsValid)
            {
                inputNumAsStr = Console.ReadLine();
                if (checkIfInputIsValid(inputNumAsStr))
                {
                    inputIsValid = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input, please enter again the number: ");
                }
            }

            return inputNumAsStr;
        }

        private static bool checkIfInputIsValid(string i_Input)
        {
            bool lengthIs7 = i_Input.Length == 7;
            bool isNum = checkIfAllCharsInStrIsNums(i_Input);
            bool isValid = lengthIs7 && isNum;

            return isValid;
        }

        private static bool checkIfAllCharsInStrIsNums(string i_str)
        {
            bool isAllNums = true;

            for(int i = 0; i < i_str.Length; i++)
            {
                if(!char.IsDigit(i_str[i]))
                {
                    isAllNums = false;
                    break;
                }
            }

            return isAllNums;
        }
    }
}
