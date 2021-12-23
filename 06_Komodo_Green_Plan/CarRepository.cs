using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Komodo_Green_Plan
{
    public class CarRepository
    {
        protected readonly List<Car> _carRepositories = new List<Car>();

        //Create
        public bool CreateCar(Car newCar)
        {
            int startingCount = _carRepositories.Count;
            newCar.Id = (startingCount + 1);
            if( newCar != null)
            {
                _carRepositories.Add(newCar);
                return true;
            }
            return false;
        }

        //Read
        public List<Car> ReadListOfAllCars()
            { return _carRepositories; }

        public Car ReadCarById(int id)
        {
            foreach (Car c in _carRepositories)
            {
                if (c.Id == id)
                    return c; 

            }
            return null;
        }

        /* List of cars by type */
        public List<Car> ReadCarByType(string driveTrain)
        {
            List<Car> car = new List<Car>();
            foreach (Car c in _carRepositories)
            {
                if (c.DriveTrain == driveTrain)
                    {
                        car.Add(c);
                    }
               
            }
            return car;
        }

        //Update
        public bool UpdateExistingCar(int id, Car updatedContent)
        {
            // was making this type List OK?  Had to do this to avoid type conflict fromn loopup1dev
            Car oldContent = ReadCarById(id);
            if (oldContent != null)
            {
                // changeing type of dev to list is cause error with oldContent varaible
                oldContent.Make = updatedContent.Make;
                oldContent.Model = updatedContent.Model;
                oldContent.Year = updatedContent.Year;
                oldContent.DriveTrain = updatedContent.DriveTrain;
                return true;
            }
            return false;
        }

        //Delete 
        public bool DeleteExistingCar(Car existingCar)
        {
            bool removeCar = _carRepositories.Remove(existingCar);
            return removeCar;

        }



    }
}
