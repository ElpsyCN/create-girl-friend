using System;
using System.Collections.Generic;
using System.Text;

namespace CreatePeople.Core.Exceptions
{
    public class RelationshipException: Exception
    {
        public RelationshipException(string message): base(message)
        {

        }
    }
}
