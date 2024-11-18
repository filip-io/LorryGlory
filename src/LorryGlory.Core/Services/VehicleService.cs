using LorryGlory.Core.Mappings;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Repositories.IRepositories;
using System.Text;
using System.Text.Json;

namespace LorryGlory.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;
        private readonly string _mockApiUrl = "https://lorryglorymockapiapi20241113130521.azurewebsites.net/api/vehicle/search";
        private readonly ITaskRepository _taskRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(HttpClient client, ITaskRepository taskRepo, IVehicleRepository vehicleRepo)
        {
            _httpClient = client;
            _taskRepository = taskRepo;
            _vehicleRepository = vehicleRepo;
        }

        public Task<VehicleDto> CreateAsync(VehicleDto vehicleDto)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAllVehiclesDto>> GetAllAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();

            var result = vehicles.Select(v => v?.ToGetAllVehiclesDto());

            return result;
        }

        public async Task<IEnumerable<TodaysVehiclesForDriver>> GetAllByDriverIdAndDayAsync(string id, DateOnly date)
        {
            var tasks = await _taskRepository.GetAllByDriverIdAndDayAsync(id, date);
            if (tasks == null) return null;

            var vehicles = tasks.Select(t => new TodaysVehiclesForDriver
            {
                Id = t.Vehicle.Id.ToString(),
                RegNo = t.Vehicle.RegNo,
                Make = t.Vehicle.Make,
                Model = t.Vehicle.Model,
                Color = t.Vehicle.Color,
                Type = t.Vehicle.Type,
                Status = t.Vehicle.Status.Status,
                StartTime = t.StartTime,
                EndTime = t.EndTime
            });

            return vehicles;
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

                if (vehicle == null) return null;

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
