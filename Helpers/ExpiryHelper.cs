namespace PSDemo_MedicineApp_ByMkd.Helpers
{
    public static class ExpiryHelper
    {
        public static bool IsExpiringSoon(DateTime expiryDate)
        {
            return (expiryDate - DateTime.Now).TotalDays < 30;
        }
    }
}
