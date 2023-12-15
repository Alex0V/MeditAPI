using Medit.BLL.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Services
{
    public class RecommendationService : IRecommendationService
    {
        public async Task<List<string>> GetRecomendationByNameAsync(string meditName)
        {
            List<string> recomendMedits = new List<string>();
            var apiUrl = "http://127.0.0.1:5000/get_recommendations";
            var title = meditName;
            var requestData = new { title };

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsJsonAsync(apiUrl, requestData);
                    if (response.IsSuccessStatusCode)
                    {
                        var recommendations = await response.Content.ReadAsStringAsync();
                        var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(recommendations);
                        recomendMedits = jsonObject["recommendations"];
                    }
                    else
                    {
                        Console.WriteLine("Не вдалося отримати рекомендації.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
            return recomendMedits;
        }
    }
}
