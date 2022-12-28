using System.Collections.Generic;

namespace EndProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Medicine> Medicines { get; set; }
        public bool IsDeactive { get; set; }
    }
}
