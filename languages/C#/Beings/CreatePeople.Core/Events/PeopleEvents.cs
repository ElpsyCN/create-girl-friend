using System;
using System.Collections.Generic;
using System.Text;

namespace CreatePeople.Core.Events
{
    public class PeopleEvents
    {
        // Declare the delegate 
        public delegate void FallInLoveEventHandler(object sender, FallInLoveArgs e);
        public delegate void BreakUpEventHandler(object sender, BreakUpArgs e);
        public delegate void MarryEventHandler(object sender, MarryArgs e);

    }
}
