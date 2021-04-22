using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Task1LogicTests
{
    internal class TestRestockEvent : Event
    {
        public TestRestockEvent(IUser user, IState state, DateTime timestamp)
            : base(user, state, timestamp) { }
    }
}
