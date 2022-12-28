using System.ComponentModel.DataAnnotations;
using System;

namespace EndProject.Models
{
    public class Income
    {
        public int Id { get; set; }
        [Required]
        public string For { get; set; }
        [DisplayFormat(DataFormatString ="{0:N}",ApplyFormatInEditMode = true)]
        public float Money { get; set; }      
        public DateTime StartTime { get; set; }
      
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

    }
}
