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
            string binNumAsStr1, binNumAsStr2, binNumAsStr3;
            string decNumAsStr1, decNumAsStr2, decNumAsStr3;
            int decNumAsInt1, decNumAsInt2, decNumAsInt3;
            int avgZeros, avgOnes;
            int amountOfNumbersThatPowOf2;
            int amountOfNumbersThatPalindroms;
            int minNumber, maxNumber;

            readBinariesNumbers(out binNumAsStr1, out binNumAsStr2, out binNumAsStr3);
            convertBinariesStringsToDecStrings(binNumAsStr1, binNumAsStr2, binNumAsStr3, out decNumAsStr1, out decNumAsStr2, out decNumAsStr3);
            convertDecStringsToDecInts(decNumAsStr1, decNumAsStr2, decNumAsStr3, out decNumAsInt1, out decNumAsInt2, out decNumAsInt3);
            amountOfNumbersThatPowOf2 = calAmountOfNumbersThatPowerOf2(binNumAsStr1, binNumAsStr2, binNumAsStr3);
            amountOfNumbersThatPalindroms = calAmountOfPalindromNumbers(decNumAsStr1, decNumAsStr2, decNumAsStr3);
            minNumber = findMin(decNumAsInt1, decNumAsInt2, decNumAsInt3);
            maxNumber = findMax(decNumAsInt1, decNumAsInt2, decNumAsInt3);
            calAvgZerosAndAvgOnes(binNumAsStr1, binNumAsStr2, binNumAsStr3, out avgZeros, out avgOnes);
            printInputStats(
                decNumAsStr1,
                decNumAsStr2,
                decNumAsStr3,
                avgZeros,
                avgOnes,
                amountOfNumbersThatPowOf2,
                amountOfNumbersThatPalindroms,
                minNumber,
                maxNumber);
        }

        private static void convertDecStringsToDecInts(
            string i_DecNumAsStr1,
            string i_DecNumAsStr2,
            string i_DecNumAsStr3,
            out int o_DecNumAsInt1,
            out int o_DecNumAsInt2,
            out int o_DecNumAsInt3)
        {
            o_DecNumAsInt1 = int.Parse(i_DecNumAsStr1);
            o_DecNumAsInt2 = int.Parse(i_DecNumAsStr2);
            o_DecNumAsInt3 = int.Parse(i_DecNumAsStr3);
        }

        private static void readBinariesNumbers(out string o_BinNumAsStr1, out string o_BinNumAsStr2, out string o_BinNumAsStr3)
        {
            Console.WriteLine("Please enter 3 binary numbers: ");
            readSingleBinaryNumber(out o_BinNumAsStr1);
            readSingleBinaryNumber(out o_BinNumAsStr2);
            readSingleBinaryNumber(out o_BinNumAsStr3);
        }

        private static void readSingleBinaryNumber(out string o_CurrentBinNum)
        {
            bool currentInputIsValid = true;

            o_CurrentBinNum = "";

            while (currentInputIsValid)
            {
                o_CurrentBinNum = Console.ReadLine();

                if(!checkIfInputIsValid(o_CurrentBinNum))
                {
                    Console.WriteLine("Incorrect input, please enter again the binary number: ");
                }
                else
                {
                    currentInputIsValid = false;
                }
            }
        }

        private static bool checkIfInputIsValid(string i_CurrentBinNumToCheck)
        {
            bool isValid = (i_CurrentBinNumToCheck.Length == 8);

            for (int i = 0; i < i_CurrentBinNumToCheck.Length; i++)
            {
                if (i_CurrentBinNumToCheck[i] != '0' && i_CurrentBinNumToCheck[i] != '1')
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private static void convertBinariesStringsToDecStrings(string i_BinNumAsStr1, string i_BinNumAsStr2, string i_BinNumAsStr3
            , out string o_DecNumAsStr1, out string o_DecNumAsStr2, out string o_DecNumAsStr3)
        {
            o_DecNumAsStr1 = convertSingleBinaryStringToDecString(i_BinNumAsStr1);
            o_DecNumAsStr2 = convertSingleBinaryStringToDecString(i_BinNumAsStr2);
            o_DecNumAsStr3 = convertSingleBinaryStringToDecString(i_BinNumAsStr3);
        }

        private static string convertSingleBinaryStringToDecString(string i_BinNumAsStr)
        {
            int binNumAsInt = int.Parse(i_BinNumAsStr);
            int decNumAsInt = 0;
            int base1 = 1;

            while(binNumAsInt > 0)
            {
                int reminder = binNumAsInt % 10;
                binNumAsInt = binNumAsInt / 10;
                decNumAsInt += reminder * base1;
                base1 = base1 * 2;
            }

            string decNumAsStr = decNumAsInt.ToString();

            return decNumAsStr;
        }
        private static void calAvgZerosAndAvgOnes(string i_BinNumAsStr1, string i_BinNumAsStr2, string i_BinNumAsStr3, out int o_AvgZeros, out int o_AvgOnes)
        {
            o_AvgZeros = 0;
            o_AvgOnes = 0;

            o_AvgZeros += calAmountOfZerosInString(i_BinNumAsStr1);
            o_AvgZeros += calAmountOfZerosInString(i_BinNumAsStr2);
            o_AvgZeros += calAmountOfZerosInString(i_BinNumAsStr3);
            o_AvgZeros /= 3;
            o_AvgOnes += calAmountOfOnesInString(i_BinNumAsStr1);
            o_AvgOnes += calAmountOfOnesInString(i_BinNumAsStr2);
            o_AvgOnes += calAmountOfOnesInString(i_BinNumAsStr3);
            o_AvgOnes /= 3;
        }

        private static int calAmountOfOnesInString(string i_String)
        {
            int sumOfOnes = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                if (i_String[i] == '1')
                {
                    sumOfOnes++;
                }
            }

            return sumOfOnes;
        }
        private static int calAmountOfZerosInString(string i_String)
        {
            int sumOfZeros = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                if(i_String[i] == '0')
                {
                    sumOfZeros++;
                }
            }

            return sumOfZeros;
        }
        private static int calAmountOfNumbersThatPowerOf2(string i_BinNumAsStr1, string i_BinNumAsStr2, string i_BinNumAsStr3)
        {
            int amountOfNumsThatPowOf2 = 0;
            if(checkIfNumberIsPowerOf2(i_BinNumAsStr1))
            {
                amountOfNumsThatPowOf2++;
            }

            if (checkIfNumberIsPowerOf2(i_BinNumAsStr2))
            {
                amountOfNumsThatPowOf2++;
            }

            if (checkIfNumberIsPowerOf2(i_BinNumAsStr3))
            {
                amountOfNumsThatPowOf2++;
            }
            
            return amountOfNumsThatPowOf2;
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

        private static int calAmountOfPalindromNumbers(string i_DecNumAsStr1, string i_DecNumAsStr2, string i_DecNumAsStr3)
        {
            int amountOfPalindroms = 0;

            if(CheckIfStrIsPalindrom(i_DecNumAsStr1))
            {
                amountOfPalindroms++;
            }

            if (CheckIfStrIsPalindrom(i_DecNumAsStr2))
            {
                amountOfPalindroms++;
            }

            if (CheckIfStrIsPalindrom(i_DecNumAsStr3))
            {
                amountOfPalindroms++;
            }

            return amountOfPalindroms;
        }

        public static bool CheckIfStrIsPalindrom(string i_String)
        {
            bool isPalindrom;

            if (i_String.Length <= 1)
            {
                isPalindrom = true;
            }
            else
            {
                if (i_String[0] != i_String[i_String.Length - 1])
                {
                    isPalindrom = false;
                }
                else
                {
                    isPalindrom = CheckIfStrIsPalindrom(i_String.Substring(1, i_String.Length - 2));
                }
            }

            return isPalindrom;
        }

        private static int findMax(int i_DecNumberAsInt1, int i_DecNumberAsInt2, int i_DecNumberAsInt3)
        {
            int max = i_DecNumberAsInt1;

            if (i_DecNumberAsInt2 > max)
            {
                max = i_DecNumberAsInt2;
            }

            if (i_DecNumberAsInt3 > max)
            {
                max = i_DecNumberAsInt3;
            }

            return max;
        }

        private static int findMin(int i_DecNumberAsInt1, int i_DecNumberAsInt2, int i_DecNumberAsInt3)
        {
            int min = i_DecNumberAsInt1;

            if (i_DecNumberAsInt2 < min)
            {
                min = i_DecNumberAsInt2;
            }

            if (i_DecNumberAsInt3 < min)
            {
                min = i_DecNumberAsInt3;
            }

            return min;
        }

        private static void printInputStats(string i_DecNumAsStr1, string i_DecNumAsStr2, string i_DecNumAsStr3, int i_AvgZeros, int i_AvgOnes, int i_AmountOfNumbThatPowOf2,
                                             int i_AmountOfNumbersThatPalindroms, int i_MinNumber, int i_MaxNumber)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("The numbers in decimal: ").AppendLine();
            stringBuilder.Append(i_DecNumAsStr1).AppendLine();
            stringBuilder.Append(i_DecNumAsStr2).AppendLine();
            stringBuilder.Append(i_DecNumAsStr3).AppendLine();
            stringBuilder.Append("Average of zeros: ").Append(i_AvgZeros).AppendLine();
            stringBuilder.Append("Average of ones: ").Append(i_AvgOnes).AppendLine();
            stringBuilder.Append("Amount of numbers that power of 2: ").Append(i_AmountOfNumbThatPowOf2).AppendLine();
            stringBuilder.Append("Amount of numbers that are palindrom: ").Append(i_AmountOfNumbersThatPalindroms).AppendLine();
            stringBuilder.Append("Minimum number: ").Append(i_MinNumber).AppendLine();
            stringBuilder.Append("Maximum number: ").Append(i_MaxNumber).AppendLine();
            Console.WriteLine(stringBuilder);
        }
    }
}
