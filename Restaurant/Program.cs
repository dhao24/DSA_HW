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
            Console.WriteLine("Opening hours: 11:00 - 24:00 Mon-Fri");
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
                input = Console.ReadKey();
                Console.Write(" --- You pressed ");
                if (input.Key == ConsoleKey.D1)
                {
                    Console.Write("1\n");
                    Console.WriteLine("Please input the date and time in format (YYYY-MM-DD HH:MM:SS)");
                    string date = Console.ReadLine();
                    if (DateTime.TryParse(date, out datetime))
                    {
                        op.CheckAvailableTables(datetime);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your input time format is invalid.");
                    }

                }

                if (input.Key == ConsoleKey.D2)
                {
                    Console.Write("2\n");
                    Console.WriteLine("Please input the arrival time in format (YYYY-MM-DD HH:MM:SS)");
                    string date = Console.ReadLine();
                    if (DateTime.TryParse(date, out datetime))
                    {
                        Console.Write("Please input name of the guest:");
                        string guest_name = Console.ReadLine();
                        Console.Write("Please input number of the guests:");
                        string guest_count_str = Console.ReadLine();
                        int guest_count_num = Int32.Parse(guest_count_str);

                        op.AssembleReservation(guest_name,guest_count_num,datetime);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your input time format is invalid.");
                    }

                }

                if (input.Key == ConsoleKey.D3)
                {
                    Console.Write("3\n");
                    Console.WriteLine("Please input the date the format (YYYY-MM-DD)");
                    string date = Console.ReadLine();
                    
                    if (DateTime.TryParse(date, out datetime))
                    {
                        op.ShowDailyMenu(datetime);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, your input time format is invalid.");
                    }


                }

                //if ((input.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                //if ((input.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                //Console.WriteLine(input.Key.ToString());
            } while (input .Key != ConsoleKey.Escape);

            Console.WriteLine("See you!");

        }
    }
}
