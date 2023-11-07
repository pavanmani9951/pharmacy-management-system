using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule_Microservice.Entity
{
    public class TreatingAlimentMapMedicine
    {
        public string TreatingAliment { get; set; }
        public List<string> MedicineName { get; set; }
    }
}
