using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class dblLinked
    {
        // so all the data I need it to save is the last item the next and th data
        private linkNode node;       
        // init class(s)   
        public dblLinked()
        {
            node = null;
        }
        // creating a new dbl linked list item as a stand alone(i.e the first one)
        public dblLinked(Object input)
        {
            node = new linkNode(null, input, null);
        }
        // all of the adding classes check to see if there is a starting node and
        // add this node as the start one if not
        // add left and right shifting the current left or right along one
        public void addLeft(Object input)
        {
            if (node == null)
            {
                node = new linkNode(null, input, null);
            }
            else
            {
                node.leftNode = new linkNode(node.leftNode, input, node);
                // now to change the old right  node's left to this one if it exisits
                //goLeft();
                if (node.leftNode.leftNode != null)
                {
                    node.leftNode.leftNode.rightNode = node;
                }
            }
        }
        public void addRight(Object input)
        {
            if (node == null)
            {
                node = new linkNode(null, input, null);
            }
            else
            {
                node.rightNode = new linkNode(node, input, node.rightNode);
                // now to change the old right  node's left to this one if it exisits
                //goRight();
                if(node.rightNode.rightNode != null)
                {
                    node.rightNode.rightNode.leftNode = node;
                }
            }
        }
        // now for adding to the end or beginning
        // this will require checking that the list is not a looped list
        // and yeah I realise that if you have a tailed loop list this could
        // be a infinate loop
        // meh this is now a controller class and cant have a loopped list
        public bool addToEnd(Object input)
        {
            if (node == null)
            {
                node = new linkNode(null, input, null);
                return true;
            }
            else
            {

                linkNode checker = node.rightNode;
                if (checker != null)
                {
                    while (true)
                    {
                        if (checker.rightNode != null)
                        {
                            // make sure its not a circular list
                            if (checker.rightNode != node)
                            {
                                checker = checker.rightNode;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            checker.rightNode = new linkNode(checker, input, null);
                            return true;
                        }
                    }
                }
                else
                {
                    addRight(input);
                    return true;
                }
            }
        }
        // add an item to the start of the linked list
        public bool addToStart(Object input)
        {
            if (node == null)
            {
                node = new linkNode(null, input, null);
                return true;
            }
            else
            {

                linkNode checker = node.leftNode;
                if (checker != null)
                {
                    while (true)
                    {
                        if (checker.leftNode != null)
                        {
                            if (checker.leftNode != node)
                            {
                                checker = checker.leftNode;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            checker.leftNode = new linkNode(null, input, checker);
                            return true;
                        }
                    }
                }
                else
                {
                    addLeft(input);
                    return true;
                }
            }
        }
        // now for the going left and right functions
        public bool goLeft()
        {
            if (node != null)
            {
                if (node.leftNode != null)
                {
                    // well it looks like I need a controller class after all    
                    node = node.leftNode;
                    return true;
                }
            }
            return false;
        }
        public bool goRight()
        {
            if (node != null)
            {
                if (node.rightNode != null)
                {
                    // well it looks like I need a controller class after all    
                    node = node.rightNode;
                    return true;
                }
            }
            return false;
        }
        // and we will need a go to start and end functions as well
        public void goToStart()
        {
            // loop until we hit the start
            if (node != null)
            {
                while (node.leftNode != null)
                {
                    goLeft();
                }
            }
        }
        public void goToEnd()
        {
            // loop until we hit the end 
            // I know that this will break if we have a circular list
            if (node != null)
            {
                while (node.rightNode != null)
                {
                    goRight();
                }
            }
        }
        // ok now lets see if a left or right exists and retrun a bool
        public bool isLeft()
        {
            if (node != null)
            {
                if (node.leftNode == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool isRight()
        {
            if (node != null)
            {
                if (node.rightNode== null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        // and now we need to be able to get the data out of the current node
        public Object getData()
        {
            if (node != null)
            {
                return node.data;
            }
            else
            {
                return false;
            }
        }
        // and a tostring override - this will just use the current objects tostring method
        override
        public String ToString()
        {
            return node.data.ToString();
        }
        // lets change the data in the current node
        public void editCurrent(object input)
        {
            node.data = input;
        }
        // and now for a delete function
        public void deleteCurrent()
        {
            // first lets get the left and right nodes to link to each other cutting out the current node
            // only if the nodes exist to be added to of course
            if (isLeft())
            {
                node.leftNode.rightNode = node.rightNode;
            }
            if (isRight())
            {
                node.rightNode.leftNode = node.leftNode;
            }
            // now to switch to one of these node - lets check if one is null and
            // if so switch to the other, after all if both are null then its the
            // only one here and this will effectivly clear the list
            if (node.leftNode != null)
            {
                node = node.leftNode;
            }
            else
            {
                node = node.rightNode;
            }
            
        }
        // for the hell of it a delete before and after
        public void deleteBefore(int amount)
        {
            while(amount > 0)
            {
                if(node.leftNode != null)
                {
                    node.leftNode = node.leftNode.leftNode;
                    // and set the new left node if it exist to have this currnt node as its right
                    if (node.leftNode != null)
                    {
                        node.leftNode.rightNode = node;
                    }
                }
                else
                {
                    break;
                }
                amount--;
            }
        }
        // and now after
        public void deleteAfter(int amount)
        {
            while (amount > 0)
            {
                if (node.rightNode != null)
                {
                    node.rightNode = node.rightNode.rightNode;
                    // and set the new right node if it exist to have this currnt node as its left
                    if(node.rightNode != null)
                    {
                        node.rightNode.leftNode = node;
                    }
                }
                else
                {
                    break;
                }
                amount--;
            }
        }
        // a check to see if the current node is null(therefore the entire thing is null
        public bool IsEmpty()
        {
            if(node == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // and Finaly a search function
        public object Find(object search)
        {
            // lets start at the begining
            if (node != null)
            {
                goToStart();
                if (search == node.data)
                {
                    return node.data;
                }
                else
                {
                    // it wasnt in the only place I looked
                    while (goRight())
                    {
                        if (search == node.data)
                        {
                            return node.data;
                        }
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        // so I am going to have a controller class and a node class after all
        //altough I could have had some fun messing if "tailed" or fractal lists without a controller
        // to clean things up
        private class linkNode
        {
            public linkNode leftNode;
            public Object data;
            public linkNode rightNode;
            public linkNode(linkNode LeftNode, Object Data, linkNode RightNode)
            {
                leftNode = LeftNode;
                data = Data;
                rightNode = RightNode;
            }
        }
    }
   
}
