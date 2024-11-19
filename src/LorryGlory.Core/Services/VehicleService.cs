using LorryGlory.Core.Models.DTOs;
using LorryGlory.Core.Services.IServices;
using System.Text;
using System.Text.Json;

namespace LorryGlory.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;
        private readonly string _mockApiUrl = "https://lorryglorymockapiapi20241113130521.azurewebsites.net/api/vehicle/search";

        public VehicleService(HttpClient client)
        {
            _httpClient = client;
        }

        public Task<VehicleDto> CreateAsync(VehicleDto vehicleDto)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDto>> GetAllByDriverIdAndDayAsync(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleSearchDto> GetByRegNoAsync(string regNo)
        {
            try
            {
                StringContent jsonContent = new(
                    JsonSerializer.Serialize(new
                    {
                        regNo = regNo
                    }),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync(_mockApiUrl, jsonContent);

                if (!response.IsSuccessStatusCode) return null;

                var result = await response.Content.ReadAsStringAsync();

                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var vehicle = JsonSerializer.Deserialize<VehicleSearchDto>(result, jsonOptions);

                return vehicle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<VehicleDto> UpdateAsync(VehicleDto vehicleDto)
        {
            throw new NotImplementedException();
        }
    }
}
