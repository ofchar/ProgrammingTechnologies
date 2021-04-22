using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IEvent
    {
        IUser User { get; set; }

        IState State { get; set; }

        DateTime Timestamp { get; set; }

        string ToString();
    }
}
