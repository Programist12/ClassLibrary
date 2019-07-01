using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using Assert = NUnit.Framework.Assert;
using BinaryTree2;
using NUnit.Framework;

namespace TestsForTree
{
    [TestClass]
    public class TreeTest
    {
        Tree<Student> student = new Tree<Student>(Tree<Student>.CompareFuncByMark);

        [TestMethod]
        public void AddStudent()
        {
            Student s = new Student();
            var result = student.AddNodeRecursion(s);
            Assert.That(result, Is.True);

        }

        [TestMethod]
        public void CompareStudents()
        {
            Student s = new Student("Sasha", "Epam", new DateTime(2019, 5, 5),1);
            Student s2 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 5);
            var result = Tree<Student>.CompareFuncByMark(s, s2);
            Assert.That(result, Is.Negative);
        }
        [TestMethod]
        public void CountChildrens()
        {
            Student s1 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -10);
            Student s2 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 0);
            Student s3 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 20);
            Student s4 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -15);
            Student s5 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 2);
            student.AddNodeRecursion(s1);
            student.AddNodeRecursion(s2);
            student.AddNodeRecursion(s3);
            student.AddNodeRecursion(s4);
            student.AddNodeRecursion(s5);
            var result = student.CountChildrens(student.root);
            Assert.That(result, Is.Not.Null);
            
        }
        [TestMethod]
        public void TreeAHeadDirectRecursion()
        {
            Student s1 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -10);
            Student s2 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 0);
            Student s3 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 20);
            Student s4 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), -15);
            Student s5 = new Student("Sasha", "Epam", new DateTime(2019, 5, 5), 2);
            student.AddNodeRecursion(s1);
            student.AddNodeRecursion(s2);
            student.AddNodeRecursion(s3);
            student.AddNodeRecursion(s4);
            student.AddNodeRecursion(s5);
            var result = ActionTree.TreeAHeadDirectRecursion(student.root);
            Assert.That(result, Is.True);
        }


    }
}
