using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{
    public class Golf : Outing
    {
        public Golf(int id, int count, DateTime date, decimal total)
            : base(id, count, date, total)
        {
            Event = EventKind.Golf;
        }
    }
}
