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
        // create the array sorter 
        ShuffleSorter myNumbers = new ShuffleSorter();

        public SearchAndSort()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            // lets run the arrary createor here
            myNumbers.CreateEscalating(12, 60);
            // now lets list those number and see what we get
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += number + " , ";
            }
            // list the array as it was when created
            lblNumberList.Text = "Original array: ";
            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += "[" + counter + "]=";
                lblNumberList.Text += number + "  , ";
                counter++;
            }
        }
        // this will run the search and display where in the array the data is - or an error message
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
        // this will shuffle the array and display the shuffled array below the original
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
        // this will sort the array with binary pivot sort and display the sorted below the original for comparision
        public void btnSort_click(object sender, EventArgs e)
        {
            myNumbers.BinarySort();
            
            lblShuffledList.Text = "Sorted with binary pivot sort: ";
            
            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += "[" + counter + "]=";
                lblShuffledList.Text += number + " , ";
                counter++;
            }
            myNumbers.BubbleSort();
        }
        // this will sort the array with bubble sort and display the sorted below the original for comparision
        public void btnBubble_click(object sender, EventArgs e)
        {
            myNumbers.BubbleSort();

            lblShuffledList.Text = "Sorted with bubble sort: ";

            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += "[" + counter + "]=";
                lblShuffledList.Text += number + " , ";
                counter++;
            }
           
        }
        // this will sort the array with tree sort and display the sorted below the original for comparision
        public void btnTree_click(object sender, EventArgs e)
        {
            myNumbers.TreeSort();

            lblShuffledList.Text = "Sorted with tree sort: ";

            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += "[" + counter + "]=";
                lblShuffledList.Text += number + " , ";
                counter++;
            }
            
        }
        // this will generate a new array sized to the number inputted and list it as the new original
        public void btnSize_click(object sender, EventArgs e)
        {
            int arraySize = 0;
            int.TryParse(entNumber.Text, out arraySize);
            myNumbers.CreateEscalating(12,arraySize);
            lblNumberList.Text = "Original array: ";
            int counter = 0;
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += "[" + counter + "]=";
                lblNumberList.Text += number + "  , ";
                counter++;
            }

        }
        // navigaition buttons
        private void btnTreeAndList_click(object sender,EventArgs e)
        {
            Navigation.PushAsync(new TreeAndList());
        }
        private void btnHash_click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HashTableView());
        }
    }
}
