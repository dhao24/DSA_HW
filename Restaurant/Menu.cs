using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Menu
    {
        List<MenuItem> menuItems=new List<MenuItem>();

        /*
        Class Menu
        Print all the menu item according the day of the week
        Parameters: DateTime
        Return: void
        Procedures:
        1) loop every item
        2) print the menu information if they are available on that day of the week
        */
        public void printDailyMenu(DateTime date)
        {
            Console.WriteLine("Menu for {0}:",date.DayOfWeek.ToString());
            foreach (var item in menuItems)
            {
                if (item.CheckAvailableDay(date.DayOfWeek))
                {
                    item.Print_Item_info();
                }                
            }
        }

        public void AddMenuItem(string name, string description, int price, DayOfWeek dayOfWeek)
        {
            menuItems.Add(new MenuItem(name, description, price, dayOfWeek));
        }
    }

    public class MenuItem
    {
        string _name;
        string _description;
        int _price;
        List<DayOfWeek> _availableDays= new List<DayOfWeek>();

        public MenuItem(string name, string description, int price, DayOfWeek dayOfWeek)
        {
            this._name = name;
            this._description = description;
            this._price = price;
            _availableDays.Add(dayOfWeek);
        }

        // print the inforamtion of the item
        public void Print_Item_info()
        {
            Console.WriteLine();
            Console.WriteLine("Name: {0}\nPrice: {1}\ndescription: {2}", _name, _price, _description);
        }

        // check if the day of week include in the '_availableDays' attribute of the MenuItem
        public bool CheckAvailableDay(DayOfWeek day)
        {
            if (_availableDays.Contains(day))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
