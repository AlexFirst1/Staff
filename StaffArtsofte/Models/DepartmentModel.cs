using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StaffArtsofte.Models
{
    public class DepartmentModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Отдел")]
        public string Name { get; set; }       
    }
}
