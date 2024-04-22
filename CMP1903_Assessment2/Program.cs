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
                Console.WriteLine("Enter '1' to play Sevens Out or '2' to view statistics or '3' to test the game is working correctly :");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        PlaySevensOutGame(stats);
                        break;
                    case "2":
                        ViewStatistics(stats);
                        Console.ReadLine();
                        break;
                    case "3":
                        GameTest.Test();
                        Console.WriteLine("Testing Complete, Sum values and die values are correct!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter '1' or '2'.");
                        break;
                }
            } while (userInput != "1" && userInput != "2");
        }

        static void PlaySevensOutGame(Statistics stats)
        {
            bool gameStarted = false; //Used to tracks if game has started
            string userInput;

            do
            {
                Console.WriteLine("Enter '1' to play single player or '2' to play with two players:");
                userInput = Console.ReadLine();

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
                    default:
                        Console.WriteLine("Invalid input. Please enter '1' or '2'.");
                        break;
                }
            } while (userInput != "1" && userInput != "2");
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
