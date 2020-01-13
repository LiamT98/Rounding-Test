using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Rounding_Test
{
    class Program
    {

        private static List<RoundNumber> userNumbers = new List<RoundNumber>();
        
        static void Main(string[] args)
        {
            Console.Title = "Math.Round() Test";
            Console.WriteLine("Math.Round() method test");

            MenuInterface();
        }

        #region USER INTERACE
        static private void MenuInterface()
        {
            string[] menuItems = new string[] { "(1) Enter numbers", "(2) View history", "(3) Exit" };

            foreach (string item in menuItems)
                Console.WriteLine(item);
            Console.WriteLine("......................");

            GetUserInput();
        }

        static private void EnterNumberInterface()
        {
            Console.WriteLine("Please enter a number");

            GetUserInput();
        }

        static private void ClearAndShowMenu()
        {
            Console.ReadKey();
            Console.Clear();
            MenuInterface();
        }
        #endregion

        #region PROCESS INPUTS
        static private void GetUserInput(object frameSkips = null)
        {
            string input = Console.ReadLine();

            InputProcessing(input, GetMethodName(frameSkips));
        }

        static private string GetMethodName(object frameSkips = null)
        {
            //if (frameSkips != null)
            //{
            //    int skips = int.Parse(frameSkips.ToString());
            //    Console.WriteLine(new StackFrame(skips).GetMethod().Name); // TESTING
            //    Console.ReadKey();
            //    return new StackFrame(skips).GetMethod().Name;
            //}
            //Console.WriteLine(new StackFrame(2).GetMethod().Name); // TESTING
            return new StackFrame(2).GetMethod().Name;

        }

        static private void InputProcessing(string input, string inType)
        {
            double inputDouble = double.Parse(input);
            switch (inType)
            {
                case "MenuInterface":
                    if      (inputDouble == 1)
                        EnterNumberInterface();
                    else if (inputDouble == 2)
                        ViewHistory();
                    else if (inputDouble == 3)
                        Environment.Exit(0);
                    else if (inputDouble < 1 || inputDouble > 3)
                    {
                        Console.WriteLine("Invalid input! Try again...\nPress any key to continue...");
                        ClearAndShowMenu();
                    }
                    else
                        ApplicationError(new StackFrame(0).GetMethod().Name);
                    break;


                case "EnterNumberInterface":
                    RoundingOutput(inputDouble);
                    ClearAndShowMenu();
                    break;
            }
        }
        #endregion

        #region ROUNDING
        static private void RoundingOutput(double input)
        {
            string roundedNum = PerformRounding(input);
            Console.WriteLine("OUTPUT:\n" + roundedNum + "\nPress any key to continue...");
        }

        static private string PerformRounding(double input)
        {
            double output = 0;

            output = Math.Round(input);

            CreateUserNumber(input, output);

            return output.ToString();

        }
        #endregion

        #region USER HISTORY
        static private void CreateUserNumber(double inputNum, double outputNum)
        {
            int id = userNumbers.Count + 1;
            RoundNumber rndNum = new RoundNumber(id, inputNum, outputNum);

            userNumbers.Add(rndNum);
        }

        static private void ViewHistory()
        {
            if (userNumbers.Count == 0)
            {
                Console.WriteLine("No history to display...\nPress any key to continue...");
                ClearAndShowMenu();
            }
            else
            {
                foreach (RoundNumber rndNum in userNumbers)
                {
                    Console.WriteLine("----------------------------\n" + rndNum.PrintRoundNumber() + "\n----------------------------");
                }

                Console.WriteLine("Press any key to continue...");
                ClearAndShowMenu();
            }
        }
        #endregion

        static private void ApplicationError(string callingMethod)
        {
            Console.WriteLine("!---ERROR---ERROR---ERROR---ERROR---ERROR---!\n!     Application error in " + callingMethod + ". \n!     Application will terminate!\n!---ERROR---ERROR---ERROR---ERROR---ERROR---! \nPress any key...");
            Console.ReadKey();
        }
    }



    class RoundNumber
    {
        //class variables
        private int roundNumberID;
        private double roundNumberInput;
        private double roundNumberOutput;

        //Blank Constructor
        public RoundNumber()
        {

        }
        //Parameterised constructor
        public RoundNumber(int rndID, double inDouble, double outDouble)
        {
            roundNumberID = rndID;
            roundNumberInput = inDouble;
            roundNumberOutput = outDouble;
        }
        //Format class for output
        public string PrintRoundNumber()
        {
            return "ID: " + roundNumberID + "\nInput: " + roundNumberInput + "\nOutput: " + roundNumberOutput;
        }
    }
}
