using PSDemo_MedicinApp_ByMkd.Models;
using PSDemo_MedicineApp_ByMkd.DTOs;
using PSDemo_MedicineApp_ByMkd.Helpers;

namespace PSDemo_MedicineApp_ByMkd.Services
{
    public class MedicineService
    {
        private readonly string path = "Data/medicines.json";

        public List<Medicine> GetAll()
        {
            return FileHelper.ReadList<Medicine>(path);
        }

        public void Add(MedicineDto dto)
        {
            var medicines = GetAll();

            var medicine = new Medicine
            {
                Id = medicines.Count + 1,
                FullName = dto.FullName,
                Notes = dto.Notes,
                ExpiryDate = dto.ExpiryDate,
                Quantity = dto.Quantity,
                Price = dto.Price,
                Brand = dto.Brand
            };

            medicines.Add(medicine);
            FileHelper.WriteList(path, medicines);
        }

        public void ReduceStock(int medicineId, int qty)
        {
            var medicines = GetAll();
            var med = medicines.FirstOrDefault(x => x.Id == medicineId);

            if (med != null)
            {
                med.Quantity -= qty;
                FileHelper.WriteList(path, medicines);
            }
        }
    }
}
