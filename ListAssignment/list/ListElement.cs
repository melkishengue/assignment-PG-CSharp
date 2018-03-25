using System;

namespace ListAssignment
{
    public class ListElement<T>
    {
        public T Data { get; set; }
        public ListElement<T> Next { get; set; }

        //Constructor
        public ListElement(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
