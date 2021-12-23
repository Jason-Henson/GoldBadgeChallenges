using System.Collections.Generic;
using System.Linq;

namespace _04_OutingsRepository
{
    public class OutingsRepository
    {
        protected readonly List<Outing> _outingsRepository = new List<Outing>();


        //Create
        // add outing
        public bool CreateNewOuting(Outing newOuting)
        {
            int startingCount = _outingsRepository.Count;
            newOuting.Id = startingCount +1;
            _outingsRepository.Add(newOuting);
            return true;
        }

        public bool CreateNewOuting(List<Outing> newOutings)
        {
            int startingCount = _outingsRepository.Count;
            foreach (var item in newOutings)
            {
                startingCount++;
                item.Id = startingCount;
            }
            _outingsRepository.AddRange(newOutings);
            return true;
        }
        public Outing GetOutingById(int id)
        {
            foreach (Outing item in _outingsRepository)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        //Read
        // display all outings #1
        public List<Outing> ReadAllOutings()
        {
            return _outingsRepository;
        }
        // sum all outings #3a
       //3
        public decimal SumAllOutings()
        {
            decimal sum = 0;
            foreach (var item in _outingsRepository)
            {
                sum += item.Total;
            }
            return sum;
            //return _outingsRepository.Sum(o => o.Total);
        }
        // sum of events by type #3b
        public decimal SumEventsByType(EventKind eventType)
        {
            decimal sum = 0;
            foreach (var item in _outingsRepository)
            {
                if(item.Event == eventType)
                {
                    sum+= item.Total;
                }

            }
            return sum;
        }
    }

}
