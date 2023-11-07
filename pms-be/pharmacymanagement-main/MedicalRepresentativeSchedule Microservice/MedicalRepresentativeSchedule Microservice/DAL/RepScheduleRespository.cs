using MedicalRepresentativeSchedule_Microservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MedicalRepresentativeSchedule_Microservice.DAL
{
    public class RepScheduleRespository
    {
        HttpClientHandler handler = new HttpClientHandler();
        List<Doctor> DocList = new List<Doctor>() {
           new Doctor(){Name="D1",ContactNumber="9884122113",TreatingAlignment="Orthopaedics"},
           new Doctor(){Name="D2",ContactNumber="9884122113",TreatingAlignment="General"},
           new Doctor(){Name="D3",ContactNumber="9884122113",TreatingAlignment="General"},
           new Doctor(){Name="D4",ContactNumber="9884122113",TreatingAlignment="Orthopaedics"},
           new Doctor(){Name="D5",ContactNumber="9884122113",TreatingAlignment="Gynaecology"}
        };

        //return List of Doctors
        public List<Doctor> GetDoctorList()
        {
            return DocList;
        }

        //Return List of TreatingAliment and corresponding list of medicine in that aliment
        public async Task<List<TreatingAlimentMapMedicine>> GetMedicineTreatingAlimentMap()
        {
            List<MedicineStock> stockList = new List<MedicineStock>();
            List<TreatingAlimentMapMedicine> TreatingAlimentList = new List<TreatingAlimentMapMedicine>();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(handler))//handler
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(medicineDemands), Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync("https://localhost:44338/api/MedicineStock")) //Call the httpget of MedicineStokeInformation api to fetch  all Medicine stoke info.
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stockList = JsonConvert.DeserializeObject<List<MedicineStock>>(apiResponse);
                }
            }

            foreach (MedicineStock item in stockList)
            {
                TreatingAlimentMapMedicine obj = new TreatingAlimentMapMedicine();
                if (TreatingAlimentList.Find(x => x.TreatingAliment == item.TargetAilment) == null)
                {
                    obj.TreatingAliment = item.TargetAilment;
                    obj.MedicineName = stockList.Where(x => x.TargetAilment == obj.TreatingAliment).Select(y => y.Name).ToList();
                    TreatingAlimentList.Add(obj);
                }
            }

            return TreatingAlimentList;
        }
    }
}
