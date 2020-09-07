using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StaffArtsofte.Models
{
    public class LanguageModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Язык программирования")]
        public string Name { get; set; }
    }
}
