using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext
    {
        public List<User> users = new List<User>();
        public Dictionary<string, Catalog> catalogs = new Dictionary<string, Catalog>();
        public List<Event> events = new List<Event>();
        public List<State> states = new List<State>();
    }
}
