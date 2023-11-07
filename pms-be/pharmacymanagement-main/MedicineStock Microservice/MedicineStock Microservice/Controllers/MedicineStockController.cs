using MedicineStock_Microservice.Model;
using MedicineStock_Microservice.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStock_Microservice.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class MedicineStockController : ControllerBase
    {
        public StockService  _stockService;
        public MedicineStockController(StockService stockService)
        {
            _stockService = stockService;
        }
        
        [HttpGet]
        public IEnumerable<MedicineStock> GetAllMedicineStock()
        {
            var allMedicine = _stockService.GetAllMedicineStock();
            return allMedicine;
        }
    }
}
