using System.ComponentModel.DataAnnotations;

namespace Fleet_tracking_system.Models
{
    public class ServiceReport
    {
        [Key]
        public int ReportID { get; set; }
        public int VehicleID { get; set; }
        public string ServiceType { get; set; }
        public DateTime CompletionDate { get; set; }
        public double Cost { get; set; }
    }
}
