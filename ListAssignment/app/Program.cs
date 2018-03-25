using System;
using System.IO;
using ListAssignment;
using Utils;
using ListException;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilsCLass utils = new UtilsCLass();

            String File = System.AppDomain.CurrentDomain.BaseDirectory + "/../../../Data.txt";
            ListStudent list = utils.createListFromFile(File);

            Console.WriteLine("Initial list: ");
            list.printList();

            try {
                Console.WriteLine("After remvoveFirst:");
                list.removeFirst();
                list.printList();
            } catch ( ListElementNotFoundException  e ) { Console.WriteLine(e); }
            catch ( ListEmptyException  e ) { Console.WriteLine(e); }


            Console.WriteLine("After adding Marc as last element(addAtEnd)");
            ListElement<Student> listElement = new ListElement<Student>(new Student("Marc", 23, 123456, 1.3));
            list.addAtEnd(listElement);
            list.printList();

            try {
                Console.WriteLine("After adding Melkis as first element(addAtStart)");
                ListElement<Student> listElement2 = new ListElement<Student>(new Student("Melkis", 27, 23423, 1.7));
                list.addAtStart(listElement2);
                list.printList();

                Console.WriteLine("After replacing Franck (Mat: 1470) by Fred (Mat: 1987)");
                list.replace(1470, new ListElement<Student>(new Student("Fred", 27, 1987, 1.0)));
                list.printList();
                ListStudent list2 = new ListStudent();
                // list2 is empty, exception ListEmptyException should be thrown
                list2.replace(1470, new ListElement<Student>(new Student("Fred", 27, 1987, 1.0)));
            } catch ( ListElementNotFoundException  e ) { Console.WriteLine(e); }
            catch ( ListEmptyException  e ) { Console.WriteLine(e); }

            // integer list now
            ListInt listInt = new ListInt();
            listInt.addAtEnd(new ListElement<int>(16));
            listInt.addAtEnd(new ListElement<int>(20));
            listInt.addAtEnd(new ListElement<int>(30));
            listInt.addAtStart(new ListElement<int>(22));
            listInt.printList();
            
            try {
                // element 19 does not exist in the list. should throw an exception
                listInt.replace(19, new ListElement<int>(100));
                listInt.printList();
            } catch ( ListElementNotFoundException  e ) { Console.WriteLine(e); }
            catch ( ListEmptyException  e ) { Console.WriteLine(e); }
            
        }

    }
}