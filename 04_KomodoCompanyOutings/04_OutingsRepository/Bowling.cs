using System;

namespace _04_OutingsRepository
{
    public class Bowling : Outing
    {
        public Bowling(int id, int count, DateTime date, decimal total)
            : base(id, count, date, total)
        {
            Event = EventKind.Bowling;
        }
    }
}
