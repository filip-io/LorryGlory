using LorryGlory.Core.Mappings;
using LorryGlory.Core.Models.ApiDtos;
using LorryGlory.Core.Models.DTOs.VehicleDtos;
using LorryGlory.Core.Services.IServices;
using LorryGlory.Data.Repositories.IRepositories;
using LorryGlory.Data.Services.IServices;
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
        private readonly ITenantService _tenantService;

        public VehicleService(HttpClient client, ITaskRepository taskRepo, IVehicleRepository vehicleRepo, ITenantService tenantService)
        {
            _httpClient = client;
            _taskRepository = taskRepo;
            _vehicleRepository = vehicleRepo;
            _tenantService = tenantService;
        }

        public async Task<VehicleDto> CreateAsync(CreateVehicleDto vehicleDto)
        {
            if (vehicleDto == null) return null;

            Guid? tenantId = null;
            //if (isAdmin)
            //{
            //    tenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709"); // Use the _tenantService instead.
            //    // TODO: Also get company.
            //}
            //var tenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709");

            try
            {
                var vehicle = VehicleMapper.ToVehicle(vehicleDto, tenantId);

                vehicle = await _vehicleRepository.AddAsync(vehicle);

                var result = vehicle.ToVehicleDto();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VehicleDto> DeleteAsync(Guid id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id, true);
            var result = await _vehicleRepository.DeleteAsync(vehicle);

            return result?.ToVehicleDto() ?? null;
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

        public async Task<VehicleDto> GetByIdAsync(Guid id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id, false);
            if (vehicle == null) return null;

            var vehicleDto = vehicle.ToVehicleDto();
            return vehicleDto;
        }

        /// <summary>
        /// Retrieves a vehicle using the mock api. The vehicle is returned to the front end, where it will be confirmed by a user.
        /// </summary>
        /// <param name="regNo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
