namespace StorageBackup
{
    static class StorageSizeConverter
    {
        public static decimal ConvertKbToMb(decimal kb)
        {
            return kb / StorageSizes.MbToKb;
        }

        public static decimal ConvertKbToGb(decimal kb)
        {
            return kb / StorageSizes.GbToKb;
        }

        public static decimal ConvertKbToTb(decimal kb)
        {
            return kb / StorageSizes.TbToKb;
        }
    }
}