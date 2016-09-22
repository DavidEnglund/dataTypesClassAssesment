using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
this is a binary tree implementation
it contains functions to add,remove,edit,search, and list the nodes,
you can list the nodes fromw lowest first,highest first, or top to bottom(left side first)
the functions are codded in this order:
varables
init 
search starter functions:
    return node
    return bool if found
add node
searching function
logging function
get log
clear log
left side iteration
left side starter
right side iteration
reight side starter
straight iteration
measure legs
delete function
alter data function


*/
namespace BinaryTree
{
    class BinTree
    {
        private TreeNode trunk; // this is the parent node of the tree
        private TreeNode currentNode; // this is the currently selecte node
        private int depth; // this is how deep the last method got to
        private string lastAction; // this is the last action performed
        private string log = "";

        // this is a binary tree class that will contain the functions and trunk
        // of the tree. 
        public BinTree(int startNumber,string startData) {
            trunk = new TreeNode(null, startNumber, startData);
            currentNode = trunk;
            logEntry("=== Trunk Node ===");
            logEntry(trunk);
        }

        // a simple search than return the node looked for
        public TreeNode findNode(int findMe)
        {
            logEntry("============================");
            logEntry("find by number");
            if (lookFor(trunk, findMe))
            {
                return currentNode;
            }
            else
            {
                return null;
            }
        }

