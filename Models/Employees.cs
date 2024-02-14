using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fleet_tracking_system.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

        
        public string Email { get; set; }

        public string JobTitle { get; set; }

        
        public DateTime HireDate { get; set; }

        
        public string PhoneNumber { get; set; }
    }
}
