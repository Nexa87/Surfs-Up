using Microsoft.Build.Construction;
using SurfsUpv3.Migrations;
using SurfsUpv3.Models;
using System.Net.Http.Json;
namespace SurfsUpv3.Services
{
    public class SurfboardService
    {
        private readonly HttpClient _httpclient;
        public SurfboardService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<IEnumerable<Surfboard>> GetSurfboardsAsync()
        {
            var response = await _httpclient.GetAsync("api/surfboards");
            if (response.IsSuccessStatusCode)
            {
                var surfboards = await response.Content.ReadFromJsonAsync<IEnumerable<Surfboard>>("http://localhost:5055/weatherforecast/surfboard");
                return surfboards;
            }
            else
            {
                throw new Exception("No surfboards found");
            }

            
        }
    }

     
}
