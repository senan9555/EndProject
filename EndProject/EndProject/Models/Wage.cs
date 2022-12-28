using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EndProject.Models
{
    public class Wage
    {
        public int Id { get; set; }
        [Required]

        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public float Money { get; set; }
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
        public Wage()
        {
            CreateTime = DateTime.Now;
        }
    }
}
