using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUser
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string Uuid { get; set; }

        string ToString();
    }
}
