using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyMedicineSupply_Microservice.Entity;
using System.Net.Http;
using Newtonsoft.Json;
namespace PharmacyMedicineSupply_Microservice.DAL
{
    public class PharmacySupplyRespo
    {
        HttpClientHandler handler = new HttpClientHandler();

        //Fetch All the medicine stoke from MedicineStoke API
        //Check for the demand and stoke of medicine in medicineDemand List

        public async Task<List<MedicineDemand>> GetDemandList(List<MedicineDemand> medicineDemands)
        {
            List<MedicineStock> stockList = new List<MedicineStock>();
            List<MedicineDemand> medicineDeamndList = new List<MedicineDemand>();

            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(handler))//handler
            {

                using (var response = await httpClient.GetAsync("https://localhost:44338/api/MedicineStock")) //Call the httpget of MedicineStokeInformation api to fetch  all Medicine stoke info.
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stockList = JsonConvert.DeserializeObject<List<MedicineStock>>(apiResponse);
                }
            }

            foreach (MedicineDemand item in medicineDemands)
            {
                MedicineDemand dem = new MedicineDemand();
                dem.Medicine = item.Medicine;
                MedicineStock stoke = stockList.Where(x => x.Name == item.Medicine).First();
                dem.DemandCount = item.DemandCount > stoke.NumberOfTabletsInStock ? stoke.NumberOfTabletsInStock : item.DemandCount;


                medicineDeamndList.Add(dem);

            }

            return medicineDeamndList;
        }
    }
}
