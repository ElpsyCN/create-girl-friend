using System;

namespace CreatePeople.Core.Events
{
    public class FallInLoveArgs: EventArgs
    {
        public object T { get; set; }
        public string Tip { get; set; }
    }
}