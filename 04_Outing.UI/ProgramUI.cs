using _04_Komodo_Outings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing.UI
{
    internal class ProgramUI
    {
        private readonly OutingsRepository _repo = new OutingsRepository();
        public void Run()
        {
            Seed();
            showMenu();
        }

        private void Seed()
        {
            AmusementPark amusementPark = new AmusementPark(1, 10, DateTime.Parse("01/01/2021"), 500.00m);
            Concert concert = new Concert(1, 10, DateTime.Parse("05/01/2021"), 1000.00m);
            Golf golf = new Golf(1, 10, DateTime.Parse("06/01/2021"), 2500.00m);

            List<Outing> outings = new List<Outing>() { amusementPark, concert, golf };
            _repo.CreateNewOuting(outings);
        }


        private void resetScreen()
        {
            Console.Clear();
            Console.WriteLine
                (
                 "Komoto Cafe Menu Management Sytem\n" +
                 "Enter the option you'd like to select:\n" +
                    "1. Add Outing\n" +
                    "2. Display All Outings\n" +
                    "3. Calculate Total for All Outings\n" +
                    "4. Calculate Totals for Outings by Type \n"
                 );
        }

        private void showMenu()
        {
            resetScreen();
            bool continueToRun = true;
            while (continueToRun)
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewOuting();
                        break;
                    case "2":
                        DisplayAllOutings();
                        break;
                    case "3":
                        CalculateTotalForAllOutings();
                        break;
                    case "4":
                        CalculateTotalsForOutingsByType();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4");
                        resetScreen();
                        break;
                }
            }
        }

        private void AddNewOuting()
        {
            Console.Clear();
            Outing newItem = new Outing();
            Console.WriteLine("please enter the number of attendees.");
            newItem.Count = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date year/month/day.");
            newItem.Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the total cost of the outing eg. '500.00'.");
            newItem.Total = decimal.Parse(Console.ReadLine());
            _repo.CreateNewOuting(newItem);
            Console.WriteLine("Your ouuting has sucesfully been added to the database.");
        }

        private void DisplayAllOutings()
        {
            Console.Clear();
            var output = _repo.ReadAllOutings();
            foreach (var item in output)
            {
                Console.WriteLine($"All outings: \n {item.ToString()}");
            }
            Console.ReadKey();
        }

        private void CalculateTotalForAllOutings()
        {
            string output = _repo.SumAllOutings().ToString();
            Console.WriteLine($"The toatal for all outings is: ${output}.");
        }

        private void CalculateTotalsForOutingsByType()
        {
            Console.WriteLine("Please enter the type of event you would like a total for:\n " +
                "Enter 1 for Amusement Park.\n" +
                "Enter 2 for Bowling.\n" +
                "Enter 2 for Concert.\n" +
                "Enter 4 for Golg. ");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    {
                        string amount = _repo.SumEventsByType(EventKind.AmusementPark).ToString();
                        Console.WriteLine($"The total for is {amount}.");
                    }
                    break;
                case 2:
                    {
                        string amount = _repo.SumEventsByType(EventKind.Bowling).ToString();
                        Console.WriteLine($"The total for is {amount}.");
                    }
                    break;
                case 3:
                    {
                        string amount = _repo.SumEventsByType(EventKind.Concert).ToString();
                        Console.WriteLine($"The total for is {amount}.");
                    }
                    break;
                case 4:
                    {
                        string amount = _repo.SumEventsByType(EventKind.Golf).ToString();
                        Console.WriteLine($"The total for is {amount}.");
                    }
                    break;
                default:
                    Console.WriteLine("Please enter 1, 2, 3 or 4.");
                    break;
            }

        }

    }
}
