using System;
using System.Threading;

namespace StorageBackup
{
    class Flash : HardDisk
    {
        public Flash(decimal capacity, double speed)
        {
            this.Capacity = capacity;
            this.Speed = speed;
        }

        public override void Copy(decimal size)
        {
            if (size > FreeMemory())
                throw new InsufficientMemoryException("There is no sufficient memory in Flash Card!");

            Used += size;
            Thread.Sleep(Convert.ToInt32(Calculate(StorageSizeConverter.ConvertKbToGb(size)).TotalSeconds) * 1000);
        }

        public override void DeviceInfo()
        {
            Console.WriteLine("----------- Flash Card Info ----------- ");
            Console.WriteLine(this);
            this.SizeAndSpeedInfo();
        }
    }
}