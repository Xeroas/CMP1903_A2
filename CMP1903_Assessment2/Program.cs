using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statistics stats = new Statistics();
            Testing GameTest = new Testing();

            string userInput;
            do
            {
                Console.WriteLine("Enter '1' to play Sevens Out or '2' to enter Testing, Enter '3' to view statistics. \nEnter 'Stop' at any time to exit the program.");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                        PlaySevensOutGame(stats);
                        break;
                    case "2":
                        GameTest.Test();
                        Console.WriteLine("Testing Complete, die values are correct, no errors detected!\n");
                        break;
                    case "3":
                        ViewStatistics(stats);
                        break;
                    case "stop":
                        Console.WriteLine("You have chosen to exit the game, exiting now!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option (1-3).");
                        break;
                }
            } while (userInput != "1"); //Loop when input is not 1 (when selecting stats or test will show stats / test then go back to menu)
        }

        static void PlaySevensOutGame(Statistics stats)
        {
            string userInput;
            do
            {
                bool gameStarted = false; // Used to track if game has started
                Console.WriteLine("Enter '1' to play single player or '2' to play with two players:");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                        if (!gameStarted)
                        {
                            stats.IncreaseGameCount(false); // Increment game for correct game type, false = single player true = two player
                            gameStarted = true;
                        }
                        PlaySevensOut1Player(stats);
                        break;
                    case "2":
                        if (!gameStarted)
                        {
                            stats.IncreaseGameCount(true);
                            gameStarted = true;
                        }
                        PlaySevensOut2Player(stats);
                        break;
                    case "stop":
                        Console.WriteLine("You have chosen to exit the game, exiting now!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter '1' or '2'.");
                        break;
                }

                Console.WriteLine("Would you like to play again? (yes/no)");
                userInput = Console.ReadLine().ToLower();
            } while (userInput == "yes");
        }

        static void PlaySevensOut2Player(Statistics stats)
        {
            SevensOut game = new SevensOut();
            game.SevensOutTwoPlayer(stats);
        }

        static void PlaySevensOut1Player(Statistics stats)
        {
            SevensOut game = new SevensOut();
            game.SevensOutOnePlayer(stats);
        }

        static void ViewStatistics(Statistics stats)
        {
            stats.DisplayStatistics();
        }
    }
}
