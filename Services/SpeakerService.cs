
using dotnetnotts.Model;
using System.Net.Http.Headers;
using System.Text.Json;
namespace dotnetnotts.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly HttpClient _httpClient;

        public SpeakerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<Speakers>> GetSpeakersAsync()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "https://sessionize.com/api/v2/eq1opc2o/view/speakers");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Speakers>>(content,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }) ?? Enumerable.Empty<Speakers>();



        }
    }
}
