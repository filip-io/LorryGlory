namespace LorryGlory.Api.Models.DataTransferObjects.VehicleDtos;

public class GetTodaysVehiclesDto
{
    public string StaffId { get; set; }
    public DateOnly Day { get; set; }
}

