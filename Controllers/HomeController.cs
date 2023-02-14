using AltoHttp;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using tiktok.Models;
using System.Web;
using System.ComponentModel;

namespace tiktok.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["ShowData"] = "none";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string videoUrl)
        {
            if(videoUrl != null)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://tiktok-downloader-download-tiktok-videos-without-watermark.p.rapidapi.com/vid/index?url={videoUrl}"),
                    Headers =
                {
                    { "X-RapidAPI-Key", "1a1dd8d20amsh9f57cb9363b78d2p1d9416jsnef806e1b3281" },
                    { "X-RapidAPI-Host", "tiktok-downloader-download-tiktok-videos-without-watermark.p.rapidapi.com" },
                },
                };

                using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var tiktokVideo = "";
                var tiktokCover = "";
                var tiktokDescription = "";
                try
                {
                    var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
                    var videoArray = json["video"] as Newtonsoft.Json.Linq.JArray;
                    tiktokVideo = videoArray[0].ToString();

                    var coverArray = json["cover"] as Newtonsoft.Json.Linq.JArray;
                    tiktokCover = coverArray[0].ToString();

                    var descriptionArray = json["description"] as Newtonsoft.Json.Linq.JArray;
                    tiktokDescription = descriptionArray[0].ToString();
                }
                catch (Exception ex)
                {
                    // handle error
                }



                ViewData["TikTokVideo"] = tiktokVideo;
                ViewData["TikTokCover"] = tiktokCover;
                ViewData["TikTokDescription"] = tiktokDescription;
                ViewData["ShowData"] = "flex";
            }
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

     


}
}