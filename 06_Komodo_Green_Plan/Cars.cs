using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Komodo_Green_Plan
{  
    public class Car
    {
        public Car() { }
        public Car(int id, string make, string model, string year, string driveTrain) 
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            DriveTrain = driveTrain;
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string DriveTrain { get; set; }
    }
}
