using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffArtsofte.Models
{
    public class EmployeeInfo
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        public string  Surname { get; set; }
        [Required]
        [DisplayName("Возраст")]
        public int Age { get; set; }
        [Required]
        [DisplayName("Отдел")]
        public string Department { get; set; }
        [Required]
        [DisplayName("Язык программирования")]
        public string DepartmentName => Department == "1" ? "Отдел 1" : Department == "2" ? "Отдел 2" : Department == "3" ? "Отдел 3" : "";
        [Required]
        [DisplayName("Язык программирования")]
        public string Language { get; set; }

        [Required]
        [DisplayName("Язык программирования")]
        public string LanguageName => Language == "1" ? "php" : Language == "2" ? "c#" : Language == "3" ? "java" : "";
    }
}
