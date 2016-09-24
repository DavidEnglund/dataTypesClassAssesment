using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 ShulffleSorter has functions to create random number arrays and shuffle and sort those arrays.
 function list:
 variabels
 Intit
 init overloads
 get array
createArray
shuffle




*/

namespace BinaryTree
{
    /// <summary>
    /// ShulffleSorter has functions to create random number arrays and shuffle and sort those arrays.
    /// </summary>
    class ShuffleSorter
    {
        // we will need an array of int to shuffle and sort and evreything else
        private int[] numbers;

        public ShuffleSorter()
        {
            // can be initilised with no data
        }
        public ShuffleSorter(int[] givenNumbers)
        {
            numbers = givenNumbers;
        }

        public int[] GetArray()
        {
            return numbers;
        }
        /// <summary>
        /// creates an ineger array with random escalting(going up) values using a method to prefer mid range numbers
        /// </summary>
        /// <param name="variance"> how much possible distance between numbers</param>
        /// <param name="count"> the size of the array</param>
        public void CreateEscalating(int variance, int count)
        {
            int[] escalating = new int[count];
            int current = 0;
            Random generator = new Random();

            for (int i =0;i<count;i++)
            {
                current += 1+((generator.Next(variance) + generator.Next(variance))/2);
                escalating[i] = current;
            }
            numbers = escalating;
        }

        /// <summary>
        /// shuffle the array by switching random places by the amount of times given
        /// </summary>
        /// <param name="amount">amount of times to perfrom a switch</param>
       public void Shuffle(int amount)
        {
            Random generator = new Random();
            for (int i=0; i <= amount; i++)
            {
                // first get two random places
                int placeOne = generator.Next(numbers.Length);
                int placeTwo = generator.Next(numbers.Length);
                // then save the first place, set the 1st to the 2nd, then the 2nd to the saved 1st
                int holder = numbers[placeOne];
                numbers[placeOne] = numbers[placeTwo];
                numbers[placeTwo] = holder;
            }
        }

        // and a default that will do it by double what it has - not so good but so what?
        public void Shuffle()
        {
            Shuffle(numbers.Length * 2);
        }

    }
}
