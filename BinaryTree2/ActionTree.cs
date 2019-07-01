using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree2;


namespace BinaryTree2
{
    public class ActionTree
    {
       
        
        public static bool TreeAHeadDirectRecursion(Tree<Student>.Node node)
        {

            if (node != null)
            {
                TreeAHeadDirectRecursion(node.Left);
                TreeAHeadDirectRecursion(node.Right);
                Console.WriteLine(node.data.ToString());
            }
            return true;
        }


    }
}
