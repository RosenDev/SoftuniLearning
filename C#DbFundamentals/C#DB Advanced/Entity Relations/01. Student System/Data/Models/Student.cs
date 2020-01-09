using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }
        public ICollection<StudentCourse> CourseEnrollments { get; set; }=new List<StudentCourse>();
        public ICollection<Homework> HomeworkSubmissions{ get; set; }=new List<Homework>();


    }
}