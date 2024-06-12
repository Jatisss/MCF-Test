using bpkp_fe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace bpkp_fe.Controllers
{
    public class BpkpController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:7033/";

        public async Task<ActionResult> Index()
        {
            List<TrBpkb> BpkpInfo = new List<TrBpkb>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Bpkp/GetAllBpkp");

                if (Res.IsSuccessStatusCode)
                {
                    var BpkpResponse = Res.Content.ReadAsStringAsync().Result;

                    BpkpInfo = JsonConvert.DeserializeObject<List<TrBpkb>>(BpkpResponse);
                }

                return View(BpkpInfo);
            }
        }

        public async Task<ActionResult> SelectLocation()
        {
            List<MsStorageLocation> LocInfo = new List<MsStorageLocation>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Bpkp/GetAllLocation");

                if (Res.IsSuccessStatusCode)
                {
                    var LocResponse = Res.Content.ReadAsStringAsync().Result;

                    LocInfo = JsonConvert.DeserializeObject<List<MsStorageLocation>>(LocResponse);
                }

                return View(LocInfo);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(
        [Bind("AgreementNumber,BranchId,BpkbNo,BpkbDateIn,BpkbDate,FakturNo,FakturDate,PoliceNo")] TrBpkb bpkp)
        {
            if (ModelState.IsValid)
            {
                bpkp.CreatedOn = DateTime.Now;
                bpkp.LastUpdatedOn = DateTime.Now;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.PostAsJsonAsync("api/Bpkp/AddBpkp", bpkp);
                    Res.EnsureSuccessStatusCode();
                    return RedirectToAction(nameof(Index));
                }
               
            }
            return View(bpkp);
        }
    }
}