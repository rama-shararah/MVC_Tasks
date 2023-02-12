using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _12_2_2023.Models
{
    public class Student_Course
    {

        [ForeignKey("StudentId")]
        public virtual Student Studentid { get; set; }


        [ForeignKey("CourseId")]
        public virtual Course Courseid { get; set; }

        public string Notes { get; set; }
    }
}