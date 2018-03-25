using ListAssignment;
using Utils;
using System;
using ListException;

namespace ListAssignment
{
    public class ListInt:IList<int>
    {
        // needed for tests
        public override bool exist(int search, ListElement<int> listElement) {
            ListElement<int> current = Head;

            while(current != null) {
                if(current.Data == search) {
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
            ListElement<int> current = Head;

            while(current != null) {
                Console.WriteLine($"{i}. [{current.Data}]");
                current = current.Next;
                i++;
            }
            }
        }

        // replace by matricule
        public override void replace(int indice, ListElement<int> listElement) {
            if(Head != null) {
                ListElement<int> current = Head;
                ListElement<int> prev = null;
                Boolean found = false;

                while(current != null) {
                    if(current.Data == indice) {
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
                if(!found) throw (new ListElementNotFoundException("Element " + indice + " not found."));
            } else {
                throw (new ListEmptyException("Unable to replace. List empty."));
            }
        }
    }
}