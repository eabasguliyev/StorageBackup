using System;

namespace StorageBackup
{
    enum MainMenuOptions
    {
        HDD=1, SSD, FLASH, DVD, BACK
    }

    enum StorageMenuOptions
    {
        TRANSFERDATA = 1, TRANSFERTIME, DEVICEINFO, BACK
    }

    public static class ConsoleScreen
    {
        public static string[] MainMenuOptions { get; set; }
        public static string[] StorageMenuOptions { get; set; }

        static ConsoleScreen()
        {
            MainMenuOptions = new string[]{ "HDD", "SSD", "FLASH", "DVD", "Back"};
            StorageMenuOptions = new string[] {"Transfer data", "Show how long the transfer will take", "Device Info", "Back"};
        }

        public static int InputChoice(int length)
        {
            while (true)
            {
                Console.Write(">> ");

                var status = int.TryParse(Console.ReadLine(), out int choice);

                if (status)
                {
                    if (choice > 0 && choice <= length)
                        return choice;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Input must be between [ 1 - {length} ]!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter numeric value!");
                }
                Console.ResetColor();
            }
        }

        public static decimal InputDataSize()
        {
            while (true)
            {
                Console.Write(">> ");
                var status = decimal.TryParse(Console.ReadLine(), out decimal size);

                if (status)
                {
                    return size;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter numeric value!");
                    Console.ResetColor();
                }
            }
        }

        public static void PrintMenu(string[] options)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.ResetColor();
        }

        public static void Clear()
        {
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
            Console.Clear();
        }
    }
}