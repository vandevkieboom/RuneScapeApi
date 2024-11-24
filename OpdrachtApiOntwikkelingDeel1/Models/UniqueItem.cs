using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkelingDeel1.Models
{
    public class UniqueItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public int Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "High Alch value must be a non-negative value.")]
        public int HighAlch { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Image { get; set; } = string.Empty;
    }
}
