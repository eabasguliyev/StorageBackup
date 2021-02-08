using System;
using System.Threading;

namespace StorageBackup
{
    class DVD : Storage
    {
        public bool DoubleSide { get; protected set; }    
        public DVD(decimal capacity, double speed, bool doubleSide = false)
        {
            if (doubleSide)
                this.Capacity = capacity * 2;
            else
                this.Capacity = capacity;

            DoubleSide = doubleSide;
            Speed = speed;
        }
        
        public override void Copy(decimal size)
        {
            if (size > FreeMemory())
                throw new InsufficientMemoryException("There is no sufficient memory in DVD Disk!");

            Used += size;
            Thread.Sleep(Convert.ToInt32(Calculate(StorageSizeConverter.ConvertKbToGb(size)).TotalSeconds) * 1000);
        }
        public override void DeviceInfo()
        {
            Console.WriteLine("----------- DVD Disk Info ----------- ");
            Console.WriteLine(this);
            Console.WriteLine("Double Side: {0}", (DoubleSide) ? "Yes" : "No");
            this.SizeAndSpeedInfo();
        }    
    }
}