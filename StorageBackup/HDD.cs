using System;
using System.Threading;

namespace StorageBackup
{
    class HDD : HardDisk
    {
        public HDD(decimal capacity, double speed)
        {
            this.Capacity = capacity;
            this.Speed = speed;
        }
        public override void Copy(decimal size)
        {
            if (size > FreeMemory())
                throw new InsufficientMemoryException("There is no sufficient memory in HDD!");

            Used += size;
            Thread.Sleep(Convert.ToInt32(Calculate(StorageSizeConverter.ConvertKbToGb(size)).TotalSeconds) * 1000);
        }

        public override void DeviceInfo()
        {
            Console.WriteLine("----------- HDD Info ----------- ");
            Console.WriteLine(this);
            this.SizeAndSpeedInfo();
        }
    }
}