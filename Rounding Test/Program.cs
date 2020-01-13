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

        static void Main(string[] args)
        {
            Console.Title = "Math.Round() Test";
            Console.WriteLine("Math.Round() method test");

            MenuInterface();
        }


        #region USER INTERACE
        static private void MenuInterface()
        {
            string[] menuItems = new string[] { "(1) Enter numbers", "(2) Exit" };
            
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
                    if (inputDouble == 1)
                        EnterNumberInterface();
                    else if (inputDouble == 2)
                        Environment.Exit(0);
                    else if (inputDouble < 1 || inputDouble > 2)
                    {
                        Console.WriteLine("Invalid input! Try again...\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        MenuInterface();
                    }
                    else 
                        ApplicationError(new StackFrame(0).GetMethod().Name);
                    break;


                case "EnterNumberInterface":
                    PerformRounding(inputDouble);
                    break;
            }
        }
        #endregion






        static private void PerformRounding(double input)
        {
            double output = 0;

            output = Math.Floor(input);

            Console.WriteLine("Output: " + output + "\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
            MenuInterface();

        }



        static private void ApplicationError(string callingMethod)
        {
            Console.WriteLine("!---ERROR---ERROR---ERROR---ERROR---ERROR---!\n!     Application error in " + callingMethod + ". \n!     Application will terminate!\n!---ERROR---ERROR---ERROR---ERROR---ERROR---! \nPress any key...");
            Console.ReadKey();
        }
    }
}
