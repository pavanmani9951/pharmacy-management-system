using MedicineStock_Microservice.Data;
using MedicineStock_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStock_Microservice.Services
{
    public class StockService
    {
        private MedicineStockDataContext _context;
        public StockService(MedicineStockDataContext context)
        {
            _context = context;
        }


        public List<MedicineStock> GetAllMedicineStock() => _context.MedicineStock.ToList();

    }
}

