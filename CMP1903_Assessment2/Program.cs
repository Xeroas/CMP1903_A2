using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */

            /// <summary>
            /// The "Program" class contains the code to be ran by the program, in this case it includes the "Testing" method and "Game" method which are both instantiated and executed,
            /// the Testing is done first and then the game will run in a loop until the user tells it to stop.
            /// </summary>

            Die playerOneDies = new Die(); //Dies are instantiated here.
            Die playerTwoDies = new Die();
            bool playerOneTurn = true; //toggle between players when conditions met (7 is rolled)

            Game Game1 = new Game(); //Object instantiation, loading "Game" into the program class.

            //Testing Test1 = new Testing(); //Object instantiation, loading "Testing" into the program class.
            //Test1.Test(); //Run the testing method.
            //Console.WriteLine("-------------------\nTesting complete\n-------------------"); //So long as no errors occur, this line will be output to let the user know testing has completed.


            string userInput;
            do
            {
                Console.WriteLine("If you would like to stop rolling please enter 'Stop'\nPlease enter how many times would you like to roll the dies :");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "stop") //If user enters "stop", stop the loop.
                {
                    break;
                }

                try
                {
                    int timesToRoll = Int32.Parse(userInput); //Cast userInput to int.
                    for (int rollCounter = 1; rollCounter <= timesToRoll; rollCounter++) //Create counter to Roll dies based on user input.
                    {
                        var currentPlayer = playerOneTurn ? "Player One" : "Player Two"; //If PlayerOneTurn = True, current player is Player 1, else it's player 2
                        var currentDie = playerOneTurn ? playerOneDies : playerTwoDies; //If PlayerOneTurn = True, use playerOneDies, else use playerTwoDies
                        var dieRoll = currentDie.StartGameSevens(); // Roll dice for the current player


                        Console.WriteLine($"-------------------\n{currentPlayer} rolled: Sum is = {dieRoll.Item1}\n-------------------");

                        if (playerOneDies.SwapPlayers()) // Check if 7 has been rolled
                        {
                            Console.WriteLine("Total sum is 7, swap players");
                            playerOneTurn = !playerOneTurn; // Swap players
                        }
                    }
                }
                catch (FormatException) //If user inputs a string this will catch it and display appropriate message.
                {
                    Console.WriteLine("\nIncorrect input, please enter a number!\n");
                }

                catch (Exception) //If user enters error-causing input this will catch it and display appropriate message.
                {
                    Console.WriteLine("Unexpected error, please try again!");
                }
            } while (true); //Ensure the code above loops while true (user has not told the code to stop).
        }
    }
}
