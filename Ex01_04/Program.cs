using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ex01_01;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            string inputStr;
            int amountOfSmallLetters;

            inputStr = readString();

            if (Ex01_01.Program.CheckIfStrIsPalindrom(inputStr))
            {
                Console.WriteLine("The string is palindrom.");
            }
            else
            {
                Console.WriteLine("The string is not palindrom.");
            }

            if(checkIfStrIsNum(inputStr))
            {
                if (checkIfDevideBy3(inputStr))
                {
                    Console.WriteLine("The number is devided by 3.");
                }
                else
                {
                    Console.WriteLine("The number is not devided by 3.");
                }
            }

            if(checkIfStringContainsOnlyEnglishLetters(inputStr))
            {
                amountOfSmallLetters = calAmountOfLowercaseLetters(inputStr);
                Console.WriteLine("The amount of small letters in the string: " + amountOfSmallLetters);
            }
        }

        private static string readString()
        {
            bool strIsValid = false;
            string inputStr = "";

            Console.WriteLine("Please enter 8 digit string: ");
            while (!strIsValid)
            {
                inputStr = Console.ReadLine();
                if (checkIfInputStringIsValid(inputStr))
                {
                    strIsValid = true;
                }
                else
                {
                    Console.WriteLine("Incorrect input, please enter again the string: ");
                }
            }

            return inputStr;
        }

        private static bool checkIfInputStringIsValid(string i_InputStr)
        {
            bool isLength8 = (i_InputStr.Length == 8);
            bool isOnlyEnglishLetters = checkIfStringContainsOnlyEnglishLetters(i_InputStr);
            bool isOnlyDigits = checkIfStringContainsOnlyDigits(i_InputStr);
            bool inputStringIsValid = isLength8 && (isOnlyDigits || isOnlyEnglishLetters);

            return inputStringIsValid;
        }

        private static bool checkIfStringContainsOnlyEnglishLetters(string i_InputStr)
        {
            bool isStringContainsOnlyEnglishLetters = true;

            for (int i = 0; i < i_InputStr.Length; i++)
            {
                if ((i_InputStr[i] < 'A') || ((i_InputStr[i] > 'Z') && (i_InputStr[i] < 'a')) || (i_InputStr[i] > 'z'))
                {
                    isStringContainsOnlyEnglishLetters = false;
                }
            }

            return isStringContainsOnlyEnglishLetters;
        }

        private static bool checkIfStringContainsOnlyDigits(string i_InputStr)
        {
            bool isStringContainsOnlyDigits = true;
            for (int i = 0; i < i_InputStr.Length; i++)
            {
                if (!char.IsDigit(i_InputStr[i]))
                {
                    isStringContainsOnlyDigits = false;
                }
            }

            return isStringContainsOnlyDigits;
        }

        private static bool checkIfStrIsNum(string i_InputStr)
        {
            bool isNum = true;

            for(int i = 0; i < i_InputStr.Length; i++)
            {
                if(i_InputStr[i] < '0' || i_InputStr[i] > '9')
                {
                    isNum = false;
                    break;
                }
            }
            
            return isNum;
        }

        private static bool checkIfDevideBy3(string i_InputStr)
        {
            int inputStrToInt = int.Parse(i_InputStr);
            bool isDevideBy3 = (inputStrToInt % 3 == 0);

            return isDevideBy3;
        }

        private static int calAmountOfLowercaseLetters(string i_InputStr)
        {
            int amountOfSmallLetters = 0;

            for (int i = 0; i < i_InputStr.Length; i++)
            {
                if(char.IsLower(i_InputStr[i]))
                {
                    amountOfSmallLetters++;
                }
            }

            return amountOfSmallLetters;
        }
    }
}
