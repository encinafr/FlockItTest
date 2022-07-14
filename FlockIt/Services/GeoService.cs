using FlockIt.Dtos;
using FlockIt.Entities;
using FlockIt.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlockIt.Services
{
    public class GeoService : IGeoService
    {
        public HttpClient _httpClient { get; }

        public GeoService(HttpClient httpClient)
        {
           _httpClient = httpClient;
        }
        public async Task<State> GetStateGeo(string stateName)
        {
            try
            {
                var response = await _httpClient.GetAsync($"provincias?nombre={stateName}");
                var result = JsonConvert.DeserializeObject<GobGeoApiResponseDto.Root>(await response.Content.ReadAsStringAsync());

                return new State() { Id = result.provincias.First().id, Lat = result.provincias.First().centroide.lat, Lon = result.provincias.First().centroide.lon, Nombre = result.provincias.First().nombre };
            }
            catch (System.Exception ex)
            {

                throw;
            }
           

        }
    }
}
