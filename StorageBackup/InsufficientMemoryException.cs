using System;

namespace StorageBackup
{
    class InsufficientMemoryException : ApplicationException
    {
        public DateTime ErrorTime { get; private set; }

        public InsufficientMemoryException(string message):base(message)
        {
            ErrorTime = DateTime.Now;
        }
    }
}