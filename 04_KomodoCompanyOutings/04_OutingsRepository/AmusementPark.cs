using System;

namespace _04_OutingsRepository
{
    public class AmusementPark : Outing
    {
        public AmusementPark(int id, int count, DateTime date, decimal total)
            : base(id, count, date, total)
        {
            Event = EventKind.AmusementPark;
        }
    }
}
