using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        /// <summary>
        /// The "Game" class contains the code relevant for generating the die game, in this case that is the instantiation and rolling of the three dies
        /// along with summing of their values. The method "StartGame" which is responsible for rolling the dies and summing them returns the die values and their sum.
        /// </summary> 

        Die die1 = new Die(); //Dies are instantiated here.
        Die die2 = new Die();
        public (int, int, int) StartGame() //"StartGame" Method responsible for rolling the dies, summing them and returning the sum along with die values.
        {
            int roll1 = die1.Roll(); //Roll the dies using the "Roll" method from "Die" class.
            int roll2 = die2.Roll();
            int sum = roll1 + roll2; //Summing of the three dies.
            Console.WriteLine($"Die 1 = {roll1} \nDie 2 = {roll2} \n"); //Output Die values (User readable)

            return (sum, roll1, roll2); //Returning the sum of the dies, and the individual die values.
        }
    }
}
