using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Komodo_Green_Plan.UI
{
    public class ProgramUI
    {
        private readonly CarRepository _repo = new CarRepository();

        public void Run()
        {
            Seed();
            showMenu();
        }

        private void Seed()
        {
            Car car = new Car
            {
                Make = "Tesla",
                Model = "Model 3",
                Year = "2020",
                DriveTrain = "electric"
            };
            _repo.CreateCar(car);

            Car car2 = new Car();
            car2.Make = "Toyota";
            car2.Model = "Prius";
            car2.Year = "2021";
            car2.DriveTrain = "hybrid";
            _repo.CreateCar(car2);

            Car car3 = new Car();
            car3.Make = "Ford";
            car3.Model = "F-150";
            car3.Year = "2021";
            car3.DriveTrain = "gasoline";
            _repo.CreateCar(car3);

            Car car4 = new Car();
            car4.Make = "Rivian";
            car4.Model = "RV1";
            car4.Year = "2022";
            car4.DriveTrain = "electric";
            _repo.CreateCar(car4);

            Car car5 = new Car();
            car5.Make = "GM";
            car5.Model = "Bolt";
            car5.Year = "2021";
            car5.DriveTrain = "electric";
            _repo.CreateCar(car5);

            Car car6 = new Car();
            car6.Make = "Porche";
            car6.Model = "Tycan";
            car6.Year = "2021";
            car6.DriveTrain = "electric";
            _repo.CreateCar(car6);

            Car car7 = new Car();
            car7.Make = "GM";
            car7.Model = "Hummer";
            car7.Year = "2021";
            car7.DriveTrain = "electric";
            _repo.CreateCar(car7);

            Car car8 = new Car();
            car8.Make = "BMW";
            car8.Model = "i8";
            car8.Year = "2019";
            car8.DriveTrain = "electric";
            _repo.CreateCar(car8);

            Car car9 = new Car();
            car9.Make = "Tesla";
            car9.Model = "Model S";
            car9.Year = "2022";
            car9.DriveTrain = "electric";
            _repo.CreateCar(car9);

            Car car10 = new Car();
            car10.Make = "GM";
            car10.Model = "Volt";
            car10.Year = "2019";
            car10.DriveTrain = "hybrid";
            _repo.CreateCar(car10);
        }

        private void resetScreen()
        {
            Console.Clear();
            Console.WriteLine
                (
                 "Komoto Cafe Menu Management Sytem\n" +
                 "Enter the option you'd like to select:\n" +
                    "1. Add car\n" +
                    "2. Look up all cars \n" +
                    "3. Look up car by car id number\n" +
                    "4. Look up cars by type\n" +
                    "5. Update car by id number\n" +
                    "6. Delete car by id number\n"
                 );
        }

        private void showMenu()
        {
            Console.Clear();
            Console.WriteLine
                (
                 "Komoto Cafe Menu Management Sytem\n" +
                 "Enter the option you'd like to select:\n" +
                    "1. Add car\n" +
                    "2. Look up all cars \n" +
                    "3. Look up car by car id number\n" +
                    "4. Look up cars by type\n" +
                    "5. Update car by id number\n" +
                    "6. Delete car by id number\n"
                 );
            bool continueToRun = true;
            while (continueToRun)
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewCar();
                        break;
                    case "2":
                        LookUpAllCars();
                        break;
                    case "3":
                        LookUpCarByID();
                        break;
                    case "4":
                        LookUpCarsByDrivetrain();
                        break; 
                    case "5":
                        UpdateCarByID();
                        break;
                    case "6":
                        DeleteCarByID();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 6");
                        resetScreen();
                        break;
                }
            }
        }

        private void AddNewCar()
        {
            Console.Clear ();
            Car car = new Car();
            Console.WriteLine("Please enter the make of the car.");
            car.Make = Console.ReadLine();
            Console.WriteLine("Please senter the model of the car.");
            car.Model = Console.ReadLine();
            Console.WriteLine("Please enter the model year of the car.");
            car.Year = Console.ReadLine();
            Console.WriteLine("Please select the type of drivetrain of the car\n" +
                "Enter (1) for electric\n" +
                "Enter (2) for hybrid\n" +
                "Enter (3) for gasoline\n");
            string driveTrainSelection = Console.ReadLine();
            switch (driveTrainSelection)
            {
                case "1":
                    { car.DriveTrain = "electric"; break; }
                case "2":
                    { car.DriveTrain = "hybrid"; break; }
                case "3":
                    { car.DriveTrain = "gasoline"; break; }
                default: { Console.WriteLine("Please enter either 1, 2 or 3"); break; }
            }
            _repo.CreateCar(car);
            Console.WriteLine("Your has been added. Press any key to continue.");
            Console.Read();
            resetScreen();
        }

        private void LookUpAllCars()
        {
            /*List<Car> cars = new List<Car>();*/
            List<Car>cars = _repo.ReadListOfAllCars();
            foreach (Car car in cars)
            {
                Console.WriteLine($"Car ID: {car.Id}");
                Console.WriteLine($"Car Make: {car.Make}");
                Console.WriteLine($"Car Model: {car.Model}");
                Console.WriteLine($"Car Drivetrain: {car.DriveTrain}");
                Console.WriteLine("====================================");
            }
        }

        private void LookUpCarByID()
        {
            Console.Clear();
            Console.WriteLine("Please senter the id number of the car you want to look up");
            int id = int.Parse(Console.ReadLine());
            Car foundCar = _repo.ReadCarById(id);
            Console.WriteLine("=========================");
            Console.WriteLine($"Car ID: {id}.\n" +
                $"Car Make: {foundCar.Make}\n" +
                $"Car Model: {foundCar.Model}\n" +
                $"Model Year: {foundCar.Year}\n" +
                $"Drivetrain: {foundCar.DriveTrain}");
            Console.WriteLine("=========================");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            resetScreen();
        }

        private void LookUpCarsByDrivetrain()
        {
            List<Car> results = new List<Car>();
            Console.WriteLine("Please enter the number for the type of drivetrain you want to look up\n" +
                "Enter (1) for electric\n" +
                "Enter (2) for hybrid\n" +
                "Enter (3) for gasoline\n");
                string response = Console.ReadLine();   
            switch (response)
            {
                case "1": 
                    { 
                        results = _repo.ReadCarByType("electric");
                    }
                    break;
                case "2": { results = _repo.ReadCarByType("hybrid");  } break;
                case "3": { results = _repo.ReadCarByType("gasoline"); } break;
                default: { break; }
            }
            foreach (var item in results)
            {
                Console.WriteLine($"===========================\n" +
                    $"ID: {item.Id}\n" +
                    $"Make: {item.Make}\n" +
                    $"Model: {item.Model}\n" +
                    $"Model Year: {item.Year}\n" +
                    $"Drivetrain: {item.DriveTrain}\n");
            }
            Console.ReadKey();
            resetScreen();
        }

        private void UpdateCarByID()
        {
            Car car = new Car();
            Console.WriteLine("Please enter the id number of the car you want to update.");
            car.Id = int.Parse(Console.ReadLine());
            if(car.Id.GetType() != typeof(int))
            {
                Console.WriteLine("Please make sure you are intering a integer/whole number for the car id number.\n" +
                    "Press any key to start over.");
                resetScreen();
            }
            Console.WriteLine("Enter the make new value for the Make: ");
            car.Make = Console.ReadLine();
            Console.WriteLine("Enter the new value for the Model: ");
            car.Model = Console.ReadLine();
            Console.WriteLine("Enter the new value for the model year: ");
            car.Year = Console.ReadLine();
            Console.WriteLine("Enter the new value for drivetrain (electric, hybrid or gasoline)");
            car.DriveTrain = Console.ReadLine();
            if(car.DriveTrain != "electric" || car.DriveTrain != "hybrid" || car.DriveTrain != "gasoline")
            {
                Console.WriteLine("Enter the new value for drivetrain (electric, hybrid or gasoline)");
            }
            _repo.UpdateExistingCar(car.Id, car);
            Console.WriteLine("Your car information has been updated\n" +
                "Presee any key to continue");
            Console.ReadKey();
            resetScreen();             
        }

        private void DeleteCarByID()
        {
            Car car = new Car(); 
            Console.WriteLine("Please enter the id number of the car you want to delete.");
            car.Id = int.Parse(Console.ReadLine());
            if (car.Id.GetType() != typeof(int))
            {
                Console.WriteLine("Please make sure you are intering a integer/whole number for the car id number.\n" +
                    "Press any key to start over.");
                resetScreen();
            }
            else
            {
                Car carToDelete = _repo.ReadCarById(car.Id);
                _repo.DeleteExistingCar(carToDelete);
            }
            Console.WriteLine("Your card has been delted.\n" +
                "Press any key to continue.");
            resetScreen();
        }
    }

    
}
