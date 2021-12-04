using System;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            DateTime datetime;

            Console.WriteLine("Hello! Welcome to the XX Restaurant!");
            Console.WriteLine("Opening hours: 11:00 - 24:00 Mon-Sun");
            Console.WriteLine();
            Console.Write("Please input your operator username: ");
            string name = Console.ReadLine();
            Operator op =new Operator(name);
            
            do
            {
                Console.WriteLine();
                Console.WriteLine("What can I do for you? Please select one from below (Press the Number on your keyboard)");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("1. Check free tables with a certain time");
                Console.WriteLine("2. Make a reservation");
                Console.WriteLine("3. Check the daily Menu");
                Console.WriteLine("Press the Escape (Esc) key to quit:");
                Console.WriteLine("Current time is: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("---------------------------------------------------------------\n");
                input = Console.ReadKey(true);
                //Console.Write(" --- You pressed ");

                // option 1
                if (input.Key == ConsoleKey.D1)
                {
                    Console.Write("---> 1\n");
                    Console.WriteLine("Please input the date and time in format (YYYY-MM-DD HH:MM:SS)");
                    string date = Console.ReadLine();

                    // first check if the input string can be parsed to 'DateTime' data type
                    if (DateTime.TryParse(date, out datetime))
                    {
                        //operate will go and check the availabilities of all the tables
                        op.CheckAvailableTables(datetime);
                    }
                    else
                    {
                        //invalid input string format
                        Console.WriteLine("Sorry, your input time format is invalid.");
                    }
                }

                // option 2
                if (input.Key == ConsoleKey.D2)
                {
                    Console.Write("---> 2\n");
                    Console.WriteLine("Please input the arrival time in format (YYYY-MM-DD HH:MM:SS)");
                    string date = Console.ReadLine();

                    // first check if the input string can be parsed to 'DateTime' data type
                    if (DateTime.TryParse(date, out datetime))
                    {
                        // request the guest name
                        Console.Write("Please input name of the guest:");
                        string guest_name = Console.ReadLine();
                        // request the number of guests
                        Console.Write("Please input number of the guests:");
                        string guest_count_str = Console.ReadLine();
                        int guest_count_num = Int32.Parse(guest_count_str);
                        // make the reservation with the info above
                        op.AssembleReservation(guest_name,guest_count_num,datetime);
                    }
                    else
                    {
                        //invalid input string format
                        Console.WriteLine("Sorry, your input time format is invalid.");
                    }
                }

                // option 3
                if (input.Key == ConsoleKey.D3)
                {
                    Console.Write("---> 3\n");
                    Console.WriteLine("Please input the date the format (YYYY-MM-DD)");
                    string date = Console.ReadLine();
                    
                    // first check if the input string can be parsed to 'DateTime' data type
                    if (DateTime.TryParse(date, out datetime))
                    {
                        //operate will go check the menu
                        op.ShowDailyMenu(datetime);
                    }
                    else
                    {
                        //invalid input string format
                        Console.WriteLine("Sorry, your input time format is invalid.");
                    }
                }
            } while (input .Key != ConsoleKey.Escape);

            Console.WriteLine("See you!");

        }
    }
}
