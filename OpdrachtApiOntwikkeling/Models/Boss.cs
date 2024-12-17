using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpdrachtApiOntwikkeling.Models
{
    public class Boss
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        [DefaultValue("Verzik Vitur")]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Hitpoints must be greater than 0.")]
        [DefaultValue(4000)]
        public int? Hitpoints { get; set; } = 4000;

        [Range(1, int.MaxValue, ErrorMessage = "Combat Level must be greater than 0.")]
        [DefaultValue(1040)]
        public int? CombatLevel { get; set; } = 1040;

        [Url(ErrorMessage = "Please enter a valid URL.")]
        [DefaultValue("https://oldschool.runescape.wiki/images/thumb/Verzik_Vitur.png/800px-Verzik_Vitur.png?cfc15")]
        public string Image { get; set; } = "https://oldschool.runescape.wiki/images/thumb/Verzik_Vitur.png/800px-Verzik_Vitur.png?cfc15";

        public int? UniqueItemId { get; set; } //nullable

        public UniqueItem? UniqueItem { get; set; }
    }
}
