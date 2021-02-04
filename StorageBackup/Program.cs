using System;
using System.Data;

namespace StorageBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage hdd = new HDD(1024 * 10, 15) {Name = "Pandora", Model = "HDDMC"};
            Storage ssd = new SSD(1024 * 256, 30) {Name = "Ryzen", Model = "SSDC"};
            Storage flash = new Flash(1024 * 8, 8) {Name = "Sandisk", Model = "SANDISK FLASHCARD"};
            Storage dvd = new DVD(1024, 5) {Name = "DVD", Model = "DVD"};


            //hdd.DeviceInfo();

            //Console.WriteLine();

            //ssd.DeviceInfo();

            //Console.WriteLine();

            //flash.DeviceInfo();

            //Console.WriteLine();
            //dvd.DeviceInfo();

            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    hdd.DeviceInfo();
                    hdd.Copy(1000);
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error: {e.Message}\nError Time: {(e as InsufficientMemoryException).ErrorTime:g}");
                Console.ResetColor();
            }

        }
    }
}
