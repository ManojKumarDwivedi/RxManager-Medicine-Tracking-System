using PSDemo_MedicineApp_ByMkd.DTOs;

namespace PSDemo_MedicineApp_ByMkd.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidMedicine(MedicineDto dto)
        {
            return !string.IsNullOrWhiteSpace(dto.FullName)
                   && dto.Price > 0
                   && dto.Quantity >= 0;
        }
    }
}
