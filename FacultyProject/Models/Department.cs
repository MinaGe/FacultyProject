using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FacultyProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}