namespace EndProject.Models
{
    public class Showcase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeactive { get; set; }
    }
}
