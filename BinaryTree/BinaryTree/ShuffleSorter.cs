using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
            numbers = new int[givenNumbers.Length];
            //numbers = givenNumbers;
            givenNumbers.CopyTo(numbers, 0);
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
        // a private funtion to switch two numbers using their indexes 
        private void swap(int placeOne, int placeTwo)
        {
            int holder = numbers[placeOne];
            numbers[placeOne] = numbers[placeTwo];
            numbers[placeTwo] = holder;
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
                swap(placeOne, placeTwo);
            }
        }        

        // and a default that will do it by double what it has - not so good but so what?
        public void Shuffle()
        {
            Shuffle(numbers.Length * 2);
        }

        // this is going to have interesting logic and I dont know how well it will work but I want to try it and see
        // this is going to take the center of the array as a guidepost and for the lower hafe check if a number is higher 
        // then switch if so and for the upper half check if lower.
        // I am going to do the go though both halfs at once because I think it will cut down on comparision to do so
        public void GuidepostSort()
        {
            int guide = numbers.Length / 2;
            bool movement = true;
            int passes = 0;
            int comparisonsPost = 0;
            int comparisonsBubble = 0;


            while (movement)
            {
                movement = false;
                passes++;
                Debug.WriteLine("---=== pass " + passes + " ===---");
                for (int i = 0; i < guide; i++)
                {
                    // and now for the bubble
                    #region bubble in guidepost
                    // lower first again 
                    if (numbers[i] > numbers[i + 1])
                    {
                        swap(i, i + 1);
                        movement = true;
                        Debug.WriteLine(numbers[i] + ">==>" + numbers[i + 1] + " --- " + i);
                        comparisonsBubble++;

                    }

                    //then higher
                    if (i + guide + 1 < numbers.Length)
                    {
                        if (numbers[i + guide] > numbers[i + guide + 1])
                        {
                            swap(i + guide, i + guide + 1);
                            movement = true;
                            Debug.WriteLine(numbers[i + guide] + ">==>" + numbers[i + guide + 1] + " --- " + (i + guide));
                            comparisonsBubble++;
                        }
                    }
                    #endregion

                    // first the lower half
                    if (numbers[i] > numbers[guide])
                    {
                        Debug.WriteLine(numbers[i] + "<<<<<" + numbers[guide] + " --- " + i);
                        swap(i, guide);
                        movement = true;
                        comparisonsPost++;

                    }
                    // then the higher
                    if (numbers[i + guide] < numbers[guide])
                    {
                        Debug.WriteLine(numbers[i + guide] + ">>>>" + numbers[guide] + " --- " + (i + guide));
                        swap(i + guide, guide);
                        movement = true;
                        comparisonsPost++;
                    }


                    // and now to add a bubble sort to this guidepost

                }
            }

            Debug.WriteLine("---=== Post: " + comparisonsPost + " ===---");
            Debug.WriteLine("---=== Bubl: " + comparisonsBubble + " ===---");
            Debug.WriteLine("---=== Totl:  " + (comparisonsPost + comparisonsBubble) + " ===---");
        }

        // and a bubble sort to compare
        public void BubbleSort()
        {
            int guide = numbers.Length / 2;
            bool movement = true;
            int passes = 0;
            
            int comparisonsBubble = 0;


            while (movement)
            {
                movement = false;
                passes++;
                Debug.WriteLine("---=== pass " + passes + " ===---");
                for (int i = 0; i < numbers.Length; i++)
                {
                    // and now for the bubble
                    #region bubble in guidepost
                    // lower first again 
                    if (i + 1 < numbers.Length)
                    {
                        if (numbers[i] > numbers[i + 1])
                        {
                            swap(i, i + 1);
                            movement = true;
                            Debug.WriteLine(numbers[i] + ">==>" + numbers[i + 1] + " --- " + i);
                            comparisonsBubble++;

                        }
                    }

                    /*
                    //then higher
                    if (i + guide + 1 < numbers.Length)
                    {
                        if (numbers[i + guide] > numbers[i + guide + 1])
                        {
                            swap(i + guide, i + guide + 1);
                            movement = true;
                            Debug.WriteLine(numbers[i + guide] + ">==>" + numbers[i + guide + 1] + " --- " + (i + guide));
                            comparisonsBubble++;
                        }
                    }
                    */
                    #endregion
                    
                    //Debug.WriteLine("---=== Totl:  " + (comparisonsPost + comparisonsBubble) + " ===---");
                }
            }
            Debug.WriteLine("---=== Bubl: " + comparisonsBubble + " ===---");
        }

    }
}
