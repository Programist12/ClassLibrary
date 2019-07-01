using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree2;

namespace BinaryTreeEpam
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<Student> student = new Tree<Student>(Tree<Student>.CompareFuncByMark);

            student.onAdd += ShowMessage;
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -10));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 1));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -5));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 6));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -11));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 20));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -8));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 2));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -12));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 0));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -45));
            student.AddNodeRecursion(new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 100));


            Console.WriteLine("Tree:");
            ActionTree.TreeAHeadDirectRecursion(student.root);
            Console.WriteLine("Count of Childrens:");
            student.onCount += ShowMessage;
            student.CountChildrens(student.root);

            Console.ReadKey();

        }

        public static void ShowMessage(object sender, TreeEvent e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
