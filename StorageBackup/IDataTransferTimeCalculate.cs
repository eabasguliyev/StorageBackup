using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBackup
{
    public interface IDataTransferTimeCalculate
    {
        TimeSpan Calculate(decimal dataSize);
    }
}
