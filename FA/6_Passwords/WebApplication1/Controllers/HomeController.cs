using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            if(TempData["message"] != null)
            {
                ViewBag.message = TempData["message"].ToString();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string guessedPassword, string difficulty, string action)
        {
            string message = string.Empty;
            if(action == "Odešli")
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.Accept.Add(new("application/json"));
                string response = await GetResponse(client, guessedPassword, difficulty);
                message = response;
            }
            else if(action == "Prolom pomocí C#")
            {
                List<string> input = new List<string>();
                List<string> combinations = new List<string>();
                DateTime start = DateTime.Now;
                TimeSpan delta;

                switch(difficulty)
                {
                    case "0":
                        input = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        combinations = Combinations(input, 4, "");
                        break;
                    case "1":
                        input = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        combinations = Combinations(input, 5, "");
                        break;
                    case "2":
                        input = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                        combinations = Combinations(input, 4, "");
                        break;
                    case "3":
                        input = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        combinations = Combinations(input, 4, "");
                        break;
                    case "4":
                        input = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                            "?", "!", "@", "+", "-", ".", "," };
                        combinations = Combinations(input, 4, "");
                        break;
                }

                using HttpClient client = new();

                client.DefaultRequestHeaders.Accept.Add(new("application/json"));

                for (int i = 0; i < combinations.Count; i++)
                {
                    string response = await GetResponse(client, combinations[i], difficulty);
                    if(response == "OK")
                    {
                        delta = DateTime.Now - start;
                        message = "Správné heslo: " + combinations[i] + ", počet pokusů: " + (i + 1) +  ", počet sekund: " + delta.TotalSeconds;
                        break;
                    }    
                }
            }
            TempData["message"] = message;
            return RedirectToAction(nameof(Index));
        }

        public static async Task<string> GetResponse(HttpClient client, string guessedPassword, string difficulty)
        {
            string url = "http://localhost/pass.php"; 
            Dictionary<string, string> postData = new();
            postData["difficulty"] = difficulty;
            postData["guessedPassword"] = guessedPassword;

            HttpRequestMessage request = new(HttpMethod.Post, url);
            request.Content = new FormUrlEncodedContent(postData);

            HttpResponseMessage response = await client.SendAsync(request);

            return response.Content.ReadAsStringAsync().Result;
        }

        public List<string> Combinations(List<string> input, int length, string curstr)
        {
            if (curstr.Length == length)
            {
                return new List<string> { curstr };
            }
            List<string> ret = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                ret.AddRange(Combinations(input, length, curstr + input[i]));
            }
            return ret;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}