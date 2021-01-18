using System;

namespace CreatePeople.Core.Events
{
    public class MarryArgs: EventArgs
    {
        public object T { get; set; }
        public string Tip { get; set; }
    }
}