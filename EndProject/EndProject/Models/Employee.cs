using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public Position Position { get; set; }
        public int PositionId { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public string Wage { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public bool IsDeactive { get; set; }
    }
}
