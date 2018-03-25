using System;
using ListException;

namespace ListAssignment
{
    public abstract class IList<T>
    {
        // Length of the list
        public ListElement<T> Head { get; set; }

        // Constructor
        public IList()
        {
            Head = null;
        }

        abstract public void printList();
        abstract public bool exist(int matricule, ListElement<T> listElement);
        abstract public void replace(int matricule, ListElement<T> listElement);

        // needed for test
        public ListElement<T> getLastElement() {
            ListElement<T> current = Head;

            while(current.Next != null) {
                current = current.Next;
            }
            return current;
        }

        // add a new element at the end of  the list
        public void addAtEnd(ListElement<T> listElement) {
            if(Head == null) {
                listElement.Next = Head;
                Head = listElement;
            } else {
                ListElement<T> current = Head;

                while(current.Next != null) {
                    current = current.Next;
                }

                current.Next = listElement;
                listElement.Next = null;
            }
        }

        // add a new element to the begining list
        public void addAtStart(ListElement<T> listElement) {
            listElement.Next = Head;
            Head = listElement;
        }

        // remove the list's first element
        public ListElement<T> removeFirst() {
            if(Head != null) {
                ListElement<T> currentHead = Head;
                Head = Head.Next;
                return currentHead;
            }  else {
                throw (new ListEmptyException("Unable to remove first element. List empty."));
            }
        }        

        // needed for tests
        public int count() {
            int i = 0;
            ListElement<T> current = Head;

            while(current != null) {
                current = current.Next;
                i++;
            }
            return i;
        }
    }
}
