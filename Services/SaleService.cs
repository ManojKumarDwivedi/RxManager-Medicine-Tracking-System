using PSDemo_MedicinApp_ByMkd.Models;
using PSDemo_MedicineApp_ByMkd.DTOs;
using PSDemo_MedicineApp_ByMkd.Helpers;
using PSDemo_MedicineApp_ByMkd.Models;

namespace PSDemo_MedicineApp_ByMkd.Services
{
    public class SaleService
    {
        private readonly string path = "Data/sales.json";
        private readonly MedicineService _medicineService = new MedicineService();

        public void AddSale(SaleRecordDto dto)
        {
            var sales = FileHelper.ReadList<SaleRecord>(path);

            // Get medicines
            var medicines = FileHelper.ReadList<Medicine>("Data/medicines.json");

            var med = medicines.FirstOrDefault(x => x.Id == dto.MedicineId);

            // Check if Medicine exists
            if (med == null)
                throw new Exception("Medicine not found");

            // Check for stock validation
            if (med.Quantity < dto.QuantitySold)
                throw new Exception("Not enough stock");

            // Create sale
            var sale = new SaleRecord
            {
                Id = sales.Count + 1,
                MedicineId = dto.MedicineId,
                QuantitySold = dto.QuantitySold,
                SaleDate = DateTime.Now
            };

            sales.Add(sale);

            FileHelper.WriteList(path, sales);

            // Reduce stock
            med.Quantity -= dto.QuantitySold;

            FileHelper.WriteList("Data/medicines.json", medicines);
        }
    }
}
