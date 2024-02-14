using System.ComponentModel.DataAnnotations;

namespace Fleet_tracking_system.Models
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }
        public int VehicleID { get; set; }
        public string Destination { get; set; }
        public int KilometersTraveled { get; set; }
        public DateTime TripDate { get; set; }
    }
}
