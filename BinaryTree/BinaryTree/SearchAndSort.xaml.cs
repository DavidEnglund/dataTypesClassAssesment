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
        ShuffleSorter myNumbers = new ShuffleSorter();
        public SearchAndSort()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            // create the array sorter 
            

            // lets run the arrary createor here
            myNumbers.CreateEscalating(12, 92);
            // now lets list those number and see what we get
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += number + " , ";
            }

            // now lets shuffle and display the shuffled array
            //myNumbers.Shuffle(1);
            // a new exact copy to perfrom a stright bubble on
            ShuffleSorter bubNumber = new ShuffleSorter(myNumbers.GetArray());
            /*
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += number + " , ";
            }
            */

            // ok so a test of the guidepost sort - I dont think on its own it will work but it should drasitcly cut down a followed bubble sort
            //myNumbers.GuidepostSort();
            // ================== tests ===================
            // these will run and not display anything - I'll undo the commenting out of above after tests
            //myNumbers.BubbleSort();
            //bubNumber.GuideOnly();
           // myNumbers.StartToEnd();
           // myNumbers.BubbleSort();
            
            lblNumberList.Text = "Original array: ";
            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += "[" + counter + "]=";
                lblNumberList.Text += number + "  , ";
                counter++;
            }

            /*
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
            */

        }
        public void btnFind_click(object sender, EventArgs e)
        {
            int lookFor;
            int found = -3 ;
            if (int.TryParse(entNumber.Text, out lookFor))
            {
                found = myNumbers.BinarySearch(lookFor);
            }
            else
            {
                DisplayAlert("bad input", "Please put a number in the search entry", "OK");
            }
            if(found == -1)
            {
                DisplayAlert("Search", "Not Found", "OK");
            }
            if (found == -2)
            {
                DisplayAlert("Search", "Please sort array first", "OK");
            }
            if (found>=0)
            {
                DisplayAlert("Search", "Found at: " + found, "OK");
            }


        }

        public void btnShuffle_click(object sender,EventArgs e)
        {
            myNumbers.Shuffle();
            lblShuffledList.Text = "Shuffled: ";
            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += "[" + counter + "]=";
                lblShuffledList.Text += number + " , ";
                counter++;
            }
        }

        public void btnSort_click(object sender, EventArgs e)
        {
            myNumbers.GuideOnly();
            lblShuffledList.Text = "Sorted with binary pivot sort: ";
            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += "[" + counter + "]=";
                lblShuffledList.Text += number + " , ";
                counter++;
            }
        }
    }
}
