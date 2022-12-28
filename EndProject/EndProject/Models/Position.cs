using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndProject.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDeactive { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
