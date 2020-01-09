using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {[Key]
        public int HomeworkId { get; set; }
       [Column(TypeName = "varchar(50)")]
       [Required]
        public string Content { get; set; }
        [Required]
        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }


    }
}