using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacultyProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attend> Attends { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        [ForeignKey("Instrucrtor")]
        public string InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instrucrtor Instrucrtor { get; set; }




    }
}