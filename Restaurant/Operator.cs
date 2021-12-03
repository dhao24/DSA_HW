using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Operator
    {
        string _name;
        Menu menu = new Menu();
        List<Table> tables = new List<Table>();

        public Operator(string name)
        {
            this._name = name;
            loadSettings();
        }

        public void CheckAvailableTables(DateTime dateTime)
        {
            Console.Write("Available tables are:");

            StringBuilder sb = new StringBuilder();
            foreach (var table in tables)
            {
                if (table.IsAvailable(dateTime))
                {
                    sb.AppendFormat(" {0}",table.Id);
                }
            }
            if (sb.Length==0)
            {
                sb.Append(" Sorry, no available tables\n");
            }
        }

        public bool AssembleReservation(string guest_name, int guest_count, DateTime arrival_time)
        {
            foreach (var table in tables)
            {
                if (table.AddReservation(guest_name,guest_count,arrival_time))
                {
                    Console.WriteLine("Reservation Success!");
                    return true;
                }
            }
            Console.WriteLine("Reservation Failed");
            return false;
        }

        public void ShowDailyMenu(DateTime date)
        {
            menu.printDailyMenu(date);
        }

        void loadSettings()
        {
            // create 5 tables
            for (int i = 0; i < 5; i++)
            {
                tables.Add(new Table(i));
            }

            menu.AddMenuItem("Peach and strawberry biscuits", "Crunchy biscuits made with fresh peach and strawberries", 300, DayOfWeek.Monday);
            menu.AddMenuItem("Currant and courgette cake", "Moist cake made with fresh currant and courgette", 300, DayOfWeek.Tuesday);
            menu.AddMenuItem("Squash and monkfish curry", "Mild curry made with pattypan squash and monkfish", 300, DayOfWeek.Wednesday);
            menu.AddMenuItem("Plaice and pepper salad", "A crisp salad featuring plaice and orange pepper", 300, DayOfWeek.Thursday);
            menu.AddMenuItem("Venison and curly kale salad", "A crisp salad featuring venison and curly kale", 300, DayOfWeek.Friday);
            menu.AddMenuItem("Pancetta and avocado fusilli", "Fresh egg pasta in a sauce made from smoked pancetta and", 300, DayOfWeek.Saturday);
            menu.AddMenuItem("Garam masala and squash bread", "Crunchy bread made with garam masala and pattypan squash", 300, DayOfWeek.Sunday);
            menu.AddMenuItem("Duck and chilli skewers", "amboo skewers loaded with duck and firey chilli", 300, DayOfWeek.Monday);
            menu.AddMenuItem("Salmon and pecan crepes", "Fluffy crepes filled with freshly-caught salmon and pecan", 300, DayOfWeek.Tuesday);
            menu.AddMenuItem("Chervil and red cabbage salad", "Chervil and red cabbage served on a bed of lettuce", 300, DayOfWeek.Tuesday);
        }
    }
}
