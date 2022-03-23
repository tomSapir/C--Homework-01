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
            Console.WriteLine("Please enter the height of the sand clock: ");
            String inputHeightStr = "";
            int inputHeightInt;
            bool inputIsValid = false;

            while(!inputIsValid)
            {
                inputHeightStr = Console.ReadLine();

                if(checkIfInputIsValid(inputHeightStr))
                {
                    inputIsValid = true;
                }
                else
                {
                    Console.WriteLine("Input is not valid. please write the height again: ");
                }
            }

            inputHeightInt = int.Parse(inputHeightStr);
            convertHeightToOddIfNeed(ref inputHeightInt);
            Ex01_02.Program.PrintSandClock(inputHeightInt, inputHeightInt, 0);
        }

        private static bool checkIfInputIsValid(string i_InputHeight)
        {
            int n;
            bool isNumeric = int.TryParse( i_InputHeight, out n);
            bool isValid = (isNumeric && (i_InputHeight[0] != '-'));

            return isValid;
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
