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
            Ex01_02.Program.PrintSandClock(inputHeightInt);
        }

        private static bool checkIfInputIsValid(string i_InputHeight)
        {
            bool isValid = true;
            int n;
            bool isNumeric = int.TryParse( i_InputHeight, out n);

            if(!isNumeric)
            {
                isValid = false;
            }
            else
            {
                if(i_InputHeight[0] == '-')
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
