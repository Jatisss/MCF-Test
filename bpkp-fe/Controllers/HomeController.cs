using bpkp_fe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace bpkp_fe.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "https://localhost:7033/";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(MsUser objUser)
        {
            List<MsUser> UserInfo = new List<MsUser>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Bpkp/GetAllUser");

                if (Res.IsSuccessStatusCode)
                {
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;

                    UserInfo = JsonConvert.DeserializeObject<List<MsUser>>(UserResponse);
                }

                var obj = UserInfo.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj == null)
                {
                    //Session["UserID"] = obj.UserId.ToString();
                    //Session["UserName"] = obj.UserName.ToString();
                    return RedirectToAction("Login");
                }

                if (!obj.IsActive)
                {
                    //Session["UserID"] = obj.UserId.ToString();
                    //Session["UserName"] = obj.UserName.ToString();
                    return RedirectToAction("Login");
                }

                return RedirectToAction("Index");
            }
        }
    }
}
