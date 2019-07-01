using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree2
{
     public class Student
    {
        public string Name { get; set; }
        public string TestName { get; set; }
        public DateTime dateTest { get; set; }
        public int Mark { get; set; }
        

        public Student(string name, string testName, DateTime dateTest, int mark)
        {
            Name = name;
            TestName = testName;
            this.dateTest = dateTest;
            Mark = mark;
            
        }
        public Student() { }

        public override string ToString()
        {
            return $"{Name} {TestName} {dateTest.ToShortDateString()} {Mark} ";
        }
    }
}
