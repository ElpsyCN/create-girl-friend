using System;
using System.Collections.Generic;
using System.Text;

namespace CreatePeople.Core.Exceptions
{
    public class NotFoundCurrentMateException:Exception
    {
        public NotFoundCurrentMateException(string message): base(message)
        {

        }
    }
}
