using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApplication.Models
{
    public class Module
    {
        [Required]
        public int ModuleId { get; set; }

        [Required]
        [Display(Name = "Module name")]
        [StringLength(20)]
        public string ModuleName { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string ModuleDescription { get; set; }

        public Course Course { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Course")]
        public int SelectedCourseId { get; set; }
    }
}