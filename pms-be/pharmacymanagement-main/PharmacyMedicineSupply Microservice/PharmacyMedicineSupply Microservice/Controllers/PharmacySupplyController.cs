using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyMedicineSupply_Microservice.Entity;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PharmacyMedicineSupply_Microservice.DAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmacyMedicineSupply_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PharmacySupplyController : ControllerBase
    {
        string[] PharmacyNames = new string[] { "Pharmacy1", "Pharmacy2", "Pharmacy3" }; //List of Pharmacy

        List<PharmacyMedicineSupply> PharmacysupplyList = new List<PharmacyMedicineSupply>();

        PharmacySupplyRespo respository = new PharmacySupplyRespo();

        //Post the medicine Deamd and return the pharmacysupplylist with demand
        [HttpPost]
        public async Task<IEnumerable<PharmacyMedicineSupply>> PostDemand(List<MedicineDemand> medicineDemands)
        {
            //handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            List<MedicineDemand> medicineDeamndList = await respository.GetDemandList(medicineDemands);                   //GetMedicineDemandList(medicineDemands);
            for (int i = 0; i < PharmacyNames.Length; i++)
            {
                foreach (MedicineDemand item in medicineDeamndList)
                {
                    PharmacyMedicineSupply temp = new PharmacyMedicineSupply();
                    temp.Pharmacyname = PharmacyNames[i];
                    temp.Medicinename = item.Medicine;
                    temp.Supplycount = Convert.ToInt32(item.DemandCount / PharmacyNames.Length);
                    if (i == 0)
                    {
                        temp.Supplycount += Convert.ToInt32(item.DemandCount % PharmacyNames.Length);
                    }
                    PharmacysupplyList.Add(temp);
                }

            }
            return PharmacysupplyList;

        }

    }
}
