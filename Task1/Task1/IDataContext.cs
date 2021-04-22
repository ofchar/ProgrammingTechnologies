using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataContextApi
    {
        public List<IUser> users = new List<IUser>();
        public Dictionary<string, ICatalog> catalogs = new Dictionary<string, ICatalog>();
        public List<IEvent> events = new List<IEvent>();
        public List<IState> states = new List<IState>();
    }
}
