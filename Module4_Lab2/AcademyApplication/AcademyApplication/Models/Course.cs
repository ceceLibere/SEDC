using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AcademyApplication.Models
{
    public class Course
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        [DisplayName("Course name")]
        [StringLength(30)]
        public string CourseName { get; set; }

        public List<Module> Modules { get; set; }
    }
}