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
Model: {Model}
Speed: {Speed}
Capacity: {Capacity} KB
Used: {Used} KB
Free: {FreeMemory()} KB";
        }

        public abstract void Copy(decimal size);

        public abstract void DeviceInfo();
    }
}