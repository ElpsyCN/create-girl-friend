using System;
using System.Collections.Generic;
using System.Text;

namespace CreatePeople.Core.Models
{
    public static class PeopleFactory
    {
        public static People CreatePeole(Type type)
        {
            return (People)Activator.CreateInstance(type);
        }
        public static People CreatePeole(Type type, params object[] args)
        {
            return (People)Activator.CreateInstance(type, args);
        }
    }
}
