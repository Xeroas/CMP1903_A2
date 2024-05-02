using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Statistics
    {
        string filePath = @"C:\Users\JackT\OneDrive\Desktop\OOP ASS\CMP1903-OOP-AS2\CMP1903_Assessment2\game_stats.txt"; //hardcoded file location, for testing purposes create .txt file and replace this file path with /your/ one.
        private int _onePlayerHighScore;
        private int _twoPlayerHighScore;
        private int _onePlayerGameCount;
        private int _twoPlayerGameCount;

        public int OnePlayerHighScore => _onePlayerHighScore; //Encapsulation
        public int TwoPlayerHighScore => _twoPlayerHighScore;
        public int OnePlayerGameCount => _onePlayerGameCount;
        public int TwoPlayerGameCount => _twoPlayerGameCount;

        public Statistics() //Statistics class constructor
        {
            LoadStatistics(filePath); //Load statistics from file when 'statistics' is constructed
        }

        public void UpdateStatistics(int playerOneScore, int playerTwoScore, bool isTwoPlayer, bool playerOneRolledSeven) //Method to update statistics so it can later be written to file (Ensuring written data is correct)
        {
            if (isTwoPlayer)
            {
                if (playerTwoScore > _twoPlayerHighScore)
                {
                    _twoPlayerHighScore = playerTwoScore;
                }
                if (playerOneScore > _twoPlayerHighScore)
                {
                    _twoPlayerHighScore = playerOneScore;
                }
            }
            else
            {
                if (playerOneScore > _onePlayerHighScore && !playerOneRolledSeven) // Update high score only if player did not roll a seven (Seven not included within score as it is indictor to stop game)
                {
                    _onePlayerHighScore = playerOneScore;
                }
            }

            WriteStatistics(filePath);
        }

        public void DisplayStatistics()
        {
            Console.WriteLine($"\nOne Player Games Played: {_onePlayerGameCount}");
            Console.WriteLine($"One Player High Score: {_onePlayerHighScore}");
            Console.WriteLine($"Two Player Games Played: {_twoPlayerGameCount}");
            Console.WriteLine($"Two Player High Score: {_twoPlayerHighScore}\n");
        }

        private void LoadStatistics(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim().ToLower();
                            string value = parts[1].Trim();

                            if (key == "one player high score")
                            {
                                int.TryParse(value, out _onePlayerHighScore);
                            }
                            else if (key == "two player high score")
                            {
                                int.TryParse(value, out _twoPlayerHighScore);
                            }
                            else if (key == "one player games played")
                            {
                                int.TryParse(value, out _onePlayerGameCount);
                            }
                            else if (key == "two player games played")
                            {
                                int.TryParse(value, out _twoPlayerGameCount);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading statistics from file, please ensure it currently exists.");
            }
        }

        public void WriteStatistics(string filePath)
        {
            try
            {
                string[] lines = {
                    $"One Player Games Played: {_onePlayerGameCount}",
                    $"One Player High Score: {_onePlayerHighScore}",
                    $"Two Player Games Played: {_twoPlayerGameCount}",
                    $"Two Player High Score: {_twoPlayerHighScore}"
                };
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Statistics successfully updated.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error writing statistics to file, please try again.");
            }
        }

        public void IncreaseGameCount(bool isTwoPlayer)
        {
            if (isTwoPlayer)
            {
                _twoPlayerGameCount++;
            }
            else
            {
                _onePlayerGameCount++;
            }

            WriteStatistics(filePath);
        }
    }
}
