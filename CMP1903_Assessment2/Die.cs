using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */

        /// <summary>
        /// The "Die" class is responsible for defining the Die and assigning it a random value within the range 1-6. 
        /// this is done with the help of the "Roll" method which generates the die values within the expected range.
        /// </summary>


        //Property
        private int _dieCurVal; //Private variable created to hold the current value of the die privately (Encapsulated).

        public int pubCurVal
        {
            get => _dieCurVal; //Encapsulation of "_dieCurVal"
            set { _dieCurVal = value; }
        }
        private static Random _randNum = new Random(); //Private "random" variable created, set to static to stop overlapping die values.
        private bool _playerSwap = false; //When true players swap


        public int Roll() //"Roll" Method responsible for rolling the die and returning a value within the expected range (1-6)
        {
            pubCurVal = _randNum.Next(1, 7); //Generates number from 1 to 6 (7 Is not included)
            return pubCurVal; //Returns the randomly (Within range of 1-6) generated die value
        }
        public (int, int, int) StartGameSevens() //"StartGame" Method responsible for rolling the dies, summing them and returning the sum along with die values.
        {
            int roll1 = Roll(); //Roll the dies using the "Roll" method from "Die" class.
            int roll2 = Roll();
            int sum = roll1 + roll2; //Summing of the three dies.
            Console.WriteLine($"Die 1 = {roll1} \nDie 2 = {roll2} \n"); //Output Die values (User readable)

            if (sum == 7)
            {
                Console.WriteLine("game over / player swap");
                _playerSwap = true; // When true players swap
            }

            return (sum, roll1, roll2); //Returning the sum of the dies, and the individual die values.
        }
        public bool SwapPlayers()
        {
            return _playerSwap;
        }
    }
}
