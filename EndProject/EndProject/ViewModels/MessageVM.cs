using System.ComponentModel.DataAnnotations;

namespace EndProject.ViewModels
{
    public class MessageVM
    {
        [Required]
        public string Message { get; set; }

    }
}
