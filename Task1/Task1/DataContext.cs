using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class DataContext
    {
        public List<User> users = new List<User>();
        public List<Catalog> catalogs = new List<Catalog>();
        public List<Event> events = new List<Event>();
        public List<State> states = new List<State>();
    }
}
