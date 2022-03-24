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
           PrintSandClock(5, 5, 0);
        }

        public static void PrintSandClock(int i_CurrHeight, int i_CurrAsterisksToPrint, int i_CurrSpacesToPrint)
        {
            if (i_CurrAsterisksToPrint >= 1)
            {
                printLine(i_CurrAsterisksToPrint, i_CurrSpacesToPrint);
                PrintSandClock(i_CurrHeight - 1, i_CurrAsterisksToPrint - 2, i_CurrSpacesToPrint + 1);
                if(i_CurrAsterisksToPrint != 1)
                {
                    printLine(i_CurrAsterisksToPrint, i_CurrSpacesToPrint);
                }
            }
        }

        private static void printLine( int i_AsterisksAmount, int i_SpacesAmount)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(' ', i_SpacesAmount);
            stringBuilder.Append('*', i_AsterisksAmount);
            stringBuilder.Append(' ', i_SpacesAmount);
            Console.WriteLine(stringBuilder);
        }
    }
}
