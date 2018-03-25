using ListAssignment;
using Utils;
using System;
using ListException;

namespace ListAssignment
{
    public class ListStudent:IList<Student>
    {
        // needed for tests
        public override bool exist(int matricule, ListElement<Student> listElement) {
            ListElement<Student> current = Head;

            while(current != null) {
                if(current.Data.MatriculationNumber == matricule) {
                    return false;
                }
                current = current.Next;
            }

            return false;
        }

        // print all the elements os the list to the console
        public override void printList() {
            if(Head == null) {
                Console.WriteLine("Empty list");
            } else {
            int i = 1;
            ListElement<Student> current = Head;

            while(current != null) {
                Console.WriteLine($"{i}. [{current.Data.Name}, {current.Data.Age}, {current.Data.Grade}, {current.Data.MatriculationNumber}]");
                current = current.Next;
                i++;
            }
            }
        }

        // replace by matricule
        public override void replace(int matricule, ListElement<Student> listElement) {
            if(Head != null) {
                ListElement<Student> current = Head;
                ListElement<Student> prev = null;
                Boolean found = false;

                while(current != null) {
                    if(current.Data.MatriculationNumber == matricule) {
                        found = true;

                        // if the search element is the first one in the list, then the new element becomes the first one
                        if(prev == null) {
                            Head = listElement;
                        } else {
                            prev.Next = listElement;
                        }

                        listElement.Next = current.Next;
                        break;
                    }

                    prev = current;
                    current = current.Next;
                }
                if(!found) throw (new ListElementNotFoundException("Student with matricule " + matricule + " not found."));
            } else {
                throw (new ListEmptyException("Unable to replace. List empty."));
            }
        }
    }
}