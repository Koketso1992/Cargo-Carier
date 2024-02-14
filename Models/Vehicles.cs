using System.ComponentModel.DataAnnotations;

namespace Fleet_tracking_system.Models
{
    public class Vehicles
    {
        [Key]
        public int VehicleID { get; set; }
        public string LicensePlate { get; set; }
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public int EngineSize { get; set; }
        public int CurrentOdometerReading { get; set; }
        public int NextServiceOdometer { get; set; }
    }
}
