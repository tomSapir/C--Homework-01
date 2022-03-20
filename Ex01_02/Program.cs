using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        static void Main()
        {
            PrintSandClock(6);
        }

        public static void PrintSandClock(int i_Height)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int asterisksToPrint, spacesToPrint;

            convertHeightToOddIfNeed(ref i_Height);

            for (asterisksToPrint = i_Height, spacesToPrint = 0; asterisksToPrint != 1; asterisksToPrint -= 2, spacesToPrint++)
            {
                printLine(ref stringBuilder, asterisksToPrint, spacesToPrint);
            }

            for(; asterisksToPrint != (i_Height + 2); asterisksToPrint += 2, spacesToPrint--)
            {
                printLine(ref stringBuilder, asterisksToPrint, spacesToPrint);
            }

            Console.WriteLine(stringBuilder);
        }

        private static void printLine(ref StringBuilder io_StringBuilder, int i_AsterisksAmount, int i_SpacesAmount)
        {
            io_StringBuilder.Append(' ', i_SpacesAmount);
            io_StringBuilder.Append('*', i_AsterisksAmount);
            io_StringBuilder.Append(' ', i_SpacesAmount).AppendLine();
        }

        private static void convertHeightToOddIfNeed(ref int io_Height)
        {
            if(checkIfEven(io_Height))
            {
                io_Height++;
            }
        }
        private static bool checkIfEven(int i_Num)
        {
            bool isEven = ((i_Num % 2) == 0);

            return isEven;
        }
    }
}
