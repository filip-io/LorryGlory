namespace LorryGlory.Data.Models.VehicleModels
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateOnly LatestInspection { get; set; }
        public DateOnly InspectionValidUntil { get; set; }
        public int Meter { get; set; } // mätarställning - parsa siffran, kommer som "xxx mil", räkna om till km
    }
}
