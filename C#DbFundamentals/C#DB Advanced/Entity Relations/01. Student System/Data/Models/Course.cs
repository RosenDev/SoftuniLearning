﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; }=new List<Resource>();
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }=new List<StudentCourse>();
        public ICollection<Homework> HomeworkSubmissions { get; set; }=new List<Homework>();



    }
}