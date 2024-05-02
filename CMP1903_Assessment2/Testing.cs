using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Testing
    {

        public void Test() //'Test' Method used for testing dies 
        {
            Statistics testGame = new Statistics(); //Object instantiation, loading "Game" into the testing class.
            Die testDie = new Die();

            for (int i = 0; i < 200; i++)  //For loop to repeatedly test the dice, in this case they are tested 200 times (Rarely runs all 200 though as it will stop once a sum of 7 is detected).
            {
                var testGameResult = testDie.StartGameSevens();  //Starts a game named "testGameResult" within the loop (200 times) in order to test die values.

                Debug.Assert(testGameResult.Item1 >= 2 && testGameResult.Item1 <= 12, "Sum Value is out of expected range");// Check if the sum of the dice is within the expected range (2 to 12)
                Debug.Assert(testGameResult.Item2 >= 1 && testGameResult.Item2 <= 6, "Die Value is out of expected range");// Check if each die value is within the expected range (1 to 6)
                Debug.Assert(testGameResult.Item3 >= 1 && testGameResult.Item3 <= 6, "Die Value is out of expected range");

                // Check if the game stops when the sum of the dice is 7
                if (testGameResult.Item1 == 7)
                {
                    Debug.Assert(testGameResult.Item2 + testGameResult.Item3 == 7, "Game didn't stop when sum is 7");
                    Console.WriteLine("Die sum of 7 detected! Stopping game!");
                    break; // Stop testing once sum of 7 detected
                }
            }
        }
    }
}
