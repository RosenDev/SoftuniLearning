using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{[Table(nameof(StudentCourse)+"s")]
    public class StudentCourse
    {
        
        public int StudentId { get; set; }
        
        public int CourseId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

    }
}