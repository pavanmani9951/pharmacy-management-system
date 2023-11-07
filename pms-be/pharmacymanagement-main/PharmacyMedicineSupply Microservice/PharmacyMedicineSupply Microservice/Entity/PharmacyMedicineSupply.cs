using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupply_Microservice.Entity
{
    public class PharmacyMedicineSupply
    {
        public string Pharmacyname { get; set; }
        public string Medicinename { get; set; }
        public int Supplycount { get; set; }
    }
}
