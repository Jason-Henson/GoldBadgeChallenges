using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItemRepository
    {
        protected readonly List<MenuItem> _menuItems = new List<MenuItem>();

        //Create 
        public bool CreateNewMenuItem(MenuItem newItem)
        {
            int startingCount = _menuItems.Count;
            _menuItems.Add(newItem);
            return true;
        }

        //Read
        public List<MenuItem> ReadAllMenuItems()
        {
            return _menuItems;
        }


        //Delete
        public bool DeleteMenuItem(int menuItemId)
        {
            if(0 < _menuItems.Count)
            {
                foreach (var item in _menuItems)
                {
                    if(item.MealNumber == menuItemId)
                    {
                        _menuItems.Remove(item);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