        // a simple search that returns true or false if the node exists or not
        public bool doesNodeExist(int findMe)
        {
            logEntry("============================");
            logEntry("check by number");
            if (lookFor(trunk, findMe))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // lets add a node
        public bool addNode(int newNumber,string newData)
        {
            logEntry("============================");
            logEntry("add a node");
           // look for the position the new node go's to
            if (!lookFor(trunk ,newNumber))
            {
                // create the node
                TreeNode newNode = new TreeNode(currentNode, newNumber, newData);
                // put it either left or right depending
                if (newNode.sortingNum < currentNode.sortingNum)
                {

                    currentNode.left = newNode;
                }
                else
                {
                    currentNode.right = newNode;
                }
                logEntry(newNode);
                logEntry("node added");
                // added the node and now to
                return true;
                
            }
            else
            {

                logEntry("node with number already exists");
                // this node already exists so 
                return false;
                
            }
        }


        // ok so now we need a check funtion that will go though the tree 
        // and return true for found and false for null and update
        // all of the data with the found node
        private bool lookFor(TreeNode checkAgainst, int findMe)
        {
            logEntry(checkAgainst);
            // lets get the checking nodes number
            int checkNum = checkAgainst.sortingNum;
            // and up the depth for funsies
            depth++;
            // if the sorting number equals the current nodes number return true
            if (checkNum == findMe)
            {
                // we also need to set this node as current
                currentNode = checkAgainst;
                logEntry("node found");
                return true;

            }
            else
            {
                // look left then right
                // see if it is lower than and going left if true right if not
                if(findMe < checkNum)
                {
                    logEntry("left"); // log this action
                    // check for null and return false if null
                    if (checkAgainst.left == null)
                    {
                        logEntry("end of tree"); // log this action
                        // we also need to set this node as current
                        currentNode = checkAgainst;
                        return false;
                    }
                    else
                    {
                        return lookFor(checkAgainst.left, findMe);
                    }
                }
                else
                {
                    logEntry("right"); // log this action
                    // do that null check again
                    if (checkAgainst.right == null)
                    {
                        logEntry("end of tree"); // log this action
                        // we also need to set this node as current
                        currentNode = checkAgainst;
                        return false;
                    }
                    else
                    {
                        return lookFor(checkAgainst.right, findMe);
                    }
                }
               // return false;
            }
        }
        // add a node to the log
        private void logEntry(TreeNode logNode)
        {
            log += logNode.sortingNum.ToString() + ": " + logNode.data + "\r\n";
        }
        // add a action to the log
        private void logEntry(String actionTitle)
        {
            log += actionTitle + "\r\n";
        }
        // get the log
        public String getLog()
        {
            return log;
        }
        // clear the log - I need this to make it easier to see what is happening after useing the thing
        // for a while
        public void clearLog()
        {
            log = "=== Log cleared ===\r\n";
        }

        ///////////////////////////////// iterations
        // left side iteration or list from lowest to highest
        public dblLinked leftSideItr(TreeNode checkIt,bool fromChild, dblLinked results)
        {
            if (fromChild)
            {
                if(checkIt.right == null)
                {
                    results.addToEnd( checkIt.ToString());
                }
                if (checkIt.parent != null)
                {
                    if(checkIt.parent.right != null && checkIt.sortingNum < checkIt.parent.sortingNum)
                    {
                        results.addToEnd(checkIt.parent.ToString());
                        return leftSideItr(checkIt.parent.right, false, results);
                    }
                    else
                    {
                        return leftSideItr(checkIt.parent, true,results);
                    }
                }
                else
                {
                    return results;
                }
            }
            // ok so that is if its coming from a kid now if it coming from anywhere else
            else
            {
                if(checkIt.left!= null)
                {
                    return leftSideItr(checkIt.left, false, results);
                }
                else
                {
                    results.addToEnd(checkIt.ToString());
                    if(checkIt.right != null)
                    {
                        return leftSideItr(checkIt.right, false, results);
                    }
                    else
                    {
                        if (checkIt.parent != null)
                        {
                            // I forgot to check for a sister
                            if (checkIt.parent.right != null && checkIt.sortingNum < checkIt.parent.sortingNum)
                            {
                                results.addToEnd(checkIt.parent.ToString());
                                return leftSideItr(checkIt.parent.right, false, results);
                            }
                            else
                            {
                                return leftSideItr(checkIt.parent, true, results);
                            }
                        }
                        else
                        {
                            return results;
                        }
                    }
                }
            }
            //return results;
        }
        // and now a function to kick it off
        public dblLinked fromLowest()
        {
            return leftSideItr(trunk, false, new dblLinked());
        }
        // ##########################################################
        // right side iteration or list from Highest to lowest
        public dblLinked rightSideItr(TreeNode checkIt, bool fromChild, dblLinked results)
        {
            if (fromChild)
            {
                if (checkIt.left == null)
                {
                    // results += checkIt.ToString()  + "\r\n";
                    results.addToEnd(checkIt);
                }
                if (checkIt.parent != null)
                {
                    if (checkIt.parent.left != null && checkIt.sortingNum > checkIt.parent.sortingNum)
                    {
                        // results += checkIt.parent.ToString() + "\r\n";
                        results.addToEnd(checkIt.parent);
                        return rightSideItr(checkIt.parent.left, false, results);
                    }
                    else
                    {
                        return rightSideItr(checkIt.parent, true, results);
                    }
                }
                else
                {
                    return results;
                }
            }
            // ok so that is if its coming from a kid now if it coming from anywhere else
            else
            {
                if (checkIt.right != null)
                {
                    return rightSideItr(checkIt.right, false, results);
                }
                else
                {
                    //  results += checkIt.ToString() + "\r\n";
                    results.addToEnd(checkIt);
                    if (checkIt.left != null)
                    {
                        return rightSideItr(checkIt.left, false, results);
                    }
                    else
                    {
                        if (checkIt.parent != null)
                        {
                            // I forgot to check for a sister
                            if (checkIt.parent.left != null && checkIt.sortingNum > checkIt.parent.sortingNum)
                            {
                                // results += checkIt.parent.ToString()  + "\r\n";
                                results.addToEnd(checkIt.parent);
                                return rightSideItr(checkIt.parent.left, false, results);
                            }
                            else
                            {
                                return rightSideItr(checkIt.parent, true, results);
                            }
                        }
                        else
                        {
                            return results;
                        }
                    }
                }
            }
            //return results;
        }
        // and now a function to kick it off
        public dblLinked fromHighest()
        {
            
            return rightSideItr(trunk, false,new dblLinked());
        }

        // ###################################### Straight Iteration
        // this is a left first straight iteration
        public dblLinked straightItr()
        {
            dblLinked straightList = new dblLinked(trunk);
            // if I dont add a least one more node to the list
            // the loop will end at the start
            /*
            if(trunk.left!= null)
            {
                straightList.addToEnd(trunk.left);
            }
            if (trunk.right != null)
            {
                straightList.addToEnd(trunk.right);
            }
            /*  it looks like a do while works instead of a while loop*/
            do
            {
                // ok so to make the line of code readablely short lets pull the current
                // node from the list with a name
                TreeNode tempTreeNode = (TreeNode)straightList.getData();
                // if it has a left node add it to list
                if (tempTreeNode.left != null)
                {
                    straightList.addToEnd(tempTreeNode.left);
                }
                // ditto for right
                if (tempTreeNode.right != null)
                {
                    straightList.addToEnd(tempTreeNode.right);
                }
                // go to the next node in the list
                straightList.goRight();
            } while (straightList.isRight());
            // well thats it for the loop
            // it should should get though them all as it will stopp adding more 
            // at the leaf nodes
            return straightList;
        }
        // this function measures whether the left side of one node is longer than the right
        // of another
        // f it all I dont have to balance it so left side pref it is
        public bool deleteNode(int nodeNumber)
        {
            // first lets log what we are doing
            logEntry("============================");
            logEntry("delete node: " + nodeNumber);
            if (!this.doesNodeExist(nodeNumber))
            {
                logEntry("no node found to delete");
                return false;
            }
            else
            {
                TreeNode toDelete =  findNode(nodeNumber);

                // first lets check if what kids we have to decide what goes where
                if (toDelete.left != null)
                {
                    // ok so now we need to get the right side leaf of the left child
                    TreeNode leftRightLeaf = findRightLeaf(toDelete.left);
                    // ok now lets save the right child of the delete node to the left
                    leftRightLeaf.right = toDelete.right;
                    // now to cut out the delete by adding its left child to its place in the parent
                    // but first lest just check it has a parent(basicly if its the trunk)
                    if (toDelete.parent != null)
                    {
                        if (toDelete == toDelete.parent.left)
                        {
                            toDelete.parent.left = toDelete.left;
                        }
                        else
                        {
                            toDelete.parent.right = toDelete.left;
                        }
                    }
                    else
                    {
                        // ok so no parent node means the trunk node  and we have already saved the right side node
                        // to the right leaf of the left so lets just make the left the trunk
                        trunk = toDelete.left;
                    }
                }
                
                else
                {
                    // well we dont have a left child so I'll just add the right node to the parent
                    // even if its null
                    // fiirst a parent check (aka trunk node)
                    if (toDelete.parent != null)
                    {


                        if (toDelete == toDelete.parent.left)
                        {
                            toDelete.parent.left = toDelete.right;
                        }
                        else
                        {
                            toDelete.parent.right = toDelete.right;
                        }
                    }
                    else
                    {
                        // ok so we have no left node and we are deleting the trunk node
                        trunk = toDelete.right;
                    }
                }
               
                // lets just log the delete
                logEntry(toDelete);
                logEntry("deleted");
                return true;
            }

        }
        public TreeNode findRightLeaf(TreeNode findMyLeaf)
        {
            TreeNode checkIt = findMyLeaf;
            while(checkIt.right != null)
            {
                checkIt = checkIt.right;
            }
            return checkIt;

        }

        public bool ChangeData(string data, int node)
        {
            if (this.lookFor(trunk, node))
            {
                currentNode.data = data;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
