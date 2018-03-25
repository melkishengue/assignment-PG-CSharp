using System;
using System.IO;
using Xunit;
using ListAssignment;
using Utils;
using ListException;

namespace test_list
{

    // tests for the class Student
    public class UnitTestStudent
    {
        [Fact]
        public void Test1()
        {   
            Student student = new Student("Melkis", 27, 123456, 1.0);
            
            Assert.NotEqual(student, null);
            Assert.Equal(student.Name, "Melkis");
            Assert.Equal(student.Age, 27);
            Assert.Equal(student.Grade, 1.0);
            Assert.Equal(student.MatriculationNumber, 123456);
        }
    }

    // tests for the class ListElement
    public class UnitTestListElement
    {
        String File = System.AppDomain.CurrentDomain.BaseDirectory + "/../../../Data.txt";

        [Fact]
        public void Test1()
        {   
            UtilsCLass utils = new UtilsCLass();
            Student[] students = utils.loadStudents(this.File);

            ListElement<Student> listElement = new ListElement<Student>(students[0]);
            
            Assert.Equal(null, listElement.Next);
            Assert.Equal(students[0], listElement.Data);
            
            Assert.NotEqual(listElement.Data, null);
            Assert.Equal(listElement.Data.Name, students[0].Name);
            Assert.Equal(listElement.Data.Age, students[0].Age);
            Assert.Equal(listElement.Data.Grade, students[0].Grade);
            Assert.Equal(listElement.Data.MatriculationNumber, students[0].MatriculationNumber);
        }
    }

    // tests for the class List
    public class UnitTestListStudent
    {
        String File = System.AppDomain.CurrentDomain.BaseDirectory + "/../../../Data.txt";
        Student[] Students;

        public UnitTestListStudent() {
            UtilsCLass utils = new UtilsCLass();
            Students = utils.loadStudents(this.File);
        }
        
        [Fact]
        public void TestInstantiation()
        {   
            ListStudent list = new ListStudent();
            Assert.NotEqual(null, list);
            Assert.Equal(null, list.Head);
        }

        [Fact]
        public void TestAddAtStart()
        {   
            ListElement<Student> listElement = new ListElement<Student>(Students[0]);
            ListElement<Student> listElement2 = new ListElement<Student>(Students[1]);
            ListElement<Student> listElement3 = new ListElement<Student>(Students[2]);
            ListElement<Student> listElement4 = new ListElement<Student>(Students[3]);

            ListStudent list = new ListStudent();
            list.addAtStart(listElement);
            list.addAtStart(listElement2);
            list.addAtStart(listElement3);
            list.addAtStart(listElement4);

            // there should be 4 elements in the list
            Assert.Equal(4, list.count());
            // last element to be added should be head
            Assert.Equal(listElement4.Data, list.Head.Data);
        }

        [Fact]
        public void TestAddAtEnd()
        {   
            ListElement<Student> listElement = new ListElement<Student>(Students[0]);
            ListStudent list = new ListStudent();

            list.addAtEnd(listElement);

            Assert.Equal(1, list.count());
            // element should be the last one now
            Assert.Equal(Students[0], list.getLastElement().Data);
        }

        [Fact]
        public void TestRemoveFirst()
        {   
            ListElement<Student> listElement = new ListElement<Student>(Students[0]);

            ListStudent list = new ListStudent();
            list.addAtStart(listElement);
            ListElement<Student> firstListElement = list.removeFirst();

            // returned element should be the one added
            Assert.Equal(firstListElement.Data, Students[0]);
            // list should be empty
            Assert.Equal(0, list.count());
            // yeah, really empty
            Assert.Equal(null, list.Head);

        }

        [Fact]
        public void TestRemoveFirstOnEmptyListThrowsListEmptyException () {
            // we create an empty list
            ListStudent list = new ListStudent();

            Exception ex = Assert.Throws<ListEmptyException>(() => list.removeFirst());
            Assert.Equal(ex.Message, "Unable to remove first element. List empty.");
        }

        [Fact]
        public void TestReplaceOnEmptyListThrowsListEmptyException () {
            // we create an empty list
            ListStudent list = new ListStudent();

            Exception ex = Assert.Throws<ListEmptyException>(() => list.replace(97035, new ListElement<Student>(new Student("Fred", 27, 1987, 1.0))));
            Assert.Equal(ex.Message, "Unable to replace. List empty.");
        }

        [Fact]
        public void TestReplaceOnEmptyListThrowsListElementNotFoundException () {
            ListStudent list = new ListStudent();
            int matricule = 0000;

            ListElement<Student> listElement = new ListElement<Student>(Students[0]);

            // we want to test a non empty list
            list.addAtStart(listElement);

            Exception ex = Assert.Throws<ListElementNotFoundException>(() => list.replace(matricule, new ListElement<Student>(new Student("Fred", 27, 1987, 1.0))));
            Assert.Equal(ex.Message, "Student with matricule " + matricule + " not found.");
        }
    }
}