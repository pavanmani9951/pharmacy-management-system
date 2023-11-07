using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalRepresentativeSchedule_Microservice.Entity;
using MedicalRepresentativeSchedule_Microservice.DAL;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalRepresentativeSchedule_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RepScheduleController : ControllerBase
    {
        RepScheduleRespository respository = new RepScheduleRespository();

        string[] representatives = new string[] { "R1", "R2", "R3" }; //List of representatives

        //Get the Repschedule of 5 days from start Date
        [HttpGet]
        public async Task<IEnumerable<RepSchedule>> Get(DateTime startDate)
        {
            List<Doctor> DocList = respository.GetDoctorList();
            List<TreatingAlimentMapMedicine> TList = await respository.GetMedicineTreatingAlimentMap();//Return List Of trating aliment with Medicine Name
            List<RepSchedule> RepList = new List<RepSchedule>();

            for (int i = 0, j = 0; i < 5; i++, j++)
            {
                if (j == 3)
                {
                    j = 0;
                }
                RepSchedule rep = new RepSchedule();
                if (startDate.DayOfWeek != DayOfWeek.Sunday) //Avoid Sundays
                {
                    rep.Doctorname = DocList[i].Name;
                    rep.DoctorContactnumber = DocList[i].ContactNumber;
                    rep.MeetingSlot = "1 PM-2 PM";
                    rep.Dateofmeeting = startDate.Date;
                    rep.Name = representatives[j];
                    rep.TreatingAlignment = DocList[i].TreatingAlignment;
                    var temp1 = TList.FirstOrDefault(x => x.TreatingAliment == rep.TreatingAlignment); //Get the List of Medicine of  corresponding rep.TreatingAlignment
                    rep.Medicine = temp1.MedicineName;
                    RepList.Add(rep);
                }
                else
                {
                    i--;
                    j--;
                }
                startDate = startDate.AddDays(1);

            }

            return RepList;
        }

      


    }
}
