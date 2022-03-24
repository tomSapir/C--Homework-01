using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ex01_02;

namespace Ex01_o3
{
    class Program
    {
        static void Main()
        {
            int sandClockHeight = readHeightFromUser();

            convertHeightToOddIfNeed(ref sandClockHeight);
            Ex01_02.Program.PrintSandClock(sandClockHeight, sandClockHeight, 0);
        }

        private static bool checkIfInputIsValid(string i_InputHeight)
        {
            int n;
            bool isNumeric = int.TryParse( i_InputHeight, out n);
            bool isValid = isNumeric && (i_InputHeight[0] != '-');

            return isValid;
        }

        private static int readHeightFromUser()
        {
            String inputHeightAsString = string.Empty;
            int inputHeightAsInt;
            bool inputIsValid = false;

            Console.WriteLine("Please enter the height of the sand clock: ");
            while (!inputIsValid)
            {
                inputHeightAsString = Console.ReadLine();
                if (checkIfInputIsValid(inputHeightAsString))
                {
                    inputIsValid = true;
                }
                else
                {
                    Console.WriteLine("Input is not valid. please write the height again: ");
                }
            }

            inputHeightAsInt = int.Parse(inputHeightAsString);

            return inputHeightAsInt;
        }

        private static void convertHeightToOddIfNeed(ref int io_Height)
        {
            if (checkNumberIfEven(io_Height))
            {
                io_Height++;
            }
        }
        private static bool checkNumberIfEven(int i_Num)
        {
            bool isEven = ((i_Num % 2) == 0);

            return isEven;
        }
    }
}
