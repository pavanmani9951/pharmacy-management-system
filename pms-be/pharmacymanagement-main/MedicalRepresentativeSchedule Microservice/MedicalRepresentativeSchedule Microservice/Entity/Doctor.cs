using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule_Microservice.Entity
{
    public class Doctor
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string TreatingAlignment { get; set; }
    }
}
