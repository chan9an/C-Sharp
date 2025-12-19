using System;

namespace Day2Demo
{
    public class LoopsAndSwitch
    {
        // -------------------
        // WHILE LOOP
        // -------------------
        public static void WhileLoopDemo()
        {
            Console.WriteLine("WHILE LOOP:");

            string[] cities = { "Pune", "Chandigarh", "Agra", "Amritsar", "Mumbai" };
            int i = 0;

            while (i < cities.Length)
            {
                Console.WriteLine(cities[i]);
                i++;
            }

            Console.WriteLine();
        }

        // -------------------
        // FOREACH LOOP
        // -------------------
        public static void ForEachLoopDemo()
        {
            Console.WriteLine("FOREACH LOOP:");

            string[] cities = { "Pune", "Chandigarh", "Agra", "Amritsar", "Mumbai" };

            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine();
        }

        // -------------------
        // SWITCH CASE
        // -------------------
        public static void SwitchCaseDemo()
        {
            Console.WriteLine("SWITCH CASE:");

            int choice = 2;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected Option 1");
                    break;

                case 2:
                    Console.WriteLine("You selected Option 2");
                    break;

                case 3:
                    Console.WriteLine("You selected Option 3");
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            Console.WriteLine();
        }
    }
}
