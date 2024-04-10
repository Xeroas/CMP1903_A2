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
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        /// <summary>
        ///This class contains the "Test" method which is responsible for testing the die values generated in "Die" using the "Roll" method,
        ///the class tests the Sum of all the die and also tests the three individual dies generated to ensure they are within the expected range.
        /// </summary>

        public void Test() //'Test' Method used for testing dies 
        {
            Game testGame = new Game(); //Object instantiation, loading "Game" into the testing class.

            for (int i = 0; i < 1000; i++)  //For loop to repeatedly test the dies, in this case they are tested 1000 times.
            {
                var testGameResult = testGame.StartGame();  //Starts a game named "testGameResult" within the loop (1000 times) in order to test die values.

                Debug.Assert(testGameResult.Item1 >= 2 && testGameResult.Item1 <= 12, "Sum Value is out of expected range"); //Checks the sum of the three dies is no less than 3 and no more than 18.
                Debug.Assert(testGameResult.Item2 >= 1 && testGameResult.Item2 <= 6, "Die Value is out of expected range"); //Checks that the value of Die 1 is no less than 1 and no more than 6
                Debug.Assert(testGameResult.Item3 >= 1 && testGameResult.Item3 <= 6, "Die Value is out of expected range");

            }
        }
    }
}
