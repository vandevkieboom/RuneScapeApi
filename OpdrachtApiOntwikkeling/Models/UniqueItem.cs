using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpdrachtApiOntwikkeling.Models
{
    public class UniqueItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name can't be longer than 30 characters.")]
        [DefaultValue("Scythe of Vitur")]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [DefaultValue(1621530981)]
        public int? Price { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "High Alch value must be greater than 0.")]
        [DefaultValue(2400000)]
        public int? HighAlch { get; set; } = 1;

        [Url(ErrorMessage = "Please enter a valid URL.")]
        [DefaultValue("https://oldschool.runescape.wiki/w/Scythe_of_vitur#/media/File:Scythe_of_vitur_(uncharged)_detail.png")]
        public string Image { get; set; } = "https://oldschool.runescape.wiki/w/Scythe_of_vitur#/media/File:Scythe_of_vitur_(uncharged)_detail.png";
    }
}
