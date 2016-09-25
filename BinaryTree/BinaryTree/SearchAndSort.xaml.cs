using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BinaryTree
{
    public partial class SearchAndSort : ContentPage
    {
        public SearchAndSort()
        {
            InitializeComponent();
            // create the array sorter 
            ShuffleSorter myNumbers = new ShuffleSorter();

            // lets run the arrary createor here
            myNumbers.CreateEscalating(12, 60);
            // now lets list those number and see what we get
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += number + " , ";
            }

            // now lets shuffle and display the shuffled array
            myNumbers.Shuffle();
            // a new exact copy to perfrom a stright bubble on
            ShuffleSorter bubNumber = new ShuffleSorter(myNumbers.GetArray());
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += number + " , ";
            }


            // ok so a test of the guidepost sort - I dont think on its own it will work but it should drasitcly cut down a followed bubble sort
            //myNumbers.GuidepostSort();
            // ================== tests ===================
            // these will run and not display anything - I'll undo the commenting out of above after tests
            myNumbers.GuidepostSort();
            bubNumber.GuideOnly();
           // myNumbers.StartToEnd();
           // myNumbers.BubbleSort();
            
            lblNumberList.Text = "start to end ";
            foreach (int number in myNumbers.GetArray())
            {
                if(number == myNumbers.GetArray()[myNumbers.GetCentre()])
                {
                    lblNumberList.Text += "-->";
                }
                lblNumberList.Text += number + " , ";
            }
            lblShuffledList.Text = "outside in ";
            int counter = 0;
            foreach (int number in bubNumber.GetArray())
            {
                if (number == bubNumber.GetArray()[bubNumber.GetCentre()])
                {
                    lblShuffledList.Text += "-->";
                }
                lblShuffledList.Text += "[" + counter + "]=";
                lblShuffledList.Text += number + " , ";
                counter++;
            }
            // bubNumber.BubbleSort();


        }

        // this function will create a random escalating array
        
    }
}
