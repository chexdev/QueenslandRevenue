using System;
using static System.Console;

namespace QueenslandRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1 - Prompt user input//
            int numLastYr;
            string numLast;
            int numThisYr;
            string numThis;
            const int MIN = 0;
            const int MAX = 30;

            Write("Enter number of contestants entered in last year's competition: ");
            numLast = ReadLine();
            numLastYr = Convert.ToInt32(numLast);

            if (numLastYr > MAX || numLastYr < MIN)
            {
                Write("Number is incorrect. Please re-enter a valid value: ");
                numLast = ReadLine();
                numLastYr = Convert.ToInt32(numLast);
            }
            Write("Enter number of contestants entered in this year's competition: ");
            numThis = ReadLine();
            numThisYr = Convert.ToInt32(numThis);

            if (numThisYr > MAX || numLastYr < MIN)
            {
                Write("Number is incorrect. Please re-enter a valid value: ");
                numThis = ReadLine();
                numThisYr = Convert.ToInt32(numThis);
            }

            //Step 2 - Display all input data//
            WriteLine("\nNo. of contestants entered in this year: {0}. \nNo. of contestants entered last year: {1}", numThisYr, numLastYr);

            //Step 3 - Display statements//
            int sum;
            sum = numLastYr + numThisYr;
            WriteLine("\nTotal no. of contestants attended for this and last year combined: {0}", sum);

            if (numThisYr > numLastYr * 2)
            {
                WriteLine("\nThe competition is more than twice as big this year!");
            }
            else if (numThisYr >= numLastYr)
            {
                WriteLine("\nThe competition is bigger than ever!");
            }
            else
            {
                WriteLine("\nA tighter race this year! Come out and cast your vote!");
            }

            //Step 4 - Enter names and talent codes // 
            string[] names = new string[numThisYr];
            int x;

            WriteLine("\nEnter contestant names below: ");
            for (x = 0; x < names.Length; x++)
            {
                Write("Enter contestant {0}: ", (x + 1));
                names[x] = ReadLine();
            }

            char[] talentCode = new char[numThisYr];
            WriteLine("\nThe talent codes for this competition are: S for singing, D for dancing, M for musical instrument, and O for other.");
            WriteLine("Enter talent code for each contestant: ");

            for (x = 0; x < talentCode.Length; x++)
            {
                Write("Contestant {0} ({1}): ", (x + 1), names[x]);
                talentCode[x] = Convert.ToChar(ReadLine());

                if (!(talentCode[x] == 'S' || talentCode[x] == 'D' || talentCode[x] == 'M' || talentCode[x] == 'O'))
                {
                    WriteLine("Incorrect code entered. Please re-enter: ");
                    x--;
                }
            }

            //Steps 5 & 6 - Display count of contestants for each talent type, prompt for talent code, display list of contestants or valid message etc.//
            int countS = 0; int countD = 0; int countM = 0; int countO = 0;

            Write("\nThe no. of contestants (count) for each type of talent are: ");
            for (x = 0; x < talentCode.Length; x++)
            {
                if (talentCode[x] == 'S')
                {
                    countS += 1;
                }
                if (talentCode[x] == 'D')
                {
                    countD += 1;
                }
                if (talentCode[x] == 'M')
                {
                    countM += 1;
                }
                if (talentCode[x] == 'O')
                {
                    countO += 1;
                }
            }
            Write("\nSinging: {0}", countS);
            Write("\nDancing: {0}", countD);
            Write("\nMusical Instrument: {0}", countM);
            WriteLine("\nOthers: {0}", countO);

            const char QUIT = 'Q';
            char inputChar = ' ';
            int y;

            while (inputChar != QUIT)
            {
                Write("\nEnter talent code to display list of contestant names (or type Q to quit): ");
                inputChar = Convert.ToChar(ReadLine());

                if (inputChar == 'S' || inputChar == 'D' || inputChar == 'M' || inputChar == 'O')
                {
                    for (y = 0; y < talentCode.Length; y++)
                    {
                        if (talentCode[y] == inputChar)
                        {
                            WriteLine("{0}", names[y]);
                        }
                    }
                }
                else if (inputChar == QUIT)
                {
                    WriteLine("\nYou have quit.");
                    WriteLine("In summary, the number of participants for each event is: ");
                    WriteLine("Singing(S): {0}, Dance(D): {1}, Musical Instrument(M): {2}, Others(O): {3}.", countS, countD, countM, countO); 
                }
                else
                {
                    WriteLine("Incorrect code entered. Please re-enter: ");
                }
            }

        }

    }

}