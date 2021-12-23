using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Komodo_Outings
{

    public enum EventKind
    {
        AmusementPark,
        Bowling,
        Concert,
        Golf
    }
    public class Outing
    {
        public Outing() { }
        public Outing
            (
            int id,
            int count,
            DateTime date,
            decimal total
            )

        {
            Id = id;

            Count = count;
            Date = date;
            Total = total;
        }

        public int Id { get; set; }
        public EventKind Event { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public decimal CostPerPerson
        {
            get
            {

                var CPerPerson = Total / Count;
                return CPerPerson;
            }

        }
        public override string ToString()
        {
            return $"{Id}\n" +
                $"{Event}\n" +
                $"{Count}\n" +
                $"{Date}\n" +
                $"{Total}\n" +
                $"{CostPerPerson}\n";
        }
    }
}

