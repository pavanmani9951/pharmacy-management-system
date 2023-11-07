using MedicineStock_Microservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStock_Microservice.Data
{
    public class MedicineStockDataContext: DbContext
    {
        public MedicineStockDataContext(DbContextOptions<MedicineStockDataContext> options): base(options)
        {
                
        }

        public DbSet<MedicineStock> MedicineStock { get; set;  }
    }

}
