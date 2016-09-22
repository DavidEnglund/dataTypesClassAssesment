using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BinaryTree
{

    public partial class HashTableView : ContentPage
    {
        private HashTable sample = new HashTable();
        private List<string> addedKeys = new List<string>();

        public HashTableView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            string[] HashOne = new string[]
            {
                "Friendly",
                "Understanding",
                "Caring",
                "Kind"
            };
            string[] HashTwo = new string[]
            {
                "Seamless",
                "Hidden",
                "Invisible",
                "Transparent"
            };
            string[] HashThree = new string[]
            {
                "Common",
                "Utilitarian",
                "Normal",
                "Typical"
            };
            string[] HashFour = new string[]
            {
                "Arrest",
                "Remand",
                "Stop",
                "End"
            };
            // ok now lets add some strings to the hash table
            lblKeyList.Text = "Keys: \r\n";
            lblDataList.Text = "Data: \r\n";
            for (int i = 0; i < HashOne.Length; i++)
            {
                sample.addEntry(HashOne[i], HashTwo[i]);
                sample.addEntry(HashThree[i], HashFour[i]);

                lblKeyList.Text += HashOne[i] + "\r\n";
                lblDataList.Text += HashTwo[i] + "\r\n";

                lblKeyList.Text += HashThree[i] + "\r\n";
                lblDataList.Text += HashFour[i] + "\r\n";
                // adding all of the keys to a list as we add them
                addedKeys.Add(HashOne[i]);
                addedKeys.Add(HashThree[i]);
            }
            // getting the key list
            lblHashList.Text = "Hashes: \r\n";
            foreach (int key in sample.GetHashs())
            {
                lblHashList.Text += key + "\r\n";
            }

            // getting the data back out of the hash table
            lblRetrivedList.Text = "Retrived: \r\n";
            for (int i = 0; i < HashOne.Length; i++)
            {
                lblRetrivedList.Text += sample.GetEntry(HashOne[i]) + "\r\n";
                lblRetrivedList.Text += sample.GetEntry(HashThree[i]) + "\r\n";
            }

        }

        // code for the add button to add a key/value pair
        private void btnAdd_click(object s, EventArgs e)
        {
            sample.addEntry(entKey.Text, entData.Text);

            lblKeyList.Text += entKey.Text + "\r\n";
            lblDataList.Text += entData.Text + "\r\n";

            addedKeys.Add(entKey.Text);
        }

        // code for the refresh button to refresh the list of retrived data and keys
        private void btnRefresh_click(object s, EventArgs e)
        {
            // getting the key list
            lblHashList.Text = "Hashes: \r\n";
            foreach (int key in sample.GetHashs())
            {
                lblHashList.Text += key + "\r\n";
            }

            // getting the data back out of the hash table
            lblRetrivedList.Text = "Retrived: \r\n";
            foreach (string key in addedKeys)
            {
                lblRetrivedList.Text += sample.GetEntry(key) + "\r\n";

            }

        }
    }
}
