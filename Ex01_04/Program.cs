using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            string inputStr;
            int amountOfSmallLetters;

            Console.WriteLine("Please enter 8 digit string: ");
            inputStr = readStr();

            if (checkIfStrIsPalindrom(inputStr))
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

        private static string readStr()
        {
            bool strIsValid = false;
            string inputStr = "";

            while (!strIsValid)
            {
                inputStr = Console.ReadLine();

                if (checkIfStrIsValid(inputStr))
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

        private static bool checkIfStrIsValid(string i_InputStr)
        {
            bool isLength8 = (i_InputStr.Length == 8);
            bool isEnglish = checkIfStringContainsOnlyEnglishLetters(i_InputStr);
            bool isNumber = checkIfStringContainsOnlyNumbers(i_InputStr);
            bool strIsValidFlag = true;

            if (!isLength8 ||  (!isNumber && !isEnglish))
            {
                strIsValidFlag = false;
            }

            return strIsValidFlag;
        }

        private static bool checkIfStringContainsOnlyEnglishLetters(string i_InputStr)
        {
            bool res = true;
            for (int i = 0; i < i_InputStr.Length; i++)
            {
                if ((i_InputStr[i] < 'A') || ((i_InputStr[i] > 'Z') && (i_InputStr[i] < 'a')) || (i_InputStr[i] > 'z'))
                {
                    res = false;
                }
            }

            return res;
        }

        private static bool checkIfStringContainsOnlyNumbers(string i_InputStr)
        {
            bool res = true;
            for(int i = 0; i < i_InputStr.Length; i++)
            {
                if(!char.IsDigit(i_InputStr[i]))
                {
                    res = false;
                }
            }

            return res;
        }

        private static bool checkIfStrIsPalindrom(string i_InputStr)
        {
            bool isPalindromFlag;

            if (i_InputStr.Length <= 1)
            {
                isPalindromFlag = true;
            }
            else
            {
                if (i_InputStr[0] != i_InputStr[i_InputStr.Length - 1])
                {
                    isPalindromFlag = false;
                }
                else
                {
                    isPalindromFlag = checkIfStrIsPalindrom(i_InputStr.Substring(1, i_InputStr.Length - 2));
                }
            }

            return isPalindromFlag;
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
