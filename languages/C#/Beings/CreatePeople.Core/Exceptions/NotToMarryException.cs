using System;
using System.Collections.Generic;
using System.Text;

namespace CreatePeople.Core.Exceptions
{
    public class NotToMarryException: Exception
    {
        public NotToMarryException(string message): base(message)
        {

        }
    }
}
