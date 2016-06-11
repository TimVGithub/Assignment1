
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1 {

    /*
     * 
     * Ohm's Law: Voltage = Current * Resistance
     *
     * From a main menu, given any two of the three quantities in Ohm's Law, the program 
     * calculates the third (or it can exit).
     * After initial calculation, allows for recalculation after user input decides which
     * variable is to be adjusted.
     * If no recalculation is to be done, program returns to main menu.
     *
     * Author: Martin-Timothy Vu, 9454870
     * Date: March 2016
     *
     */

    class Program {
        static void Main(string[] args) {

            int mainRunType;
            int mainRecalculate;
            double mainVoltage;
            double mainCurrent;
            double mainResistance;

            do {
                DisplayWelcomeMessage();
                mainRunType = RunTypeCheck();

                //If statements to determine which operation is to be run
                if (mainRunType == 1) {
                    mainCurrent = ReceiveCurrent();
                    mainResistance = ReceiveResistance();
                    DisplayVoltage(mainCurrent, mainResistance);
                    PromptContinue();
                    mainRecalculate = CheckRecalculate();

                    //Loop for continued recalculations
                    do {

                        //If statements to determine which variable is to be changed, if any
                        if (mainRecalculate == 1) {
                            mainCurrent = ReceiveCurrent();
                            PromptContinue();
                            DisplayVoltage(mainCurrent, mainResistance);
                            mainRecalculate = CheckRecalculate();
                        } else if (mainRecalculate == 2) {
                            mainResistance = ReceiveResistance();
                            PromptContinue();
                            DisplayVoltage(mainCurrent, mainResistance);
                            mainRecalculate = CheckRecalculate();
                        } else {
                        }
                    } while (mainRecalculate != 0);

                } else if (mainRunType == 2) {
                    mainVoltage = ReceiveVoltage();
                    mainResistance = ReceiveResistance();
                    DisplayCurrent(mainVoltage, mainResistance);
                    PromptContinue();
                    mainRecalculate = CheckRecalculate();
                    do {
                        if (mainRecalculate == 1) {
                            mainVoltage = ReceiveVoltage();
                            PromptContinue();
                            DisplayCurrent(mainVoltage, mainResistance);
                            mainRecalculate = CheckRecalculate();
                        } else if (mainRecalculate == 2) {
                            mainResistance = ReceiveResistance();
                            PromptContinue();
                            DisplayCurrent(mainVoltage, mainResistance);
                            mainRecalculate = CheckRecalculate();
                        } else {
                        }
                    } while (mainRecalculate != 0);

                } else if (mainRunType == 3) {
                    mainVoltage = ReceiveVoltage();
                    mainCurrent = ReceiveCurrent();
                    DisplayResistance(mainVoltage, mainCurrent);
                    PromptContinue();
                    mainRecalculate = CheckRecalculate();
                    do {
                        if (mainRecalculate == 1) {
                            mainVoltage = ReceiveVoltage();
                            PromptContinue();
                            DisplayResistance(mainVoltage, mainCurrent);
                            mainRecalculate = CheckRecalculate();
                        } else if (mainRecalculate == 2) {
                            mainCurrent = ReceiveCurrent();
                            PromptContinue();
                            DisplayResistance(mainVoltage, mainCurrent);
                            mainRecalculate = CheckRecalculate();
                        } else {
                        }
                    } while (mainRecalculate != 0);

                } else if (mainRunType == 4) {
                }

            } while (mainRunType != 4);

            DisplayExitMessage();
        }


        //Display welcome message
        static void DisplayWelcomeMessage() {
            Console.WriteLine("");
            Console.WriteLine(@" \    /   _   |   _   _   ._ _    _     _|_   _     _|_  |_    _ ");
            Console.WriteLine(@"  \/\/   (/_ _|  (_  (_)  | | | _(/_     |_  (_)     |_  | |  (/_ ");
            Console.WriteLine(@"         /  / \  |_|  |\/|  /  (_     |    /\   \    /  /         ");
            Console.WriteLine(@"            \_/  | |  |  |     __)    |_  /--\   \/\/             ");
            Console.WriteLine(@"            _   _.  |   _        _.  |  _|_   _   ._              ");
            Console.WriteLine(@"           (_  (_|  |  (_  |_|  (_|  |   |_  (_)  |               ");
        }//DisplayWelcomeMessage

        //------------------------------------------------------------------------------------------------------

        //Receive user's input on which operation to run
        static int RunTypeCheck() {

            int runRunTypeCheck = 0;
            int runType;
            bool validRunType;

            do {
                Console.WriteLine("\nWhich operation would you like to perform:\n\t(1)Calculate voltage\n\t"
                                  + "(2)Calculate current\n\t(3)Calculate resistance\n\n\t(4)Exit");
                validRunType = int.TryParse(Console.ReadLine(), out runType);

                //If statement to handle invalid inputs
                if ((validRunType != true) || (runType < 1 || runType > 4)) {
                    runRunTypeCheck = 1;
                    Console.WriteLine("\nYour input was invalid please enter 1,2,3 or 4");
                } else {
                    runRunTypeCheck = 0;
                }
            } while (runRunTypeCheck == 1);

            return runType;
        }//RunTypeCheck

        //------------------------------------------------------------------------------------------------------

        //Receive user input for voltage
        static double ReceiveVoltage() {

            int runReceiveVoltage = 0;
            double inputVoltage;
            const double MINIMUM_VOLTAGE = 0;
            bool validVoltage;


            do {
                Console.WriteLine("\nPlease enter the voltage (volts): ");
                validVoltage = double.TryParse(Console.ReadLine(), out inputVoltage);

                //If statement to handle invalid inputs
                if ((validVoltage != true) || inputVoltage < MINIMUM_VOLTAGE) {
                    runReceiveVoltage = 1;
                    Console.WriteLine("\nYour input was invalid, ensure you entered a number above 0");
                } else {
                    runReceiveVoltage = 0;
                }
            } while (runReceiveVoltage == 1);

            return inputVoltage;
        }//ReceiveVoltage

        //------------------------------------------------------------------------------------------------------

        //Receive user input for current
        static double ReceiveCurrent() {

            int runReceiveCurrent = 0;
            double inputCurrent;
            const double MINIMUM_CURRENT = 0.01;
            bool validCurrent;

            do {
                Console.WriteLine("\nPlease enter the current (amps): ");
                validCurrent = double.TryParse(Console.ReadLine(), out inputCurrent);

                //If statement to handle invalid inputs
                if ((validCurrent != true) || inputCurrent < MINIMUM_CURRENT) {
                    runReceiveCurrent = 1;
                    Console.WriteLine("\nYour input was invalid, ensure you entered a number above 0.01");
                } else {
                    runReceiveCurrent = 0;
                }
            } while (runReceiveCurrent == 1);

            return inputCurrent;
        }//ReceiveCurrent

        //------------------------------------------------------------------------------------------------------

        //Receive user input for resistance
        static double ReceiveResistance() {

            int runReceiveResistance = 0;
            double inputResistance;
            const double MINIMUM_RESISTANCE = 10;
            bool validResistance;

            do {
                Console.WriteLine("\nPlease enter the resistance (ohms): ");
                validResistance = double.TryParse(Console.ReadLine(), out inputResistance);

                //If statement to handle invalid inputs
                if ((validResistance != true) || inputResistance < MINIMUM_RESISTANCE) {
                    runReceiveResistance = 1;
                    Console.WriteLine("\nYour input was invalid, ensure you entered a number above 10");
                } else {
                    runReceiveResistance = 0;
                }
            } while (runReceiveResistance == 1);

            return inputResistance;
        }//ReceiveResistance

        //------------------------------------------------------------------------------------------------------

        //Display voltage result to user
        static void DisplayVoltage(double mainCurrent, double mainResistance) {
            Console.WriteLine("\nGiven:\n\t-a current of: {0:f2} amps\n\t-a resistance of: {1:f2} ohms\n\n\tThe voltage is: {2:f2} volts.",
                mainCurrent, mainResistance, mainCurrent * mainResistance);
        }//DisplayVoltage

        //------------------------------------------------------------------------------------------------------

        //Display current result to user
        static void DisplayCurrent(double mainVoltage, double mainResistance) {
            Console.WriteLine("\nGiven:\n\t-a voltage of: {0:f2} volts\n\t-a resistance of: {1:f2} ohms\n\n\tThe current is: {2:f2} amps.",
                mainVoltage, mainResistance, mainVoltage / mainResistance);
        }//DisplayCurrent

        //------------------------------------------------------------------------------------------------------

        //Display resistance result to user
        static void DisplayResistance(double mainVoltage, double mainCurrent) {
            Console.WriteLine("\nGiven:\n\t-a voltage of: {0:f2} volts\n\t-a current of: {1:f2} amps\n\n\tThe resistance is: {2:f2} ohms.",
                mainVoltage, mainCurrent, mainVoltage / mainCurrent);
        }//DisplayResistance

        //------------------------------------------------------------------------------------------------------

        //Check if the user would like to recalculate with different variables or return to main menu
        static int CheckRecalculate() {

            int runCheckRecalculate = 1;
            int inputRecalculate;
            bool validRecalculate;

            do {
                Console.WriteLine("\nWould you like to:\n\t(1)Recalculate after adjusting a variable\n\t(0)Return to main menu");

                //If statement to handle invalid inputs
                validRecalculate = int.TryParse(Console.ReadLine(), out inputRecalculate);
                if (validRecalculate != true || ((inputRecalculate != 0) && (inputRecalculate != 1))) {
                    Console.WriteLine("\nYour input was invalid, please enter 0 or 1");
                    runCheckRecalculate = 1;
                } else {

                    //If statement to either exit to menu or ask user which variable they'd like to adjust
                    if (inputRecalculate == 0) {
                        runCheckRecalculate = 0;
                    } else if (inputRecalculate == 1) {

                        do {
                            Console.WriteLine("\nWhich variable would you like to recalculate:\n\t(1)1st Variable entered\n\t(2)2nd variable entered");

                            //If statement to handle invalid inputs
                            validRecalculate = int.TryParse(Console.ReadLine(), out inputRecalculate);
                            if (validRecalculate != true || ((inputRecalculate != 1) && (inputRecalculate != 2))) {
                                Console.WriteLine("\nYour input was invalid, please enter 1 or 2");
                                runCheckRecalculate = 1;
                            } else {
                                runCheckRecalculate = 0;
                            }
                        } while (runCheckRecalculate == 1);
                    }
                }
            } while (runCheckRecalculate == 1);

            return inputRecalculate;
        }//CheckRecalculate

        //------------------------------------------------------------------------------------------------------

        //Prompts the user to continue, as to allow them to process less items at once
        static void PromptContinue() {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }//PromptContinue

        //------------------------------------------------------------------------------------------------------

        //Displays an exit message
        static void DisplayExitMessage() {
            Console.WriteLine("\nThank you for using the 'Ohm's Law' calculator, press any key to close.");
            Console.ReadKey();
        }//DisplayExitMessage
    }
}
