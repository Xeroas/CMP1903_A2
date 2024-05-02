using CMP1903_A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut
    {
        string filePath = @"C:\Users\JackT\OneDrive\Desktop\OOP ASS\CMP1903-OOP-AS2\CMP1903_Assessment2\game_stats.txt"; //hardcoded file location, for testing purposes create .txt file and replace this file path with /your/ one.

        private Die playerOneDie;
        private Die playerTwoDie;
        private bool playerOneTurn;
        private int playerOneScore;
        private int playerTwoScore;

        public SevensOut()
        {
            playerOneDie = new Die();
            playerTwoDie = new Die();
            playerOneTurn = true;
            playerOneScore = 0;
            playerTwoScore = 0;
        }

        public void SevensOutTwoPlayer(Statistics stats) //Prompted when player selects '2 player' version of sevens out, will direct them to either play with friend game or play vs computer
        {
            string userInput;
            do
            {
                Console.WriteLine("Enter '1' to play against a friend or '2' to play against the computer:");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    SevensOutWithFriend(stats);
                    break;
                }
                else if (userInput == "2")
                {
                    SevensOutWithComp(stats);
                    break;
                }
                else if (userInput.ToLower() == "stop")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter '1' or '2'.");
                }
            } while (true);
        }

        private void SevensOutWithFriend(Statistics stats)
        {
            string userInput;

            do
            {
                Console.WriteLine("Enter any input to roll the dice or enter 'Stop' to exit:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "stop")
                {
                    return;
                }

                try
                {
                    var currentPlayer = playerOneTurn ? "Player One" : "Player Two";
                    var currentDie = playerOneTurn ? playerOneDie : playerTwoDie;
                    var dieRoll = currentDie.StartGameSevens();

                    Console.WriteLine($"-------------------\n{currentPlayer} rolled: Sum is = {dieRoll.Item1}\n-------------------");

                    if (dieRoll.Item2 == dieRoll.Item3)
                    {
                        Console.WriteLine("Both dice are the same! Double points awarded!");
                        dieRoll.Item1 *= 2;
                    }

                    if (dieRoll.Item1 == 7)
                    {
                        if (playerOneTurn)
                            playerOneTurn = false;
                        else
                            break; // Game over if player two rolls a 7
                    }
                    else
                    {
                        if (playerOneTurn)
                            playerOneScore += dieRoll.Item1;
                        else
                            playerTwoScore += dieRoll.Item1;

                        Console.WriteLine($"Player One's Score is : {playerOneScore}");
                        Console.WriteLine($"Player Two's Score is : {playerTwoScore}");
                    }

                    playerOneDie.SwapPlayers();
                    playerTwoDie.SwapPlayers();
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected error, please try again!");
                }
            } while (true);

            Console.WriteLine($"Player Two has rolled a 7, game over!");
            Console.WriteLine($"Player One's Score is : {playerOneScore}");
            Console.WriteLine($"Player Two's Score is : {playerTwoScore}");
            Console.ReadLine();
            stats.UpdateStatistics(playerOneScore, playerTwoScore, true, !playerOneTurn); // Pass playerOneRolledSeven as !playerOneTurn
            stats.WriteStatistics(filePath);
        }

        private void SevensOutWithComp(Statistics stats)
        {
            bool playerDone = false; // used to check if player has rolled a sum of 7
            bool computerDone = false; // used to check if 'computer' has rolled a sum of 7

            do
            {
                if (!playerDone)
                {
                    Console.WriteLine("Enter any input to roll the dice:\n");
                    Console.ReadKey(true);

                    var currentPlayer = "Player One";
                    var currentDie = playerOneDie;
                    var dieRoll = currentDie.StartGameSevens();

                    Console.WriteLine($"-------------------\n{currentPlayer} rolled: Sum is = {dieRoll.Item1}\n-------------------");

                    if (dieRoll.Item2 == dieRoll.Item3)
                    {
                        Console.WriteLine("Both dice are the same! Double points awarded!");
                        dieRoll.Item1 *= 2;
                    }

                    if (dieRoll.Item1 == 7)
                    {
                        Console.WriteLine("Sum is 7! User's turn is over.");
                        Console.WriteLine($"User's Score is : {playerOneScore}");
                        playerDone = true;
                    }
                    else
                    {
                        playerOneScore += dieRoll.Item1;
                        Console.WriteLine($"User's Score is : {playerOneScore}");
                    }
                }

                if (!computerDone)
                {
                    Console.WriteLine("Computer's turn:");

                    var currentDie = playerTwoDie;
                    var computerDieRoll = currentDie.StartGameSevens();
                    Console.WriteLine($"-------------------\nThe computer rolled: Sum is = {computerDieRoll.Item1}\n-------------------");

                    if (computerDieRoll.Item2 == computerDieRoll.Item3)
                    {
                        Console.WriteLine("Both dice are the same! Double points awarded!");
                        computerDieRoll.Item1 *= 2;
                    }

                    if (computerDieRoll.Item1 == 7)
                    {
                        Console.WriteLine("Sum is 7! Computer's turn is over.");
                        Console.WriteLine($"Computer's Score is : {playerTwoScore}");
                        computerDone = true;
                    }
                    else
                    {
                        playerTwoScore += computerDieRoll.Item1;
                        Console.WriteLine($"Computer's Score is : {playerTwoScore}");
                    }
                }

            } while (!playerDone || !computerDone); // will run while one OR other is false (have not rolled sum of 7), meaning once BOTH have rolled a sum of 7 it will stop.

            Console.WriteLine($"\nUser's final score is : {playerOneScore}");
            Console.WriteLine($"Computer's final score is : {playerTwoScore}");

            stats.UpdateStatistics(playerOneScore, playerTwoScore, true, true);
            stats.WriteStatistics(filePath);
        }

        public void SevensOutOnePlayer(Statistics stats)
        {
            string userInput;
            do
            {
                Console.WriteLine("Enter any input to roll the dice or enter 'Stop' to exit:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "stop")
                {
                    break;
                }

                try
                {
                    var currentPlayer = "User";
                    var currentDie = playerOneDie;
                    var dieRoll = currentDie.StartGameSevens();

                    Console.WriteLine($"-------------------\n{currentPlayer} rolled: Sum is = {dieRoll.Item1}\n-------------------");

                    if (dieRoll.Item2 == dieRoll.Item3)
                    {
                        Console.WriteLine("Both dies are the same! Double points awarded!");
                        dieRoll.Item1 *= 2;
                    }

                    if (dieRoll.Item1 == 7)
                    {
                        Console.WriteLine("Sum is 7, Game over!");
                        Console.WriteLine($"User's final score is : {playerOneScore}");
                        break;
                    }
                    else
                    {
                        playerOneScore += dieRoll.Item1;
                        Console.WriteLine($"User's Score is : {playerOneScore}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected error, please try again!");
                }
            } while (true);
            stats.UpdateStatistics(playerOneScore, playerTwoScore, false, false); // For single player, playerOneRolledSeven always false
            stats.WriteStatistics(filePath);
        }
    }
}
