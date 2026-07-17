using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HETHONGTINHNHUANBUT.Services.AI.Providers
{
    public class OllamaProvider : IAIProvider
    {
        private readonly string _endpoint;
        private readonly string _modelName;
        private readonly HttpClient _httpClient;

        public OllamaProvider(string endpoint, string modelName)
        {
            _endpoint = endpoint;
            _modelName = modelName;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(2);
        }

        public async Task<string> GenerateResponseAsync(string prompt)
        {
            var requestBody = new
            {
                model = _modelName,
                prompt = prompt,
                stream = false,
                options = new { temperature = 0.1 }
            };

            string jsonString = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ollama API Error: {response.StatusCode}");
            }

            string responseJson = await response.Content.ReadAsStringAsync();
            JObject result = JObject.Parse(responseJson);
            
            return result["response"]?.ToString().Replace("**", "").Trim() ?? "...";
        }

        public async Task<string> ExtractJsonAsync(string prompt)
        {
            var requestBody = new
            {
                model = _modelName,
                prompt = prompt,
                format = "json",
                stream = false,
                options = new { temperature = 0.0 }
            };

            string jsonString = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(_endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ollama API Error: {response.StatusCode}");
            }

            string responseJson = await response.Content.ReadAsStringAsync();
            JObject result = JObject.Parse(responseJson);
            
            return result["response"]?.ToString().Trim() ?? "{}";
        }
    }
}
