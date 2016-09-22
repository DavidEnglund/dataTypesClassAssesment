using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class TreeNode
    {
        // this is a node for the binray tree  it will have a parent node a left and right node
        // and a sorting number and the data(a string).
        public TreeNode parent;
        public TreeNode left;
        public TreeNode right;
        public int sortingNum;
        public string data;

        public TreeNode(TreeNode Parent,int SortingNum,String Data)
        {
            parent = Parent;
            sortingNum = SortingNum;
            data = Data;
            // I think this is all a node needs as the code to traverse the tree shall be in the tree class
        }
        // lets create the toString
        public override string ToString()
        {
            return sortingNum + ": " + data;
        }
    }
}
