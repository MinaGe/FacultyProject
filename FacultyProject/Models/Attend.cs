using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacultyProject.Models
{
    public class Attend
    {
        public int Id { get; set; }

        public bool Attends { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student {get; set;}


        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }


    }
}