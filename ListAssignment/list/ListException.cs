using System;

namespace ListException
{


    public class ListEmptyException: Exception
    {
        public ListEmptyException(string message): base(message)
        {
        }
    }

    public class ListElementNotFoundException: Exception
    {
        public ListElementNotFoundException(string message): base(message)
        {
        }
    }

}