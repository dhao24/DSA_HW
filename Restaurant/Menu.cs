using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Menu
    {
        List<MenuItem> menuItems=new List<MenuItem>();

        public Menu()
        {
        }

        public void printDailyMenu(DateTime date)
        {
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

        public void Print_Item_info()
        {
            Console.WriteLine("Name: {0}, Price: {1}, description: {2}", _name, _description, _price);
        }

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
