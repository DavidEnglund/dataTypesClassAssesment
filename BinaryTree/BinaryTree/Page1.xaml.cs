using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

// this app will show off a binary tree and doule linked list
// I know that it could be very memory intensive with a large dataset
// due to the way it runs the left,right and straight iterations
// unless c# or whatever is good at referanceing and keeping the memory
// to a minimun
namespace BinaryTree
{
    public partial class Page1 : ContentPage
    {
        // we will need a binary tree and a dbl link list
        BinTree myTree = new BinTree(500, "Trunk");
        dblLinked nodeList = new dblLinked("start");
        // and a dbl link list of saved keys to demonstrate adding and editing a dbl link list
        dblLinked saveList = new dblLinked();
        public Page1()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            

            // lests setup some random nodes
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                myTree.addNode(rnd.Next(1, 1001), "random node");
                //nodeList.addToEnd(i + " added node"); // add a node to a test dbl link list
            }
            // now lets clear to log to make it easier to see wht I do
            myTree.clearLog();
            // creating the straight iteration list
            nodeList = myTree.straightItr();
            nodeList.goToStart();
            lblLink.Text = nodeList.getData().ToString();
        }
        public void addKey_click(object sender, EventArgs e)
        {
            //lblKey.Text = "clicked";
            // ok lets add a node to the tree
            // lets get the inputs from user
            string newData = txtData.Text;
            int newNumber = int.Parse(txtKey.Text);
            //ok thats got the input now lets go ahead and shove it it wherever it fits :)
            myTree.addNode(newNumber, newData);
            // and finaly show the log
           // lblLog.Text = myTree.getLog();

        }

        // and now for something compltely... lets just find it
        public void findKey_click(object sender, EventArgs e)
        {
            // how to do an alert or toast or something like that
            //DisplayAlert("find key", "key found", "go away");
            // like that aparently
            TreeNode foundNode = myTree.findNode(int.Parse(txtKey.Text));
            if (foundNode != null)
            {
                DisplayAlert("node found", foundNode.ToString(), "Okay");
            }
            else
            {
                DisplayAlert("node found", "no node found", "Okay");
            }
        }
        // the delete button click
        public void btnDelete_click(object sender,EventArgs e)
        {
            TreeNode foundNode = myTree.findNode(int.Parse(txtKey.Text));
            if (foundNode != null)
            {
                DisplayAlert("node deleted", foundNode.ToString(), "Okay");
                myTree.deleteNode(int.Parse(txtKey.Text));
            }
            else
            {
                DisplayAlert("cant delete", "no node found", "Okay");
            }
        }
        // the save button
        public void btnSave_click(object sender, EventArgs e)
        {
            TreeNode foundNode = myTree.findNode(int.Parse(txtKey.Text));
            if (foundNode != null)
            {
                DisplayAlert("node Saved", foundNode.ToString(), "Okay");
                saveList.addToEnd(foundNode);
                lblSaveList.Text = saveList.getData().ToString();
            }
            else
            {
                DisplayAlert("cant save", "no node found", "Okay");
            }
        }
        // #################################### iteration buttons #####################
        // left side iteration button
        public void btnLeft_click(object sender, EventArgs e)
        {
          //  myTree.clearLog();
           // lblLog.Text = myTree.fromLowest();
            // creating the straight iteration list
            nodeList = myTree.fromLowest();
            // go to the start of the list
            nodeList.goToStart();
            //display that list item in the label
            lblLink.Text = nodeList.getData().ToString();
            //change the label above the link list display to say straight iteration
            lblIteration.Text = "Left Side Iteration";
        }
        // straight ineration button
        public void btnStraight_click(object sender, EventArgs e)
        {
            // creating the straight iteration list
            nodeList = myTree.straightItr();
            // go to the start of the list
            nodeList.goToStart();
            //display that list item in the label
            lblLink.Text = nodeList.getData().ToString();
            //change the label above the link list display to say straight iteration
            lblIteration.Text = "Straight Iteration";

        }
        // right side iteration button
        public void btnRight_click(object sender, EventArgs e)
        {
            //myTree.clearLog();
            //lblLog.Text = myTree.fromHighest().ToString();
            // creating the straight iteration list
            nodeList = myTree.fromHighest();
            nodeList.goToStart();
            lblLink.Text = nodeList.getData().ToString();
            //change the label above the link list display to say right side iteration
            lblIteration.Text = "Right Side Iteration";

        }
        // dbl link list buttons
        public void btnLinkLeft_click(object sender,EventArgs e)
        {
           // DisplayAlert("node found", nodeList.isLeft().ToString(), "Okay");
            if (nodeList.isLeft())
            {
                nodeList.goLeft();
                lblLink.Text = nodeList.getData().ToString();
            }
            else
            {
                DisplayAlert("", "start of list", "OK");
            }
        }

        public void btnLinkRight_click(object sender, EventArgs e)
        {
         //   DisplayAlert("node found", nodeList.isRight().ToString(), "Okay");
            if (nodeList.isRight())
            {
                nodeList.goRight();
                lblLink.Text = nodeList.getData().ToString();

            }
            else
            {
                DisplayAlert("", "end of list", "OK");
            }
        }

        // the saved list buttons
        public void btnSaveLeft_click(object sender, EventArgs e)
        {
            if (saveList.isLeft())
            {
                saveList.goLeft();
                lblSaveList.Text = saveList.ToString();
            }
            else
            {
                DisplayAlert("", "start of list", "OK");
            }
        }
        public void btnSaveRight_click(object sender, EventArgs e)
        {
            if (saveList.isRight())
            {
                saveList.goRight();
                lblSaveList.Text = saveList.ToString();
            }
            else
            {
                DisplayAlert("", "end of list", "OK");
            }
        }
        public void btnFindSaved_click(object sender, EventArgs e)
        {
           string foundNode = saveList.Find(myTree.findNode(int.Parse(txtKey.Text))).ToString();
            DisplayAlert("found in list", foundNode, "OK");

        }

        public void btnRemoveSaved_click(object sender, EventArgs e)
        {
            DisplayAlert("deleted", saveList.getData().ToString(), "OK");
            saveList.deleteCurrent();
            saveList.goLeft();
            lblSaveList.Text = saveList.getData().ToString();

        }

        public void btnReplacedSaved_click(object sender, EventArgs e)
        {
            //TreeNode foundNode = (TreeNode)saveList.Find(myTree.findNode(int.Parse(txtKey.Text)));
            TreeNode foundNode = myTree.findNode(int.Parse(txtKey.Text));
            DisplayAlert("replaced", saveList.getData().ToString() + " with " + foundNode.ToString(), "OK");
            saveList.editCurrent(foundNode);
            lblSaveList.Text = saveList.getData().ToString();
          
        }

        // the got to the hash tables button
        public void btnGoToHash_click(object sender,EventArgs e)
        {
             Navigation.PushAsync(new HashTableView());
        }
        // the got to the sorting an searching button
        public void btnGoToSort_click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchAndSort());
        }
    }
}
