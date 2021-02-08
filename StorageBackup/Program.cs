using System;
using System.Data;

namespace StorageBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage[] storageDisks =
            {
                new HDD(1024 * 1024 * 1024, 1024 * 210) {Name = "Seagate FireCuda Gaming (ST1000DX002)", Model = "Seagate"},
                new SSD(1024 * 1024 * 512, 1024*3480) {Name = "Gigabyte Aorus RGB (GP-ASM2NE2512GTTDR)", Model = "Gigabyte"},
                new Flash(1024 * 1024 * 64, 1024*1024*5) {Name = "Kingston DataTraveler SE9 DTSE9G2", Model = "Kingston"},
                new DVD(1024 * 1024 * 4, 1024*2) {Name = "Verbatim DVD-R 4.7GB", Model = "Verbatim"},
            };
            

            while (true)
            {
                Console.WriteLine("Enter data size [GB] : ");

                var dataSize = ConsoleScreen.InputDataSize();

                Console.Clear();

                var mainMenuLoop = true;

                while (mainMenuLoop)
                {
                    ConsoleScreen.PrintMenu(ConsoleScreen.MainMenuOptions);

                    var mainMenuChoice = ConsoleScreen.InputChoice(ConsoleScreen.MainMenuOptions.Length);

                    Console.Clear();

                    if ((MainMenuOptions)mainMenuChoice == MainMenuOptions.BACK)
                        break;

                    var storageMenuLoop = true;

                    while (storageMenuLoop)
                    {
                        ConsoleScreen.PrintMenu(ConsoleScreen.StorageMenuOptions);

                        var storageMenuChoice = ConsoleScreen.InputChoice(ConsoleScreen.StorageMenuOptions.Length);

                        Console.Clear();

                        switch ((StorageMenuOptions)storageMenuChoice)
                        {
                            case StorageMenuOptions.TRANSFERDATA:
                            {
                                try
                                {
                                    Console.WriteLine("Data transfering started.");
                                    storageDisks[mainMenuChoice - 1].ShowTransferTime(dataSize);
                                    storageDisks[mainMenuChoice - 1].Copy(StorageSizeConverter.ConvertGbToKb(dataSize));
                                    Console.WriteLine("Operation completed!");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                ConsoleScreen.Clear();
                                break;
                            }

                            case StorageMenuOptions.TRANSFERTIME:
                            {
                                storageDisks[mainMenuChoice - 1].ShowTransferTime(dataSize);
                                ConsoleScreen.Clear();
                                break;
                            }

                            case StorageMenuOptions.DEVICEINFO:
                            {
                                storageDisks[mainMenuChoice - 1].DeviceInfo();
                                ConsoleScreen.Clear();
                                break;
                            }
                            case StorageMenuOptions.BACK:
                            {
                                storageMenuLoop = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
