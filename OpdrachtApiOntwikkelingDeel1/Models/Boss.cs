using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Models
{
    public class Boss
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Hitpoints must be greater than 0.")]
        public int Hitpoints { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Combat Level must be greater than 0.")]
        public int CombatLevel { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Image { get; set; } = string.Empty;

        public int UniqueItemId { get; set; }
        public UniqueItem? UniqueItem { get; set; }
    }
}
