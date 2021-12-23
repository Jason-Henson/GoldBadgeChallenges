using _01_KomodoCafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        // MUST BE THE SAME NAME AS THE CLASS IN THE REPO
        private readonly MenuItemRepository _repo = new MenuItemRepository();
        public void Run()
        {
            showMenu();
        }

        private void resetScreen()
        {
            Console.Clear();
            Console.WriteLine
                (
                 "Komoto Cafe Menu Management Sytem\n" +
                 "Enter the option you'd like to select:\n" +
                    "1. Add Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. View All Menu Items\n" +
                    "4. Exit\n"
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
                        AddNewItem();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        ViewAllItems();
                        break;
                    case "4":
                        EndProgram();
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4");
                        resetScreen();
                        break;
                }
            }
        }

        private void DeleteItem()
        {
            Console.WriteLine("Please enter the meal number of the item you wish to delete: ");
            int mealNumberToDelete = int.Parse(Console.ReadLine());
            _repo.DeleteMenuItem(mealNumberToDelete);
            Console.WriteLine($"Meal number {mealNumberToDelete} has been removed from the menu");
            resetScreen();
        }

        private void AddNewItem()
        {
            MenuItem newItem = new MenuItem();
            resetScreen();
            Console.WriteLine("Please input the menu item id.");
            newItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the meal name: \n");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Please enter the meal discription: \n");
            newItem.MealDescription = Console.ReadLine();
            bool hasEnteredAllIngredents = false;
            while (hasEnteredAllIngredents == false)
            {
                Console.WriteLine("Please enter meal ingredents: \n");
                var ingredent = Console.ReadLine();
                newItem.MealIngredients.Add(ingredent);
                Console.WriteLine("Would you like any more ingedents y/n: ");
                string userInput = Console.ReadLine();
                if (userInput == "Y".ToLower())
                {
                    continue;
                }
                else
                {
                    hasEnteredAllIngredents = true;
                }
            }

            
            Console.WriteLine("Please enter the meal price \n");
            newItem.MealPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("New meal item sucessfully added!");
            _repo.CreateNewMenuItem(newItem);
            resetScreen();
        }

        private void ViewAllItems()
        {
            Console.Clear();
            List<MenuItem> allItems = _repo.ReadAllMenuItems();
            if (allItems.Count > 0)
            {
                foreach (MenuItem line in allItems)
                {
                    ViewMealDetails(line);
                }
            }
            else
            {
                Console.WriteLine("There are no available menu items.");
            }
            Console.ReadKey();
        }
        private void ViewMealDetails(MenuItem menuItem)
        {
            Console.WriteLine(menuItem.MealInfoShort);
            foreach (var item in menuItem.MealIngredients)
            {
                Console.WriteLine(item);
            }
        }

        private void EndProgram()
        {
            resetScreen();
        }
    }
}

