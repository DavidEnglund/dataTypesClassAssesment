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
        // ad a bool to tell if its sorted or not
        private bool sorted = false;

        public ShuffleSorter()
        {
            // can be initilised with no data
        }
        public ShuffleSorter(int[] givenNumbers)
        {
            numbers = new int[givenNumbers.Length];
            //numbers = givenNumbers;
            givenNumbers.CopyTo(numbers, 0);
            sorted = false;
        }

        public int[] GetArray()
        {
            return numbers;
        }
        public int GetCentre()
        {
            return numbers.Length / 2;
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
            sorted = true;
        }
        // a private funtion to switch two numbers using their indexes 
        private void swap(int placeOne, int placeTwo)
        {
            int holder = numbers[placeOne];
            numbers[placeOne] = numbers[placeTwo];
            numbers[placeTwo] = holder;
            sorted = false;
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
            sorted = false;
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
            sorted = true;
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
                           // Debug.WriteLine(numbers[i] + ">==>" + numbers[i + 1] + " --- " + i);
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
            sorted = true;
        }

        // ======================== tests ===========================
        public void OutsideIn()
        {
            // for this I am going to not do a bubble as this is testing the variances of the post sort
            // and I am gonig to kill the debug for every line as I just want the final tally
            // unless there is a problem
            Debug.WriteLine("Outside in sort");
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
                    #endregion
                    // first the lower half
                    if (numbers[i] > numbers[guide])
                    {
                      //  Debug.WriteLine(numbers[i] + "<<<<<" + numbers[guide] + " --- " + i);
                        swap(i, guide);
                        movement = true;
                        comparisonsPost++;
                    }
                    // then the higher
                    if (numbers[numbers.Length - i-1] < numbers[guide])
                    {
                       // Debug.WriteLine(numbers[numbers.Length - i] + ">>>>" + numbers[guide] + " --- " + (numbers.Length - i));
                        swap(numbers.Length - i-1, guide);
                        movement = true;
                        comparisonsPost++;
                    }
                }
            }

            Debug.WriteLine("---=== Post: " + comparisonsPost + " ===---");
            Debug.WriteLine("---=== Bubl: " + comparisonsBubble + " ===---");
            Debug.WriteLine("---=== Totl:  " + (comparisonsPost + comparisonsBubble) + " ===---");
        }

        // ======================== tests ===========================
        public void StartToEnd()
        {
            // for this I am going to not do a bubble as this is testing the variances of the post sort
            // and I am gonig to kill the debug for every line as I just want the final tally
            // unless there is a problem
            Debug.WriteLine("Start to end sort");
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
                    /**/
                    #endregion
                    // first the lower half
                    if (numbers[i] > numbers[guide])
                    {
                        //  Debug.WriteLine(numbers[i] + "<<<<<" + numbers[guide] + " --- " + i);
                        swap(i, guide);
                        movement = true;
                        comparisonsPost++;
                    }
                    // then the higher
                    if (numbers[i + guide] < numbers[guide])
                    {
                        //Debug.WriteLine(numbers[i + guide] + ">>>>" + numbers[guide] + " --- " + (i + guide));
                        swap(i + guide, guide);
                        movement = true;
                        comparisonsPost++;
                    }
                }
            }

            Debug.WriteLine("---=== Post: " + comparisonsPost + " ===---");
            Debug.WriteLine("---=== Bubl: " + comparisonsBubble + " ===---");
            Debug.WriteLine("---=== Totl:  " + (comparisonsPost + comparisonsBubble) + " ===---");
        }

        // ======================== tests ===========================
        public void InsideOut()
        {
            // for this I am going to not do a bubble as this is testing the variances of the post sort
            // and I am gonig to kill the debug for every line as I just want the final tally
            // unless there is a problem
            Debug.WriteLine("Inside out sort");
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
                    /**/
                    #endregion
                    // first the lower half
                    if (numbers[guide-i] > numbers[guide])
                    {
                        //  Debug.WriteLine(numbers[i] + "<<<<<" + numbers[guide] + " --- " + i);
                        swap(guide - i, guide);
                        movement = true;
                        comparisonsPost++;
                    }
                    // then the higher
                    if (numbers[i + guide] < numbers[guide])
                    {
                        //Debug.WriteLine(numbers[i + guide] + ">>>>" + numbers[guide] + " --- " + (i + guide));
                        swap(i + guide, guide);
                        movement = true;
                        comparisonsPost++;
                    }
                }
            }

            Debug.WriteLine("---=== Post: " + comparisonsPost + " ===---");
            Debug.WriteLine("---=== Bubl: " + comparisonsBubble + " ===---");
            Debug.WriteLine("---=== Totl:  " + (comparisonsPost + comparisonsBubble) + " ===---");
        }

        // here I am gonig to try and do it just with the goudepost
        public void GuideOnly()
        {
            int divider = 2; // this will divide by 2 then 4 the n8 etc untill the sum is three or less
            int fraction = (numbers.Length-1) / divider; // this is the length of a fraction of the array length
            int[] currentPosts = new int[] { (numbers.Length-1)/divider }; // this is all the guideposts that we will loop though
            int offset = currentPosts[0]; // this is how far from the post to check from - I am doing it this way becasue rounding wont get everything and ciling causes out of bounds errors
            int[] newPosts = new int[divider / 2]; // this is all the guideposts that we will loop though
            bool swapMade = true;
            int passes = 0;  // the pass count
            int comparisonsPost = 0; // the number of swaps made

            // now to go though untill the fraction is less than three
            while (fraction >= 1)
            {
                swapMade = true; 
                Debug.WriteLine("---=== frac: " + fraction + " ===---");
                // the main event so to speak
                while (swapMade)
                {
                    Debug.WriteLine("---=== pass: " + passes + " ===---");
                    passes++;
                    swapMade = false;
                    // looping though each guidepost we currentley have
                    foreach (int guidepost in currentPosts)
                    {
                        Debug.WriteLine("---=== guid: " + guidepost + " ===---");
                        for (int i = 0; i < fraction; i++)
                        {
                            int lowside = (guidepost - fraction);
                            int highside = guidepost + i;

                            // check the lowside then the highside of the guide
                            if (lowside >= 0)
                            {
                                if (numbers[lowside] > numbers[guidepost])
                                {
                                    swap(lowside, guidepost);
                                    swapMade = true;
                                    comparisonsPost++;
                                    Debug.WriteLine(numbers[lowside] + "<<<<<" + numbers[guidepost] + " --- " + lowside);
                                }
                            }
                            if (highside < numbers.Length)
                            {
                                if (numbers[highside] < numbers[guidepost])
                                {
                                    swap(highside, guidepost);
                                    swapMade = true;
                                    comparisonsPost++;
                                    Debug.WriteLine(numbers[highside] + ">>>>" + numbers[guidepost] + " --- " + highside);
                                }
                            }
                        } // that each check done for that guide
                    }// all of the guideposts have been checked
                }// and now it has no more swaps to be made so all of the lower half is in there and vice versa for higher

                // getting the next set of guideposts
                newPosts = new int[divider];
                divider = divider * 2;
                fraction = (int)Math.Ceiling( ((double)numbers.Length-1) / divider);

                int k = 0;// this is th count for the new posts array
                for (int j = 0; j < currentPosts.Length; j++)
                {
                    newPosts[k] = currentPosts[j] - fraction;
                    k++;
                    newPosts[k] = currentPosts[j] + fraction;
                    k++;
                }
                // now to set current to new
                currentPosts = newPosts;
                if (currentPosts[0] <= 0) {
                    currentPosts[0] = 0; }
                offset = currentPosts[0];
                
                Debug.WriteLine(currentPosts[1] + "-----------");
            }// ends when fraction is three or less
            Debug.WriteLine("---=== Post: " + comparisonsPost + " ===---");
            sorted = true;
        }


        /// <summary>
        /// does a binary search of the array looking for you chosen value. returns the array positions it's in.
        /// -1 is not found.
        /// -2 is not sorted.
        /// </summary>
        /// <param name="lookingFor"></param>
        /// <returns></returns>
        public int BinarySearch(int lookingFor)
        {
            if (sorted)
            {
                int low = 0;
                int high = numbers.Length-1;
                while (low <= high)
                {
                    int lookingAt = (low + high) / 2;
                    if(numbers[lookingAt] == lookingFor)
                    {
                        return lookingAt;
                    }
                    else
                    {
                        if(numbers[lookingAt] > lookingFor)
                        {
                            high = lookingAt-1;
                        }
                        else
                        {
                            low = lookingAt+1;
                        }
                    }
                    Debug.WriteLine("low: " + low + " mid: " + lookingAt + " high: " + high);
                }   
                // not found error
                return -1;
            }
            else
            {
                // not sorted error
                return -2;
            }
        }

        // well the guide only failed so I am going to try copying the binary search technique and seeing if that even works
        // works but is slow - will try something i think will work better
        public void BinarySort()
        {
            bool swapped = true;
            int swapcount = 0;
            int current = 0;
            while (swapped)
            {
                swapped = false;
                for (current = 0; current < numbers.Length; current++)
                {
                    int low = 0;
                    int high = numbers.Length - 1;
                    while (low <= high)
                    {
                        int Pivot = (low + high) / 2;
                        if (Pivot == current)
                        {
                            Debug.WriteLine(" well now what? " + Pivot + " : " + numbers[current]);
                            break;
                        }
                        else
                        {
                            if (Pivot > current)
                            {
                                high = Pivot - 1;
                                if (numbers[Pivot] < numbers[current])
                                {
                                    swap(Pivot, current);
                                    Debug.WriteLine("swapped[" + Pivot + "]=" + numbers[Pivot] + " << [" + current + "]=" + numbers[current]);
                                    swapped = true;
                                    swapcount++;
                                }
                            }
                            else
                            {
                                low = Pivot + 1;
                                if (numbers[Pivot] > numbers[current])
                                {
                                    swap(Pivot, current);
                                    Debug.WriteLine("swapped[" + Pivot + "]=" + numbers[Pivot] + " >> [" + current + "]=" + numbers[current]);
                                    swapped = true;
                                    swapcount++;
                                }
                            }
                        }
                        Debug.WriteLine("low: " + low + " mid: " + Pivot + " high: " + high);
                    }
                }
            }
            Debug.WriteLine("Swapcount: " + swapcount);
        }
        public void BinarySortTwo()
        {
            bool swapped = true;
            int low = 0;
            int high = numbers.Length-1;
            int pivot = (low + high) / 2; ;
            while (low <= high)
            {

                pivot = (low + high) / 2;
                swapped = true;
                while (swapped)
                {
                    swapped = false;
                    for (int i = low; i <= pivot; i++)
                    {
                        if (numbers[i] > numbers[pivot])
                        {
                            swap(i, pivot);
                            swapped = true;
                            Debug.WriteLine("swapped[" + pivot + "]=" + numbers[pivot] + " >> [" + i + "]=" + numbers[i]);
                        }
                        if (numbers[high - i] < numbers[pivot])
                        {
                            swap(high - i, pivot);
                            swapped = true;
                            Debug.WriteLine("swapped[" + pivot + "]=" + numbers[pivot] + " >> [" + (high - i) + "]=" + numbers[high - i]);
                        }
                    }
                    Debug.WriteLine("low: " + low + " mid: " + pivot + " high: " + high);
                    
                }
                high = pivot - 1;
            }

        }
        // going to try recursive in the am
    }
}
