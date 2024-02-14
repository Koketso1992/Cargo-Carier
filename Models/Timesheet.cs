using System.ComponentModel.DataAnnotations;

namespace Fleet_tracking_system.Models
{
    public class Timesheet
    {
        [Key]
        public int TimesheetID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
    }
}
