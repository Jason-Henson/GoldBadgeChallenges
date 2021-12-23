using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItem
    {
        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; } = new List<string>();
        public decimal MealPrice { get; set; }
        public string MealInfoShort
            {
            get
                {
                return
                    $"Meal Info:\n +" +
                    $"Meal Number: {MealNumber}\n +" +
                    $"Meal Name: {MealDescription}\n +" +
                    $"Meal Price: {MealPrice}\n" +
                    $"====================================\n +" +
                    $"";
                }
            }
        public override string ToString()
        {
                    return
                    $"Meal Info:\n +" +
                    $"Meal Number: {MealNumber}\n +" +
                    $"Meal Name: {MealDescription}\n +" +
                    $"Meal Price: {MealPrice}\n" +
                    $"====================================\n +" +
                    $"";
        }
    }
}
