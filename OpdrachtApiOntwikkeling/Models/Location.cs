using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpdrachtApiOntwikkeling.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        [DefaultValue("Theatre of Blood")]
        public string Name { get; set; } = string.Empty;

        [DefaultValue("It is a large arena used by the ruling vampyres to host blood sports")]
        public string Description { get; set; } = string.Empty;

        [Url(ErrorMessage = "Please enter a valid URL.")]
        [DefaultValue("https://oldschool.runescape.wiki/images/Fighting_Verzik_Vitur.png?0bea5")]
        public string Image { get; set; } = "https://oldschool.runescape.wiki/images/Fighting_Verzik_Vitur.png?0bea5";

        public int? BossId { get; set; } //nullable

        public Boss? Boss { get; set; }
    }
}
