using System.ComponentModel.DataAnnotations;

namespace AcademyApplication.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "Student full name")]
        [StringLength(10)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please provide e-mail address")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\S+@\S+$")]
        public string StudentEmail { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string StudentInfo { get; set; }

        public Course Course { get; set; }
    }
}