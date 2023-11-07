using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule_Microservice.Entity
{
    public class RepSchedule
    {

        public string Name { get; set; }
        public string Doctorname { get; set; }
        public string MeetingSlot { get; set; }
        public DateTime Dateofmeeting { get; set; }
        public string DoctorContactnumber { get; set; }

        public string TreatingAlignment { get; set; }

        public List<string>  Medicine { get; set; }
    }
}
