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
            myNumbers.CreateEscalating(12, 160);
            // now lets list those number and see what we get
            foreach (int number in myNumbers.GetArray())
            {
                lblNumberList.Text += number + " , ";
            }

            // now lets shuffle and display the shuffled array
            myNumbers.Shuffle();
            foreach (int number in myNumbers.GetArray())
            {
                lblShuffledList.Text += number + " , ";
            }

        }

        // this function will create a random escalating array
        
    }
}
