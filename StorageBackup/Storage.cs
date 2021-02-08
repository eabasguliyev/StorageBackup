using System;

namespace StorageBackup
{
    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public double Speed { get; protected set; }
        public decimal Capacity { get; protected set; }
        public decimal Used { get; protected set; }

        public decimal FreeMemory() => Capacity - Used;

        public override string ToString()
        {
            return $@"Name: {Name}
Model: {Model}";
        }

        public abstract void Copy(decimal size);

        public abstract void DeviceInfo();

        public void SizeAndSpeedInfo()
        {
            Console.WriteLine($"Speed: {StorageSizeConverter.ConvertKbToMb((decimal)Speed):F} MBpS");
            Console.WriteLine($"Capacity: {StorageSizeConverter.ConvertKbToGb(Capacity):F} GB");
            Console.WriteLine($"Used: {StorageSizeConverter.ConvertKbToGb(Used):F} GB");
            Console.WriteLine($"Free: {StorageSizeConverter.ConvertKbToGb(FreeMemory()):F} GB");
        }

        protected TimeSpan Calculate(decimal dataSize)
        {

            var t = (double) (StorageSizeConverter.ConvertGbToMb(dataSize) / StorageSizeConverter.ConvertKbToMb((decimal)Speed));
            return TimeSpan.FromSeconds(t);
        }

        public void ShowTransferTime(decimal dataSize)
        {
            var timespan = Calculate(dataSize);
            Console.WriteLine($"Data will be transfer in {timespan.Days} days, {timespan.Hours} hours, {timespan.Minutes} minutes, {timespan.Seconds} seconds, {timespan.Milliseconds} milliseconds.");
        }
    }
}