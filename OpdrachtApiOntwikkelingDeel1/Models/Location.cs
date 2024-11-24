using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkelingDeel1.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Image { get; set; } = string.Empty;

        public int BossId { get; set; }
        public Boss Boss { get; set; }
    }
}
