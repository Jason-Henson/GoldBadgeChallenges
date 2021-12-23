using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OutingsRepository
{
    public class Concert : Outing
    {
        public Concert(int id, int count, DateTime date, decimal total)
            : base(id, count, date, total)
        {
            Event = EventKind.Concert;
        }
    }
}
