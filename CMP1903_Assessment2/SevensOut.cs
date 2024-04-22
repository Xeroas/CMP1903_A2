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
        string filePath = @"C:\Users\JackT\OneDrive\Desktop\OOP ASS\CMP1903-OOP-AS2\CMP1903_Assessment2\game_stats.txt";

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

        public void SevensOutTwoPlayer(Statistics stats)
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
                    var currentPlayer = playerOneTurn ? "Player One" : "Player Two";
                    var currentDie = playerOneTurn ? playerOneDie : playerTwoDie;
                    var dieRoll = currentDie.StartGameSevens();

                    Console.WriteLine($"-------------------\n{currentPlayer} rolled: Sum is = {dieRoll.Item1}\n-------------------");

                    if (dieRoll.Item2 == dieRoll.Item3)
                    {
                        Console.WriteLine("Both dies are the same! Double points awarded!");
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
                        Console.ReadLine(); //temp remove later
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
