using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using SkrapaBiluppgifter.Model;

namespace SkrapaBiluppgifter.Controllers
{

    public class ScrapingController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ScrapingController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("skrapa")]
        public async Task<ActionResult<List<ScrapeModel>>> Scrape(string Regnr)
        {
            // Sidan du vill skrapa
            var url = $"https://biluppgifter.se/fordon/{Regnr}";

            // Hämta sidan
            var response = await _httpClient.GetStringAsync(url);

            // Ladda sidan i HtmlAgilityPack
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);


            // Hämta alla ul och li
            var ulNodes = htmlDoc.DocumentNode.SelectNodes("//ul");

            //var labelValuePairs = new List<(string label, string value)>();
            var carInfo = new List<ScrapeModel>();

            foreach (var ul in ulNodes)
            {
                foreach (var li in ul.SelectNodes(".//li"))
                {
                    // Kolla om ul-listan innehåller label-value
                    var findLabel = li.SelectSingleNode(".//span[@class='label']");
                    if (findLabel != null)
                    {
                        // Hitta span med "label" och "value"
                        var label = li.SelectSingleNode(".//span[@class='label']").InnerText.Trim();
                        var value = li.SelectSingleNode(".//span[@class='value']").InnerText.Trim();
                        //labelValuePairs.Add((label, value));
                        Console.WriteLine($"{label}: {value}");
                        var car=new ScrapeModel { label = label, value = value };
                        carInfo.Add(car);
                    }

                }
            }


            // Returnera de skrapade data
            return Ok(carInfo);
        }
    }

}
