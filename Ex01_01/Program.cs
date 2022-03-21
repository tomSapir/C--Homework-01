using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    public class Program
    {
        static void Main()
        {
            string[] binariesNumbersAsStrings = new string[3];
            string[] decNumbersAsStrings = new string[3];

            readNBinariesNumbers(3, ref binariesNumbersAsStrings);
            convertBinariesStringsToDecStrings(binariesNumbersAsStrings, decNumbersAsStrings);
            printIntputStats(binariesNumbersAsStrings, decNumbersAsStrings);
        }

        private static void readNBinariesNumbers(int i_AmountOfNumbersToRead, ref string[] o_BinariesNumbersInStr)
        {
            bool currentInputIsValid = true;

            Console.WriteLine("Please enter 3 binary numbers: ");
            for(int i = 0; i < i_AmountOfNumbersToRead; i++)
            {
                currentInputIsValid = true;

                while(currentInputIsValid)
                {
                    o_BinariesNumbersInStr[i] = Console.ReadLine();

                    if(!checkIfInputIsValid(o_BinariesNumbersInStr[i]))
                    {
                        Console.WriteLine("Incorrect input, please enter again the binary number: ");
                    }
                    else
                    {
                        currentInputIsValid = false;
                    }
                }
            }
        }

        private static bool checkIfInputIsValid(string i_NumStr)
        {
            bool isValid = (i_NumStr.Length == 8);

            for (int i = 0; i < i_NumStr.Length; i++)
            {
                if (i_NumStr[i] != '0' && i_NumStr[i] != '1')
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private static void convertBinariesStringsToDecStrings(string[] i_BinariesStrings, string[] o_DecStrings)
        {
            for (int i = 0; i < i_BinariesStrings.Length; i++)
            {
                o_DecStrings[i] = Convert.ToInt32(i_BinariesStrings[i], 2).ToString();
            }
        }

        private static void calAvgZerosAndAvgOnes(string[] i_BinariesStrings, out int o_AvgZeros, out int o_AvgOnes)
        {
            o_AvgZeros = 0;
            o_AvgOnes = 0;

            for (int i = 0; i < i_BinariesStrings.Length; i++)
            {
                for (int j = 0; j < i_BinariesStrings[i].Length; j++)
                {
                    if (i_BinariesStrings[i][j] == '0')
                    {
                        o_AvgZeros++;
                    }
                    else
                    {
                        o_AvgOnes++;
                    }
                }
            }

            o_AvgOnes /= i_BinariesStrings.Length;
            o_AvgZeros /= i_BinariesStrings.Length;
        }

        private static int calAmountOfNumbersThatPowerOf2(string[] i_BinariesStrings)
        {
            int amountOfNumbersThatPowOf2 = 0;
            for (int i = 0; i < i_BinariesStrings.Length; i++)
            {
                if(checkIfNumberIsPowerOf2(i_BinariesStrings[i]))
                {
                    amountOfNumbersThatPowOf2++;
                }
            }

            return amountOfNumbersThatPowOf2;
        }

        private static bool checkIfNumberIsPowerOf2(string i_NumToCheck)
        {
            int numOfOnes = 0;
            bool isPowOf2;

            for (int i = 0; i < i_NumToCheck.Length; i++)
            {
                if(i_NumToCheck[i] == '1')
                {
                    numOfOnes++;
                }
            }

            isPowOf2 = (numOfOnes == 1);

            return isPowOf2;
        }

        private static int calAmountOfPalindromNumbers(string[] i_DecNumbers)
        {
            int amountOfPalindroms = 0;
            for (int i = 0; i < i_DecNumbers.Length; i++)
            {
                if(CheckIfStrIsPalindrom(i_DecNumbers[i]))
                {
                    amountOfPalindroms++;
                }
            }

            return amountOfPalindroms;
        }

        public static bool CheckIfStrIsPalindrom(string i_StrToCheck)
        {
            bool isPalindromFlag;

            if (i_StrToCheck.Length <= 1)
            {
                isPalindromFlag = true;
            }
            else
            {
                if (i_StrToCheck[0] != i_StrToCheck[i_StrToCheck.Length - 1])
                {
                    isPalindromFlag = false;
                }
                else
                {
                    isPalindromFlag = CheckIfStrIsPalindrom(i_StrToCheck.Substring(1, i_StrToCheck.Length - 2));
                }
            }

            return isPalindromFlag;
        }

        private static int findMax(string[] DecNumbers)
        {
            int max = int.Parse(DecNumbers[0]);
            for(int i = 1; i < DecNumbers.Length; i++)
            {
                if(int.Parse(DecNumbers[i]) > max)
                {
                    max = int.Parse(DecNumbers[i]);
                }
            }

            return max;
        }

        private static int findMin(string[] i_DecNumbers)
        {
            int min = int.Parse(i_DecNumbers[0]);
            for (int i = 1; i < i_DecNumbers.Length; i++)
            {
                if (int.Parse(i_DecNumbers[i]) < min)
                {
                    min = int.Parse(i_DecNumbers[i]);
                }
            }

            return min;
        }

        private static void printIntputStats(string[] i_BinariesNumbersAsStrings, string[] i_DecNumbersAsStrings)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int avgZeros, avgOnes;
            
            calAvgZerosAndAvgOnes(i_BinariesNumbersAsStrings, out avgZeros, out avgOnes);
            stringBuilder.Append("The numbers in decimal: ").AppendLine();

            for (int i = 0; i < i_DecNumbersAsStrings.Length; i++)
            {
                stringBuilder.Append(i_DecNumbersAsStrings[i]).AppendLine();
            }

            stringBuilder.Append("Average of zeros: ").Append(avgZeros).AppendLine();
            stringBuilder.Append("Average of ones: ").Append(avgOnes).AppendLine();
            stringBuilder.Append("Amount of numbers that power of 2: ").Append(calAmountOfNumbersThatPowerOf2(i_BinariesNumbersAsStrings)).AppendLine();
            stringBuilder.Append("Amount of numbers that are palindrom: ").Append(calAmountOfPalindromNumbers(i_DecNumbersAsStrings)).AppendLine();
            stringBuilder.Append("Minimum number: ").Append(findMin(i_DecNumbersAsStrings)).AppendLine();
            stringBuilder.Append("Maximum number: ").Append(findMax(i_DecNumbersAsStrings)).AppendLine();

            Console.WriteLine(stringBuilder);
        }
    }
}
