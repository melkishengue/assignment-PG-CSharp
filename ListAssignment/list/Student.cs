using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListAssignment
{
    public class Student
    {
        //The name of the student
        public string Name { get; set; }
        //The age of the student
        public int Age { get; set; }
        //The Matriculation Number of the student
        public int MatriculationNumber { get; set; }
        //The Grade of the student from his A level
        public double Grade { get; set; }

        //Constructor
        public Student(string name, int age, int maNumber, double grade)
        {
            Name = name;
            Age = age;
            MatriculationNumber = maNumber;
            Grade = grade;
        }

    }
}
