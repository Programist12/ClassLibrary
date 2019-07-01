using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTree2
{
    public class TreeEvent
    {
        public string Message { get; }
        public TreeEvent(string mes)
        {
            Message = mes;
        }
    }


    public class Tree<T> : IComparable<T>
    {
        public delegate void EventDelegate(object sender, TreeEvent e);
        public event EventDelegate onAdd;
        public event EventDelegate onCount;



        public class Node
        {
            public T data;
            public Node Left;
            public Node Right;
            public Node parent;
            public Node()
            {

                Left = null;
                Right = null;
                parent = null;

            }

        }

        public Node root;
        Comparison<T> CompareFunc;

        public Tree(Comparison<T> theCompareFunc)
        {
            root = null;
            CompareFunc = theCompareFunc;
        }

        public static int CompareFuncByMark(Student left, Student right)
        {
            return left.Mark - right.Mark;
        }

        public Tree()
        {
        }

        public bool AddNodeRecursion(T Newdata)
        {
            Node child = new Node();
            child.data = Newdata;
            if (root == null)
            {
                root = child;
                return true;
            }
            else
            {
                Node currentNode = root;
                while (true)
                {
                    int Compare = CompareFunc(Newdata, currentNode.data);
                    if (Compare <= 0)
                        if (currentNode.Left != null)
                        {
                            currentNode = currentNode.Left;

                        }
                        else
                        {
                            currentNode.Left = child;
                            child.parent = currentNode;
                            break;
                        }
                    if (Compare > 0)
                        if (currentNode.Right != null)
                        {
                            currentNode = currentNode.Right;
                            continue;
                        }
                        else
                        {
                            currentNode.Right = child;
                            child.parent = currentNode;
                            break;
                        }
                }
                if (onAdd != null)
                {
                    onAdd?.Invoke(this, new TreeEvent("Был добавлен новый элемент"));
                }





            }
            return true;

        }




        public int CountChildrens(Node n)
        {

            int counter = 0;
            
            if (n.Left != null)
            {
                counter += CountChildrens(n.Left);
                counter++;

            }
            if (n.Right != null)
            {
                counter += CountChildrens(n.Right);
                counter++;

            }
            Console.WriteLine(counter.ToString());

            if (onCount != null)
            {
                onCount?.Invoke(this, new TreeEvent("Было подсчитано количество дочерних элементов дерева" + " " + "И показан каждый из них "));
                
            }

            return counter;
            

        }











        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator(this);
        }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Student s1,Student s2)
        {
            if (s1.Mark < s2.Mark)
                return 1;
            else if (s1.Mark > s2.Mark)
                return 0;
            return s1.Mark.CompareTo(s2.Mark);
        }

        public class TreeEnumerator : IEnumerator<T>
        {
            Node current;
            Tree<T> theTree;

            public TreeEnumerator(Tree<T> tree)
            {
                theTree = tree;
                current = null;

            }
            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public T Current
            {
                get
                {
                    if (current == null)
                        throw new InvalidOperationException();
                    return current.data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (current == null)
                        throw new InvalidOperationException();
                    return current.data;
                }
            }

            public void Dispose() { }
            public void Reset() { current = null; }

        }
    }
}
