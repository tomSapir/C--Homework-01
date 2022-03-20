using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    class Program
    {
        static void Main()
        {
            string[] numStrBinaryArr = new string[3];
            string[] numStrDecArr = new string[3];

            Console.WriteLine("Please enter 3 binary numbers: ");

            for (int i = 0; i < numStrBinaryArr.Length; i++)
            {
                bool flag = true;

                while (flag)
                {
                    numStrBinaryArr[i] = Console.ReadLine();

                    if (!checkIfValidInput(numStrBinaryArr[i]))
                    {
                        Console.WriteLine("Incorrect input, please enter again the binary number: ");
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }

            convertBinStrNumsToStrDec(numStrBinaryArr, numStrDecArr);

            printIntputStats(numStrBinaryArr, numStrDecArr);

        }

        private static bool checkIfValidInput(string i_NumStr)
        {
            bool isValid = true;

            for (int i = 0; i < i_NumStr.Length; i++)
            {
                if (i_NumStr[i] != '0' && i_NumStr[i] != '1')
                {
                    isValid = false;
                }
            }

            if (i_NumStr.Length != 8)
            {
                isValid = false;
            }

            return isValid;
        }

        private static void convertBinStrNumsToStrDec(string[] i_NumStrBinaryArr, string[] o_NumStrDecArr)
        {
            for (int i = 0; i < i_NumStrBinaryArr.Length; i++)
            {
                o_NumStrDecArr[i] = Convert.ToInt32(i_NumStrBinaryArr[i], 2).ToString();
            }
        }

        private static void calAvgZerosAndOnes(string[] i_NumStrBinaryArr, out int o_AvgZeros, out int o_AvgOnes)
        {
            o_AvgZeros = 0;
            o_AvgOnes = 0;

            for (int i = 0; i < i_NumStrBinaryArr.Length; i++)
            {
                for (int j = 0; j < i_NumStrBinaryArr[i].Length; j++)
                {
                    if (i_NumStrBinaryArr[i][j] == '0')
                    {
                        o_AvgZeros++;
                    }
                    else
                    {
                        o_AvgOnes++;
                    }
                }
            }

            o_AvgOnes /= i_NumStrBinaryArr.Length;
            o_AvgZeros /= i_NumStrBinaryArr.Length;
        }

        private static int amountOfNumsPowOf2(string[] i_NumStrBinaryArr)
        {
            int amountOfNumThatPowOf2 = 0;
            for (int i = 0; i < i_NumStrBinaryArr.Length; i++)
            {
                if(checkIfNumIsPowOf2(i_NumStrBinaryArr[i]))
                {
                    amountOfNumThatPowOf2++;
                }
            }

            return amountOfNumThatPowOf2;
        }

        private static bool checkIfNumIsPowOf2(string i_NumToCheck)
        {
            int numOfOnes = 0;
            bool isPowOf2 = true;
            for(int i = 0; i < i_NumToCheck.Length; i++)
            {
                if(i_NumToCheck[i] == '1')
                {
                    numOfOnes++;
                }
            }

            if(numOfOnes != 1)
            {
                isPowOf2 = false;
            }

            return isPowOf2;
        }

        private static int amountOfNumbersPalindrom(string[] i_NumStrDecArr)
        {
            int amountOfPalindroms = 0;
            for (int i = 0; i < i_NumStrDecArr.Length; i++)
            {
                if(checkIfStrIsPalindrom(i_NumStrDecArr[i]))
                {
                    amountOfPalindroms++;
                }
            }

            return amountOfPalindroms;
        }

        private static bool checkIfStrIsPalindrom(string i_Str)
        {
            bool isPalindromFlag;

            if (i_Str.Length <= 1)
            {
                isPalindromFlag = true;
            }
            else
            {
                if (i_Str[0] != i_Str[i_Str.Length - 1])
                {
                    isPalindromFlag = false;
                }
                else
                {
                    isPalindromFlag = checkIfStrIsPalindrom(i_Str.Substring(1, i_Str.Length - 2));
                }
            }

            return isPalindromFlag;
        }

        private static int findMax(string[] i_NumStrDecArr)
        {
            int max = int.Parse(i_NumStrDecArr[0]);
            for(int i = 1; i < i_NumStrDecArr.Length; i++)
            {
                if(int.Parse(i_NumStrDecArr[i]) > max)
                {
                    max = int.Parse(i_NumStrDecArr[i]);
                }
            }

            return max;
        }

        private static int findMin(string[] i_NumStrDecArr)
        {
            int min = int.Parse(i_NumStrDecArr[0]);
            for (int i = 1; i < i_NumStrDecArr.Length; i++)
            {
                if (int.Parse(i_NumStrDecArr[i]) < min)
                {
                    min = int.Parse(i_NumStrDecArr[i]);
                }
            }

            return min;
        }

        private static void printIntputStats(string[] i_NumStrBinaryArr, string[] i_NumStrDecArr)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int avgZeros, avgOnes;
            
            calAvgZerosAndOnes(i_NumStrBinaryArr, out avgZeros, out avgOnes);
            stringBuilder.Append("The number in decimal: ").AppendLine();

            for (int i = 0; i < i_NumStrDecArr.Length; i++)
            {
                stringBuilder.Append(i_NumStrDecArr[i]).AppendLine();
            }

            stringBuilder.Append("Average of zeros: ").Append(avgZeros).AppendLine();
            stringBuilder.Append("Average of ones: ").Append(avgOnes).AppendLine();
            stringBuilder.Append("Amount of numbers that power of 2: ").Append(amountOfNumsPowOf2(i_NumStrBinaryArr)).AppendLine();
            stringBuilder.Append("Amount of numbers that are palindrom: ").Append(amountOfNumbersPalindrom(i_NumStrDecArr)).AppendLine();
            stringBuilder.Append("Minimum number: ").Append(findMin(i_NumStrDecArr)).AppendLine();
            stringBuilder.Append("Maximum number: ").Append(findMax(i_NumStrDecArr)).AppendLine();

            Console.WriteLine(stringBuilder);
        }
    }
}
