using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1LogicTests
{
    internal class TestBuyEvent : Event
    {
        public TestBuyEvent(IUser user, IState state, DateTime timestamp)
            : base(user, state, timestamp) { }
    }
}
